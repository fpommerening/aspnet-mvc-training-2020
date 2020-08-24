using System.IO;
using Newtonsoft.Json;

namespace GW.AspNetTraining.LinqPlayground
{
    public class JsonHelper
    {
        public static string JsonPrettify(object obj)
        {
            return JsonHelper.JsonPrettify(JsonConvert.SerializeObject(obj));
        }

        //Source: https://gist.github.com/FrankHu-MSFT/b6750185b19fd4ada4ba36b099985813
        public static string JsonPrettify(string json)
        {
            using (var stringReader = new StringReader(json))
            {
                using (var stringWriter = new StringWriter())
                {
                    var jsonReader = new JsonTextReader(stringReader);
                    var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                    jsonWriter.WriteToken(jsonReader);
                    return stringWriter.ToString();
                }
            }
        }

    }
}
