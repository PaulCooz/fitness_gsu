using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Models.SaveManages
{
    public class FileSaveService : ISaveService
    {
        private const string DIRECTORY_NAME = "Data";

        private readonly string _directoryPath = Path.Combine(Application.persistentDataPath, DIRECTORY_NAME);

        public FileSaveService()
        {
            if (!Directory.Exists(_directoryPath)) Directory.CreateDirectory(_directoryPath);
        }

        public T Get<T>(string key, T defaultValue)
        {
            return !HasKey(key)
                ? defaultValue
                : JsonConvert.DeserializeObject<T>(File.ReadAllText(Path.Combine(_directoryPath, key)));
        }

        public void Set<T>(string key, T value)
        {
            File.WriteAllText(Path.Combine(_directoryPath, key), JsonConvert.SerializeObject(value));
        }

        public bool HasKey(string key)
        {
            return File.Exists(Path.Combine(_directoryPath, key));
        }
    }
}
