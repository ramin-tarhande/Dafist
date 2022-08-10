using Dafist.Engine.FieldsData;
using Dafist.Shared;

namespace Dafist.Engine.Updates
{
    public class TargetUpdate
    {
        public string EntityName { get; private set; }
        public UpdateType UpdateType { get; private set; }
        public TargetFieldDataSet CorrelationData { get; private set; }
        public TargetFieldDataSet AllData { get; private set; }
        public TargetUpdate(UpdateType updateType, string entityName, 
            TargetFieldDataSet correlationData,TargetFieldDataSet allData)
        {
            EntityName = entityName;
            UpdateType = updateType;
            AllData = allData;
            CorrelationData = correlationData;
        }

        public string Text()
        {
            return string.Format("{0}: {1}", EntityName, AllData.Text());
        }
    }
}
