using System.Collections.Generic;

namespace FP.AspNetTraining.PersonsWebApp.Business
{
    public class DataStore
    {
        public List<PersonEntity> Persons { get; set; } = new List<PersonEntity>();
    }
}