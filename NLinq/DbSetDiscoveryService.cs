using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using NLinq.Utilities;

namespace NLinq
{
    public class DbSetDiscoveryService
    {
        public static readonly MethodInfo SetMethod = typeof(DbContext).GetDeclaredMethod("Set");
        private static readonly ConcurrentDictionary<Type, List<Action<DbContext>>> _objectSetInitializers = new ConcurrentDictionary<Type, List<Action<DbContext>>>();
        private readonly DbContext _context;

        public DbSetDiscoveryService(DbContext context)
        {
            _context = context;
        }

        public void InitializeSets()
        {
            var actions = _objectSetInitializers.GetOrAdd(_context.GetType(), type =>
            {
                var dbContextParam = Expression.Parameter(typeof(DbContext), "dbContext");
                var initDelegates = new List<Action<DbContext>>();
                foreach (var propertyInfo in _context.GetType().GetInstanceProperties().Where(p => p.GetIndexParameters().Length == 0 && p.DeclaringType != typeof(DbContext)))
                {
                    var entityType = GetSetType(propertyInfo.PropertyType);
                    if (entityType != null)
                    {
                        if (!entityType.IsValidStructuralType())
                        {
                            throw new InvalidOperationException(entityType.Name);
                        }

                        EntitySet entitySet = new EntitySet
                        {
                            EntityType = entityType,
                            Schema = "dbo",
                            TableName = entityType.Name
                        };

                        entitySet.EntityProperties = 
                            entityType.GetNonHiddenProperties()
                            .Where(o =>
                                !o.IsStatic() &&
                                o.IsValidStructuralProperty() &&
                                o.Setter().IsPublic &&
                                entityType.BaseType().GetInstanceProperties().All(bp => bp.Name != o.Name))
                            .Select(o => new EntityProperty
                            {
                                ColumnName = o.Name,
                                EntitySet = entitySet,
                                PropertyInfo = o
                            }).ToList();

                        WorkSpace.EntitySetCache.TryAdd(entityType, entitySet);

                        var setter = propertyInfo.Setter();
                        if (setter != null && setter.IsPublic)
                        {
                            var setMethod = SetMethod.MakeGenericMethod(entityType);

                            var newExpression = Expression.Call(dbContextParam, setMethod);
                            var setExpression = Expression.Call(Expression.Convert(dbContextParam, _context.GetType()), setter, newExpression);
                            initDelegates.Add(Expression.Lambda<Action<DbContext>>(setExpression, dbContextParam).Compile());
                        }
                    }
                }
                return initDelegates;
            });
            foreach (var action in actions)
            {
                action(_context);
            }
        }

        private static Type GetSetType(Type declaredType)
        {
            if (!declaredType.IsArray)
            {
                var entityType = GetSetElementType(declaredType);
                if (entityType != null)
                {
                    var setOfT = typeof(DbSet<>).MakeGenericType(entityType);
                    if (declaredType.IsAssignableFrom(setOfT))
                    {
                        return entityType;
                    }
                }
            }

            return null;
        }

        private static Type GetSetElementType(Type setType)
        {
            try
            {
                var setInterface = (setType.IsGenericType() && typeof(DbSet<>).IsAssignableFrom(setType.GetGenericTypeDefinition())) ? setType : setType.GetInterface(typeof(DbSet<>).FullName);

                if (setInterface != null && !setInterface.ContainsGenericParameters())
                {
                    return setInterface.GetGenericArguments()[0];
                }
            }
            catch (AmbiguousMatchException)
            {
            }
            return null;
        }
    }
}
