using System;
using System.Collections.Generic;
using System.Text;
using Serilog.Core;

namespace HW._15
{
    internal class InMemoryMotoRepository : IRepository<Motorcycle>
    {
        private static readonly List<Motorcycle> Motorcycles = new List<Motorcycle>() {new Motorcycle("BMW F 800 ST", 2000, 11000),
                                                                                        new Motorcycle("Suzuki RF40RV", 2004, 60000),
                                                                                        new Motorcycle("Kawasaki GPZ-900R", 2020, 1000) };
        
        public void Create(Motorcycle item)
        {
            Logger.Log.Info($"Item {item.Id} was created");

            Motorcycles.Add(item);
        }

        public void Delete(Guid id)
        {
            Logger.Log.Info($"Item {id} was deleted");

            Motorcycles.Remove(GetById(id));
        }

        public IEnumerable<Motorcycle> GetAll()
        {
            return Motorcycles;
        }

        public Motorcycle GetById(Guid id)
        {
            Motorcycle result = new Motorcycle();

            foreach (Motorcycle motorcycle in Motorcycles)
            {
                if (motorcycle.Id == id)
                {
                    result = motorcycle;
                    break;
                }
            }
            return result;
        }

        public void Update(Motorcycle motorcycle)
        {
            Logger.Log.Info($"Item {motorcycle.Id} was updated");

            int index = 0;
            for (int i = 0; i < Motorcycles.Count; i++)
            {
                if (Motorcycles[i].Id == motorcycle.Id)
                {
                    index = i;
                    break;
                }
            }
            Motorcycles[index] = motorcycle;
        }
    }
}