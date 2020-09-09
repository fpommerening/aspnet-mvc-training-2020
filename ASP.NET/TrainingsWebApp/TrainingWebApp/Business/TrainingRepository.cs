using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GW.AspNetTraining.TrainingsWebApp.Business
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly string _dataStorePath;
        private static SemaphoreSlim _semaphoreDataStore = new SemaphoreSlim(1, 1);

        public TrainingRepository(string dataStorePath)
        {
            _dataStorePath = dataStorePath;
        }

        public async Task<List<TrainingEntity>> GetTrainings()
        {
            await _semaphoreDataStore.WaitAsync();
            try
            {
                var datastore = await GetStore();
                return (datastore?.Trainings ?? Enumerable.Empty<TrainingEntity>()).ToList();
            }
            finally
            {
                _semaphoreDataStore.Release();
            }
        }

        public async Task SaveTraining(TrainingEntity entity)
        {
            await _semaphoreDataStore.WaitAsync();
            try
            {
                var store = await GetStore() ?? new DataStore();
                var existingEntity = store.Trainings.FirstOrDefault(x => x.Id == entity.Id);
                if (existingEntity != null)
                {
                    store.Trainings.Remove(existingEntity);
                }
                store.Trainings.Add(entity);
                await SaveStore(store);
            }
            finally
            {
                _semaphoreDataStore.Release();
            }
        }

        public async Task DeleteTraining(Guid id)
        {
            await _semaphoreDataStore.WaitAsync();
            try
            {
                var store = await GetStore();
                if (store == null)
                {
                    return;
                }
                var existingEntity = store.Trainings.FirstOrDefault(x => x.Id == id);
                if (existingEntity != null)
                {
                    store.Trainings.Remove(existingEntity);
                }
                await SaveStore(store);
            }
            finally
            {
                _semaphoreDataStore.Release();
            }
        }

        public async Task<TrainingEntity> GetTrainingById(Guid id)
        {
            await _semaphoreDataStore.WaitAsync();
            try
            {
                var store = await GetStore();
                var item = store?.Trainings?.FirstOrDefault(x => x.Id == id);
                if (item == null)
                {
                    throw new ArgumentOutOfRangeException($"training with id '{id}' not exist.");
                }
                return item;
            }
            finally
            {
                _semaphoreDataStore.Release();
            }

        }

        public async Task<List<OrderEntity>> GetOrders()
        {
            await _semaphoreDataStore.WaitAsync();
            try
            {
                var datastore = await GetStore();
                return (datastore?.Orders ?? Enumerable.Empty<OrderEntity>()).ToList();
            }
            finally
            {
                _semaphoreDataStore.Release();
            }

        }

        public async Task SaveOrder(OrderEntity entity)
        {
            await _semaphoreDataStore.WaitAsync();
            try
            {
                var store = await GetStore() ?? new DataStore();
                var existingEntity = store.Orders.FirstOrDefault(x => x.Id == entity.Id);
                if (existingEntity != null)
                {
                    store.Orders.Remove(existingEntity);
                }
                store.Orders.Add(entity);
                await SaveStore(store);
            }
            finally
            {
                _semaphoreDataStore.Release();
            }
        }

        private static readonly LocationEntity[] Locations = new[]
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

        private async Task<DataStore> GetStore()
        {
            if (!File.Exists(_dataStorePath))
            {
                return null;
            }

            using(var reader = File.OpenText(_dataStorePath))
            {
                var fileContent = await reader.ReadToEndAsync();
                using (var sr = new StringReader(fileContent))
                {
                    var serializer = new XmlSerializer(typeof(DataStore));
                    return (serializer.Deserialize(sr) as DataStore);
                }
            }
        }

        private async Task SaveStore(DataStore store)
        {
            using(var writer = File.CreateText(_dataStorePath))
            {
                using (var sw = new StringWriter())
                {
                    var serializer = new XmlSerializer(typeof(DataStore));
                    serializer.Serialize(sw, store);
                    await writer.WriteAsync(sw.ToString());
                }
            }
        }
    }
}