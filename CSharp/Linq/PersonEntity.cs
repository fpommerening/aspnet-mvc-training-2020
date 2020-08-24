using System;

namespace GW.AspNetTraining.LinqPlayground
{
    public class PersonEntity
    {
        public string Title { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public DateTime Birthday { get; set; }
        
        public AddressEntity Address { get; set; }

        public string[] PhoneNumers { get; set; }

    }
}
