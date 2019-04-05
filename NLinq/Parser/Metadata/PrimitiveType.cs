using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace NLinq.Parser.Metadata
{
    public class PrimitiveType : MetadataItem
    {
        private static ReadOnlyCollection<PrimitiveType> _primitiveTypes;

        public PrimitiveTypeKind PrimitiveTypeKind;

        private static void InitializePrimitiveTypes()
        {
            if (_primitiveTypes != null)
            {
                return;
            }

            var primitiveTypes = new PrimitiveType[15];
            primitiveTypes[(int)PrimitiveTypeKind.Binary] = CreatePrimitiveType(typeof(Byte[]), PrimitiveTypeKind.Binary);
            primitiveTypes[(int)PrimitiveTypeKind.Boolean] = CreatePrimitiveType(typeof(Boolean), PrimitiveTypeKind.Boolean);
            primitiveTypes[(int)PrimitiveTypeKind.Byte] = CreatePrimitiveType(typeof(Byte), PrimitiveTypeKind.Byte);
            primitiveTypes[(int)PrimitiveTypeKind.DateTime] = CreatePrimitiveType(typeof(DateTime), PrimitiveTypeKind.DateTime);
            primitiveTypes[(int)PrimitiveTypeKind.Time] = CreatePrimitiveType(typeof(TimeSpan), PrimitiveTypeKind.Time);
            primitiveTypes[(int)PrimitiveTypeKind.DateTimeOffset] = CreatePrimitiveType(typeof(DateTimeOffset), PrimitiveTypeKind.DateTimeOffset);
            primitiveTypes[(int)PrimitiveTypeKind.Decimal] = CreatePrimitiveType(typeof(Decimal), PrimitiveTypeKind.Decimal);
            primitiveTypes[(int)PrimitiveTypeKind.Double] = CreatePrimitiveType(typeof(Double), PrimitiveTypeKind.Double);
            primitiveTypes[(int)PrimitiveTypeKind.Guid] = CreatePrimitiveType(typeof(Guid), PrimitiveTypeKind.Guid);
            primitiveTypes[(int)PrimitiveTypeKind.Int16] = CreatePrimitiveType(typeof(Int16), PrimitiveTypeKind.Int16);
            primitiveTypes[(int)PrimitiveTypeKind.Int32] = CreatePrimitiveType(typeof(Int32), PrimitiveTypeKind.Int32);
            primitiveTypes[(int)PrimitiveTypeKind.Int64] = CreatePrimitiveType(typeof(Int64), PrimitiveTypeKind.Int64);
            primitiveTypes[(int)PrimitiveTypeKind.SByte] = CreatePrimitiveType(typeof(SByte), PrimitiveTypeKind.SByte);
            primitiveTypes[(int)PrimitiveTypeKind.Single] = CreatePrimitiveType(typeof(Single), PrimitiveTypeKind.Single);
            primitiveTypes[(int)PrimitiveTypeKind.String] = CreatePrimitiveType(typeof(String), PrimitiveTypeKind.String);

            var readOnlyTypes = new ReadOnlyCollection<PrimitiveType>(primitiveTypes);
            Interlocked.CompareExchange(ref _primitiveTypes, readOnlyTypes, null);
        }

        private static PrimitiveType CreatePrimitiveType(Type clrType, PrimitiveTypeKind primitiveTypeKind)
        {
            var primitiveType = new PrimitiveType { ClrType = clrType, PrimitiveTypeKind = primitiveTypeKind };
            return primitiveType;
        }

        private static bool TryGetPrimitiveTypeKind(Type clrType, out PrimitiveTypeKind resolvedPrimitiveTypeKind)
        {
            PrimitiveTypeKind? primitiveTypeKind = null;
            if (!clrType.IsEnum)
            {
                switch (Type.GetTypeCode(clrType))
                {
                    case TypeCode.Boolean:
                        primitiveTypeKind = PrimitiveTypeKind.Boolean;
                        break;
                    case TypeCode.Byte:
                        primitiveTypeKind = PrimitiveTypeKind.Byte;
                        break;
                    case TypeCode.DateTime:
                        primitiveTypeKind = PrimitiveTypeKind.DateTime;
                        break;
                    case TypeCode.Decimal:
                        primitiveTypeKind = PrimitiveTypeKind.Decimal;
                        break;
                    case TypeCode.Double:
                        primitiveTypeKind = PrimitiveTypeKind.Double;
                        break;
                    case TypeCode.Int16:
                        primitiveTypeKind = PrimitiveTypeKind.Int16;
                        break;
                    case TypeCode.Int32:
                        primitiveTypeKind = PrimitiveTypeKind.Int32;
                        break;
                    case TypeCode.Int64:
                        primitiveTypeKind = PrimitiveTypeKind.Int64;
                        break;
                    case TypeCode.SByte:
                        primitiveTypeKind = PrimitiveTypeKind.SByte;
                        break;
                    case TypeCode.Single:
                        primitiveTypeKind = PrimitiveTypeKind.Single;
                        break;
                    case TypeCode.String:
                        primitiveTypeKind = PrimitiveTypeKind.String;
                        break;
                    case TypeCode.Object:
                        {
                            if (typeof(byte[]) == clrType)
                            {
                                primitiveTypeKind = PrimitiveTypeKind.Binary;
                            }
                            else if (typeof(DateTimeOffset) == clrType)
                            {
                                primitiveTypeKind = PrimitiveTypeKind.DateTimeOffset;
                            }
                            else if (typeof(Guid) == clrType)
                            {
                                primitiveTypeKind = PrimitiveTypeKind.Guid;
                            }
                            else if (typeof(TimeSpan) == clrType)
                            {
                                primitiveTypeKind = PrimitiveTypeKind.Time;
                            }
                            break;
                        }
                }
            }

            if (primitiveTypeKind.HasValue)
            {
                resolvedPrimitiveTypeKind = primitiveTypeKind.Value;
                return true;
            }
            else
            {
                resolvedPrimitiveTypeKind = default(PrimitiveTypeKind);
                return false;
            }
        }

        internal static PrimitiveType GetPrimitiveType(Type clrType)
        {
            InitializePrimitiveTypes();
            if (TryGetPrimitiveTypeKind(clrType, out PrimitiveTypeKind primitiveTypeKind))
            {
                return _primitiveTypes[(int)primitiveTypeKind];
            }
            return null;
        }
    }
}
