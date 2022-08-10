using TDCS.General.Tools;

namespace DataGen
{
    class MyProgress
    {
        private readonly Counter counter;

        public MyProgress(DgSettings settings)
        {
            counter= Counter.CreateWrapping(settings.CountWrapping);
        }

        public int Writes
        {
            get
            {
                return (int)counter.Value;
            }
        }

        public void AddDone()
        {
            counter.AddOne();
        }

    }
}
