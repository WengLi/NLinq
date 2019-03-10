using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NLinq.Utilities
{
    internal static class TypeExtensions
    {
        internal static readonly MethodInfo GetDefaultMethod = typeof(TypeExtensions).GetOnlyDeclaredMethod("GetDefault");

        private static T GetDefault<T>()
        {
            return default(T);
        }

        internal static MethodInfo GetDeclaredMethod(this Type type, string name, params Type[] parameterTypes)
        {
            return type.GetDeclaredMethods(name).SingleOrDefault(m => m.GetParameters().Select(p => p.ParameterType).SequenceEqual(parameterTypes));
        }

        internal static IEnumerable<MethodInfo> GetDeclaredMethods(this Type type, string name)
        {
            return type.GetTypeInfo().GetDeclaredMethods(name);
        }

        internal static IEnumerable<MethodInfo> GetDeclaredMethods(this Type type)
        {
            return type.GetTypeInfo().DeclaredMethods;
        }

        internal static MethodInfo GetOnlyDeclaredMethod(this Type type, string name)
        {
            return type.GetDeclaredMethods(name).SingleOrDefault();
        }

        internal static IEnumerable<PropertyInfo> GetInstanceProperties(this Type type)
        {
            return type.GetRuntimeProperties().Where(p => !p.IsStatic());
        }

        internal static bool IsGenericType(this Type type)
        {
            return type.GetTypeInfo().IsGenericType;
        }

        internal static bool ContainsGenericParameters(this Type type)
        {
            return type.GetTypeInfo().ContainsGenericParameters;
        }

        internal static bool IsValueType(this Type type)
        {
            return type.GetTypeInfo().IsValueType;
        }

        internal static bool IsInterface(this Type type)
        {
            return type.GetTypeInfo().IsInterface;
        }

        internal static bool IsPrimitive(this Type type)
        {
            return type.GetTypeInfo().IsPrimitive;
        }

        internal static bool IsGenericTypeDefinition(this Type type)
        {
            return type.GetTypeInfo().IsGenericTypeDefinition;
        }

        public static bool IsGenericParameter(this Type type)
        {
            return type.GetTypeInfo().IsGenericParameter;
        }

        internal static Assembly Assembly(this Type type)
        {
            return type.GetTypeInfo().Assembly;
        }

        internal static Type BaseType(this Type type)
        {
            return type.GetTypeInfo().BaseType;
        }

        public static bool IsValidStructuralType(this Type type)
        {
            return !(type.IsGenericType()
                     || type.IsValueType()
                     || type.IsPrimitive()
                     || type.IsInterface()
                     || type.IsArray
                     || type == typeof(string)
                     || type.IsGenericTypeDefinition()
                     || type.IsPointer
                     || type == typeof(object));
        }

        public static bool IsValidStructuralPropertyType(this Type type)
        {
            return !(type.IsGenericTypeDefinition()
                     || type.IsPointer
                     || type == typeof(object));
        }

        public static IEnumerable<PropertyInfo> GetNonHiddenProperties(this Type type)
        {
            return from property in type.GetRuntimeProperties()
                   group property by property.Name into propertyGroup
                   select MostDerived(propertyGroup);
        }

        private static PropertyInfo MostDerived(IEnumerable<PropertyInfo> properties)
        {
            PropertyInfo mostDerivedProperty = null;
            foreach (var property in properties)
            {
                if (mostDerivedProperty == null
                    || (mostDerivedProperty.DeclaringType != null
                        && mostDerivedProperty.DeclaringType.IsAssignableFrom(property.DeclaringType)))
                {
                    mostDerivedProperty = property;
                }
            }

            return mostDerivedProperty;
        }

        public static bool IsCollection(this Type type)
        {
            return type.IsCollection(out type);
        }

        public static bool IsCollection(this Type type, out Type elementType)
        {
            Debug.Assert(!type.IsGenericTypeDefinition());

            elementType = TryGetElementType(type, typeof(ICollection<>));

            if (elementType == null
                || type.IsArray)
            {
                elementType = type;
                return false;
            }

            return true;
        }

        public static Type TryGetElementType(this Type type, Type interfaceOrBaseType)
        {
            Debug.Assert(interfaceOrBaseType.GetGenericArguments().Count() == 1);

            if (!type.IsGenericTypeDefinition())
            {
                var types = GetGenericTypeImplementations(type, interfaceOrBaseType).ToList();

                return types.Count == 1 ? types[0].GetGenericArguments().FirstOrDefault() : null;
            }

            return null;
        }

        public static IEnumerable<Type> GetGenericTypeImplementations(this Type type, Type interfaceOrBaseType)
        {
            if (!type.IsGenericTypeDefinition())
            {
                return (interfaceOrBaseType.IsInterface() ? type.GetInterfaces() : type.GetBaseTypes())
                    .Union(new[] { type })
                    .Where(
                        t => t.IsGenericType()
                             && t.GetGenericTypeDefinition() == interfaceOrBaseType);
            }

            return Enumerable.Empty<Type>();
        }

        public static IEnumerable<Type> GetBaseTypes(this Type type)
        {
            type = type.BaseType();

            while (type != null)
            {
                yield return type;

                type = type.BaseType();
            }
        }
    }
}
