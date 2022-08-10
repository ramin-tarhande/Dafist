using System;

namespace Dafist.MsSqlAdp.Updates
{
    public class Version
    {
        public long Value { get; private set; }
        public Version(long value) 
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public bool SameAs(Version other)
        {
            return this.Value == other.Value;
        }

        public long Diff(Version other)
        {
            return Math.Abs(this.Value - other.Value);
        }

        public Version Add(long diff)
        {
            return new Version(this.Value+diff);
        }
    }
}
