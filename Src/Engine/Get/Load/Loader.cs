using System.Collections.Generic;
using Dafist.Engine.Updates;

namespace Dafist.Engine.Get.Load
{
    public interface Loader
    {
        IEnumerable<SourceUpdate> Load();
    }
}