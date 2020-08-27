using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace FP.AspNetTraining.PersonsWebApp.Business
{
    public class PersonRepository
    {
        private readonly string _dataStorePath;
        private static object syncRoot = new object();

        public PersonRepository(string dataStorePath)
        {
            _dataStorePath = dataStorePath;
        }

        public List<PersonEntity> GetPersons()
        {
            lock(syncRoot)
            {
                return (GetStore()?.Persons ?? Enumerable.Empty<PersonEntity>()).ToList();
            }
        }

        public void SavePerson(PersonEntity entity)
        {
            lock(syncRoot)
            {
                var store = GetStore() ?? new DataStore();
                var existingEntity = store.Persons.FirstOrDefault(x => x.Id == entity.Id);
                if(existingEntity != null)
                {
                    store.Persons.Remove(existingEntity);
                }
                store.Persons.Add(entity);
                SaveStore(store);
            }
        }

        public void DeletePerson(Guid id)
        {
            lock(syncRoot)
            {
                var store = GetStore();
                if(store == null)
                {
                    return;
                }
                var existingEntity = store.Persons.FirstOrDefault(x => x.Id == id);
                if(existingEntity != null)
                {
                    store.Persons.Remove(existingEntity);
                }
                SaveStore(store);
            }
        }

        private DataStore GetStore()
        {
            if (!File.Exists(_dataStorePath))
            {
                return null;
            }

            var fileContent = File.ReadAllText(_dataStorePath);
            using (var sr = new StringReader(fileContent))
            {
                var serializer = new XmlSerializer(typeof(DataStore));
                return (serializer.Deserialize(sr) as DataStore);
            }
        }

        private void SaveStore(DataStore store)
        {
            using (var sw = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(DataStore));
                serializer.Serialize(sw, store);
                File.WriteAllText(_dataStorePath, sw.ToString());
            }
        }
    }
}