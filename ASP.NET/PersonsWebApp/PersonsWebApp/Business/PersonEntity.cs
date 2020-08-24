using System;

namespace FP.AspNetTraining.PersonsWebApp.Business
{
    public class PersonEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public DateTime Birthday { get; set; }
    }
}