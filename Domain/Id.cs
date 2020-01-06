using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Id : ValueObject
    {
        public uint Value { get; }
        public override IEnumerable<object> Properties => Enumerable.Empty<object>().Append(Value);

        public Id(uint id)
        {
            Value = id;
        }

        public static explicit operator uint(Id x)
        {
            return x.Value;
        }
        public static explicit operator string(Id x)
        {
            return x.Value.ToString();
        }
    }
}