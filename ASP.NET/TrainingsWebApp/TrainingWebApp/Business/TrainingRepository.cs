using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace GW.AspNetTraining.TrainingsWebApp.Business
{
    public class TrainingRepository
    {
        private readonly string _dataStorePath;
        private static object syncRoot = new object();

        public TrainingRepository(string dataStorePath)
        {
            _dataStorePath = dataStorePath;
        }

        public List<TrainingEntity> GetTrainings()
        {
            lock (syncRoot)
            {
                return (GetStore()?.Trainings ?? Enumerable.Empty<TrainingEntity>()).ToList();
            }
        }

        public void SaveTraining(TrainingEntity entity)
        {
            lock (syncRoot)
            {
                var store = GetStore() ?? new DataStore();
                var existingEntity = store.Trainings.FirstOrDefault(x => x.Id == entity.Id);
                if (existingEntity != null)
                {
                    store.Trainings.Remove(existingEntity);
                }
                store.Trainings.Add(entity);
                SaveStore(store);
            }
        }

        public void DeleteTraining(Guid id)
        {
            lock (syncRoot)
            {
                var store = GetStore();
                if (store == null)
                {
                    return;
                }
                var existingEntity = store.Trainings.FirstOrDefault(x => x.Id == id);
                if (existingEntity != null)
                {
                    store.Trainings.Remove(existingEntity);
                }
                SaveStore(store);
            }
        }

        public TrainingEntity GetTrainingById(Guid id)
        {
            lock (syncRoot)
            {
                var store = GetStore();
                var item = store.Trainings.FirstOrDefault(x => x.Id == id);
                if (item == null)
                {
                    throw new ArgumentOutOfRangeException($"training with id '{id}' not exist.");
                }
                return item;
            }

        }


        private static readonly LocationEntity[] Locations = new []
        {
            new LocationEntity{Id = "HL", Description = "Halle (Saale)"},
            new LocationEntity{Id = "HH", Description = "Hamburg"},
            new LocationEntity{Id = "HB", Description = "Bremen"},
            new LocationEntity{Id = "MD", Description = "Magdeburg"},
            new LocationEntity{Id = "RD", Description = "Altenholz"},
        };

        public IEnumerable<LocationEntity> GetLocations()
        {
            return Locations;
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