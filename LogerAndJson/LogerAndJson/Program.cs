using System;
using System.Collections.Generic;
using Serilog.Core;
using log4net;
using log4net.Config;

namespace HW._15
{
    internal class Program
    {
        static void ShowMotoCollection(IEnumerable<Motorcycle> motorcycles)
        {
            Logger.Log.Info("Motorcycle collection was shown on the console");

            foreach (Motorcycle motorcycle in motorcycles)
            {
                Console.WriteLine($"{motorcycle.Id} {motorcycle.Model}, {motorcycle.Year}, {motorcycle.Odometer}");
            }

            Console.WriteLine();
        }

        private static void ShowMoto(Motorcycle motorcycle)
        {
            Logger.Log.Info("Motorcycle instance was shown on the console");

            Console.WriteLine($"{motorcycle.Id} {motorcycle.Model}, {motorcycle.Year}, {motorcycle.Odometer} \n");
        }

        private static void Main(string[] args)
        {
            Logger.InitLogger();
            Logger.Log.Info("The program started");

            InMemoryMotoRepository inMemoryMotoRepository = new InMemoryMotoRepository();

            ShowMotoCollection(inMemoryMotoRepository.GetAll());

            Motorcycle testMotorcycle = new Motorcycle("BMW F 800 ST", 2003, 30000);

            Guid testId = testMotorcycle.Id;

            inMemoryMotoRepository.Create(testMotorcycle);

            ShowMotoCollection(inMemoryMotoRepository.GetAll());

            ShowMoto(inMemoryMotoRepository.GetById(testId));

            Motorcycle motorcycleUpdate = new Motorcycle(testId, "KTM EXC450", 2003, 55000);

            inMemoryMotoRepository.Update(motorcycleUpdate);

            ShowMotoCollection(inMemoryMotoRepository.GetAll());

            inMemoryMotoRepository.Delete(testId);

            ShowMotoCollection(inMemoryMotoRepository.GetAll());


            FileMotoRepository fileMotoRepository = new FileMotoRepository();

            Motorcycle testFileMotorcycle = new Motorcycle("Suzuki RF40RV", 2014, 15000);

            Guid testFileId = testFileMotorcycle.Id;

            fileMotoRepository.Create(testFileMotorcycle);

            ShowMotoCollection(fileMotoRepository.GetAll());
            ShowMoto(fileMotoRepository.GetById(testFileId));

            Motorcycle motorcycleFileUpdate = new Motorcycle(testId, "Suzuki RF40RV", 2003, 55000);

            fileMotoRepository.Update(motorcycleFileUpdate);

            ShowMotoCollection(fileMotoRepository.GetAll());

            //fileMotoRepository.Delete(testFileId);

            ShowMotoCollection(fileMotoRepository.GetAll());
        }
    }
}
