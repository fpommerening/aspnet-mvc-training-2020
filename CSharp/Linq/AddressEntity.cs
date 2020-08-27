using System;
using System.Collections;

namespace GW.AspNetTraining.LinqPlayground
{
    public class AddressEntity : IEquatable<AddressEntity>, IComparable
    {
        public string Street { get; set; }

        public string Number { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is AddressEntity adr)
            {
                return Equals(adr);
            }
            return false;
        }

        public bool Equals(AddressEntity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(other.City, City) &&
                   string.Equals(other.Number, Number) &&
                   string.Equals(other.ZipCode, ZipCode) &&
                   string.Equals(other.Street, Street);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Street != null ? Street.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Number != null ? Number.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ZipCode != null ? ZipCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
                return hashCode;
            }
        }

        int IComparable.CompareTo(object obj)
        {
            if(obj is AddressEntity adr)
            {
                if(!string.Equals(City, adr.City))
                {
                    return string.Compare(City, adr.City);
                }
                if (!string.Equals(ZipCode, adr.ZipCode))
                {
                    return string.Compare(ZipCode, adr.ZipCode);
                }
                if (!string.Equals(Street, adr.Street))
                {
                    return string.Compare(Street, adr.Street);
                }
                if (!string.Equals(Number, adr.Number))
                {
                    return string.Compare(Number, adr.Number);
                }
            }
            return 0;
        }
    }
}
