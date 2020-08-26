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


        private static readonly LocationEntity[] Locations = {
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