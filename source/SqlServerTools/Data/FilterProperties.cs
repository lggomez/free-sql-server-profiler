using SqlServerTools.Data;
using System;
using System.Text;

namespace AnfiniL.SqlServerTools.Data
{
    public class FilterProperties
    {
        public FilterProperties(TraceField field, ComparisonOperator op, string value)
        {
            Field = field;
            Operator = op;
            Value = value;
        }

        public TraceField Field { get; private set; }

        public ComparisonOperator Operator { get; private set; }

        public string Value { get; set; }

        public object TypedValue
        {
            get
            {
                if (Array.IndexOf(IntFields, Field) > -1 )
                {
                    int value;
                    if (int.TryParse(Value, out value))
                        return value;
                    else
                        return 0;
                }
                else if (Array.IndexOf(LongFields, Field) > -1)
                {
                    long value;

                    return long.TryParse(Value, out value) ? value : 0;
                }
                if (Array.IndexOf(VarBinaryFields, Field) > -1)
                {
                    return Encoding.ASCII.GetBytes(Value);
                }
                else
                    return Value;
            }
        }

        private static readonly TraceField[] IntFields = {
                                             TraceField.DatabaseID, 
                                             TraceField.ObjectID,
                                             TraceField.ClientProcessID,
                                             TraceField.SPID,
                                             TraceField.EventClass
                                         };

        private static readonly TraceField[] LongFields = {
                                             TraceField.TransactionID,
                                             TraceField.Duration,
                                             TraceField.Reads,
                                             TraceField.Writes,
                                             TraceField.CPU
                                         };

        private static readonly TraceField[] VarBinaryFields = {
                                            TraceField.LoginSID
                                         };

        public static readonly TraceField[] nonFilterableFields =
            {
                TraceField.BinaryData,
                TraceField.EventClass,
                TraceField.LoginSID,
                TraceField.ServerName
            };

        public static string CheckFilter(FilterProperties fp)
        {
            if (Array.IndexOf(IntFields, fp.Field) > -1)
            {
                int val;
                if (!int.TryParse(fp.Value, out val))
                    return "The value should be an integer";
                if (OnlyStringOperator(fp))
                    return "The operator is not correct for this field";
            }
            else if (Array.IndexOf(LongFields, fp.Field) > -1)
            {
                long val;
                if (!long.TryParse(fp.Value, out val))
                    return "The value should be a bigint";
                if (OnlyStringOperator(fp))
                    return "The operator is not correct for this field";
            }
            
            return string.Empty;
        }

        private static bool OnlyStringOperator(FilterProperties fp)
        {
            return fp.Operator == ComparisonOperator.Like || fp.Operator == ComparisonOperator.NotLike;
        }

        public bool CheckFilter()
        {
            if ((Operator == ComparisonOperator.Like || Operator == ComparisonOperator.NotLike)
                && string.IsNullOrEmpty(Value))
                Value = "%";

            return true;
        }
    }
}
