using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    internal class Converter
    {
        public static void Serialize<T>(T tasks)
        {
            string json = JsonConvert.SerializeObject(tasks);
            File.WriteAllText("C:\\Users\\HP\\Desktop\\Quest.json", json);

        }
        public static T Deserialize<T>()
        {
            if (File.Exists("C:\\Users\\HP\\Desktop\\Quest.json"))
            {
                string text = File.ReadAllText("C:\\Users\\HP\\Desktop\\Quest.json");
                T quest = JsonConvert.DeserializeObject<T>(text);
                return quest;
            }
            else
            {
                File.Create("C:\\Users\\HP\\Desktop\\Quest.json");
                string text = File.ReadAllText("C:\\Users\\HP\\Desktop\\Quest.json");
                T quest = JsonConvert.DeserializeObject<T>(text);
                return quest;
            }

        }
    }
}
