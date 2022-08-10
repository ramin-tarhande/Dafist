using Dafist.MsSqlAdp.Updates;

namespace Dafist.MsSqlAdp.Get
{
    class VersionRange
    {
        public Version Lower { get; private set; }
        public Version Upper { get; private set; }
        public VersionRange(Version lower, Version upper)
        {
            Lower = lower;
            Upper = upper;
        }

        public string Text()
        {
            return string.Format("{0} - {1}", Lower, Upper);
        }

        public override string ToString()
        {
            return Text();
        }

        public bool IsEmpty()
        {
            return Lower.SameAs(Upper);
        }

        public long Length()
        {
            return Upper.Diff(Lower);
        }

    }
}
