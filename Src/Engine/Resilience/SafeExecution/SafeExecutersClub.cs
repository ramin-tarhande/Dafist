using System.Collections.Generic;

namespace Dafist.Engine.Resilience.SafeExecution
{
    public class SafeExecutersClub
    {
        private readonly List<SafeExecuter> list;
        public SafeExecutersClub()
        {
            list=new List<SafeExecuter>();
        }

        public void Register(SafeExecuter re)
        {
            list.Add(re);
        }

        public void StopAll()
        {
            foreach (var safeExecuter in list)
            {
                safeExecuter.Stop();
            }
        }
    }
}
