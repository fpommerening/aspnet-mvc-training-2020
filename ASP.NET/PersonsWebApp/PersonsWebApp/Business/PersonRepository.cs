using System.IO;
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