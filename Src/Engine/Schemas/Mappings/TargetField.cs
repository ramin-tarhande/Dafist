using System;
using log4net;
using Dafist.Engine.FieldsData;
using Dafist.Engine.Resilience.SchemaErrors;

namespace Dafist.Engine.Schemas.Mappings
{
    public abstract class TargetField
    {
        public string FieldName { get; private set; }
        protected TargetField(string targetFieldName)
        {
            targetFieldName.ValidateFieldName();

            FieldName = targetFieldName;
        }
    }

    public abstract class ActiveTargetField : TargetField
    {
        /// <summary>
        /// is null for a Constant or a Custom based on more than one fields
        /// </summary>
        public string SingleSourceFieldName { get; private set; }
        protected ActiveTargetField(string targetFieldName, string singleSourceFieldName)
            : base(targetFieldName)
        {
            SingleSourceFieldName = singleSourceFieldName;
        }

        internal bool IsBasedOn(string fieldName)
        {
            return SingleSourceFieldName == fieldName;
        }

        internal FieldData Compute(SourceFieldDataSet sourceData, ILog log)
        {
            try
            {
                return ComputeCore(sourceData);
            }
            catch (FieldNotFoundException x)
            {
                throw new SchemaErrorException(
                    string.Format("target field '{0}' depends on '{1}' and it's not found in source data",
                        FieldName, x.FieldName), x);
            }
            catch
            {
                log.InfoFormat("Error in computing field '{0}'", FieldName);
                throw;
            }
        }

        internal abstract FieldData ComputeCore(SourceFieldDataSet sourceData);
    }

    public class Copy : ActiveTargetField
    {
        public Copy(string fieldName)
            : base(fieldName, fieldName)
        {

        }

        public Copy(string targetFieldName, string sourceFieldName)
            : base(targetFieldName, sourceFieldName)
        {

        }


        internal override FieldData ComputeCore(SourceFieldDataSet sourceData)
        {
            return new FieldData(FieldName, sourceData[SingleSourceFieldName]);
        }
    }

    public class Custom : ActiveTargetField
    {
        public Func<SourceFieldValues, object> Func { get; private set; }
        public Custom(string targetFieldName, Func<SourceFieldValues, object> func, string singleSourceFieldName = null)
            : base(targetFieldName, singleSourceFieldName)
        {
            func.ValidateNotNull();
            Func = func;
        }

        internal override FieldData ComputeCore(SourceFieldDataSet sourceData)
        {
            return new FieldData(FieldName, Func(sourceData));
        }
    }

    public class Constant : ActiveTargetField
    {
        public object Value { get; private set; }
        public Constant(string targetFieldName, object value)
            : base(targetFieldName, null)
        {
            Value = value;
        }

        internal override FieldData ComputeCore(SourceFieldDataSet sourceData)
        {
            return new FieldData(FieldName, Value);
        }
    }

    /// <summary>
    /// automatically set at the target. Defined just for clarity and will be ignored by the engine
    /// </summary>
    public class Auto : TargetField
    {
        public Auto(string targetFieldName)
            : base(targetFieldName)
        {
        }
    }
}
