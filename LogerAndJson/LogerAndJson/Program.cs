using System;
using System.Collections.Generic;
using System.IO;
using Serilog;
using Serilog.Core;


namespace HW._15
{
    internal class Program
    {

        static void ShowMotoCollection(IEnumerable<Motorcycle> motorcycles)
        {

            foreach (Motorcycle motorcycle in motorcycles)
            {
                Console.WriteLine($"{motorcycle.Id} {motorcycle.Model}, {motorcycle.Year}, {motorcycle.Odometer}");
            }

            Console.WriteLine();
        }

        private static void ShowMoto(Motorcycle motorcycle)
        {

            Console.WriteLine($"{motorcycle.Id} {motorcycle.Model}, {motorcycle.Year}, {motorcycle.Odometer} \n");
        }

        static string Path()
        {
            string path = "C:\\MotoRepository\\Log\\";

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
                directoryInfo.Create();

            return $"{path}Log.txt";
        }

        private static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(Path(), rollingInterval: RollingInterval.Hour)
                .CreateLogger();	                


            Log.Information("HW._15.App is started."); 

            InMemoryMotoRepository inMemoryMotoRepository = new InMemoryMotoRepository();
            Log.Information("List Repository is created." );

            ShowMotoCollection(inMemoryMotoRepository.GetAll());

            Motorcycle testMotorcycle = new Motorcycle("BMW F 800 ST", 2003, 30000);

            Guid testId = testMotorcycle.Id;

            inMemoryMotoRepository.Create(testMotorcycle);
            Log.Information($"{testMotorcycle.Model}is created and added in the List Repository.");

            ShowMotoCollection(inMemoryMotoRepository.GetAll());

            ShowMoto(inMemoryMotoRepository.GetById(testId));

            Motorcycle motorcycleUpdate = new Motorcycle(testId, "KTM EXC450", 2003, 55000);
            

            inMemoryMotoRepository.Update(motorcycleUpdate);
            Log.Information($"{motorcycleUpdate.Model} is updated.");

            ShowMotoCollection(inMemoryMotoRepository.GetAll());

            inMemoryMotoRepository.Delete(testId);
            Log.Information($"Motorcycle with ID: {testId} is deleted.");

            ShowMotoCollection(inMemoryMotoRepository.GetAll());

            Console.WriteLine("From Json");

            FileMotoRepository fileMotoRepository = new FileMotoRepository();

            Motorcycle testFileMotorcycle = new Motorcycle("Suzuki RF40RV", 2014, 15000);

            Guid testFileId = testFileMotorcycle.Id;

            fileMotoRepository.Create(testFileMotorcycle);
            Log.Information("File Repository is created.");

            ShowMotoCollection(fileMotoRepository.GetAll());
            ShowMoto(fileMotoRepository.GetById(testFileId));

            Motorcycle motorcycleFileUpdate = new Motorcycle(testId, "Suzuki RF40RV", 2003, 55000);

            fileMotoRepository.Update(motorcycleFileUpdate);
            Log.Information($"{motorcycleFileUpdate.Model} is updated.");

            ShowMotoCollection(fileMotoRepository.GetAll());

            fileMotoRepository.Delete(testFileId);
            Log.Information($"Motorcycle with ID: {testId} is deleted.");

            ShowMotoCollection(fileMotoRepository.GetAll());

            Log.Information("HW._15.App is finished.");
        }
    }
}
