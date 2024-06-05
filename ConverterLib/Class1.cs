using Newtonsoft.Json;

namespace ConverterLib
{
    public class Converter
    {
        public static void Serialize<T>(T info, string fileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(info);
            File.WriteAllText(desktop + "\\" + fileName, json);

        }
        public static T Deserialize<T>(string fileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (File.Exists(desktop + "\\" + fileName))
            {
                string text = File.ReadAllText(desktop + "\\" + fileName);
                T info = JsonConvert.DeserializeObject<T>(text);
                return info;
            }
            else
            {
                File.Create(desktop + "\\" + fileName);
                string text = File.ReadAllText(desktop + "\\" + fileName);
                T info = JsonConvert.DeserializeObject<T>(text);
                return info;
            }

        }
    }
}