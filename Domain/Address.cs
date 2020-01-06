using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Address : ValueObject
    {
        public string Street { get; }
        public string City { get; }
        public string StateProvince { get; }
        public string Country { get; }
        public string ZipPostal { get; }

        //private static object[] _properties = new object[] { Street, City, StateProvince, Country, ZipPostal };
        public override IEnumerable<object> Properties 
            => Enumerable.Empty<object>().Append(Street).Append(City).Append(StateProvince).Append(Country).Append(ZipPostal);
    }
}
