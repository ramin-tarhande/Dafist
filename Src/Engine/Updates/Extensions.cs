using System.Linq;
using Dafist.Shared.Messages;

namespace Dafist.Engine.Updates
{
    public static class Extensions
    {
        public static UpdateMessage ToMessage(this TargetUpdate update)
        {
            var data = update.AllData;

            var md = data.ToDictionary(fd => fd.Name, fd => fd.Value);

            return new UpdateMessage(update.EntityName, update.UpdateType, data.FieldsInclusiveness, md);
        }
    }
}
