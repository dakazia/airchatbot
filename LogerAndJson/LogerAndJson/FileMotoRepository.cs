using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace HW._15
{
    internal class FileMotoRepository : IRepository<Motorcycle>
    {
        private readonly string _filePath = $"C:\\MotoRepository\\";

        public FileMotoRepository()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(_filePath);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        }

        public void Create(Motorcycle item)
        {
            string path = $"{_filePath}ID_{item.Id}.json";

            File.WriteAllText(path, JsonConvert.SerializeObject(item));
        }

        public void Delete(Guid id)
        {
            string path = $"{_filePath}ID_{id}.json";

            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            else
            {
                Console.WriteLine("Error. File not found.");
            }
        }

        public void Update(Motorcycle item)
        {
            string path = $"{_filePath}ID_{item.Id}.json";

            FileInfo fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                Console.WriteLine("Error. File not found.");
            }
            else
            {
                Create(item);
            }
        }

        public Motorcycle GetById(Guid id)
        {
            string path = $"{_filePath}ID_{id}.json";

            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
            {
                return JsonConvert.DeserializeObject<Motorcycle>(File.ReadAllText(path));
            }
            else
            {
                Console.WriteLine("Error. File not found.");
                return new Motorcycle();
            }
        }

        public IEnumerable<Motorcycle> GetAll()
        {
            List<Motorcycle> motorcycles = new List<Motorcycle>();

            DirectoryInfo directoryInfo = new DirectoryInfo(_filePath);

            FileInfo[] filesInfo = directoryInfo.GetFiles();

            foreach (var item in filesInfo)
            {
                if (item.Extension.Equals(".json", StringComparison.OrdinalIgnoreCase))
                    motorcycles.Add(JsonConvert.DeserializeObject<Motorcycle>(File.ReadAllText(item.FullName)));
            }

            if (motorcycles.Count.Equals(0))
            {
                Console.WriteLine("Error. Files not found.");
            }

            return motorcycles;
        }
    }
}
