using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace messenger
{
    internal class Converter
    {
        public static void Serialize<T>(T clients)
        {
            string json = JsonConvert.SerializeObject(clients);
            File.WriteAllText("..\\Clients.json", json);

        }
        public static T Deserialize<T>()
        {
            if (File.Exists("..\\Clients.json"))
            {
                string text = File.ReadAllText("..\\Clients.json");
                T tasks = JsonConvert.DeserializeObject<T>(text);
                return tasks;
            }
            else
            {
                File.Create("..\\Clients.json");
                string text = File.ReadAllText("..\\Clients.json");
                T tasks = JsonConvert.DeserializeObject<T>(text);
                return tasks;
            }

        }
    }

}
