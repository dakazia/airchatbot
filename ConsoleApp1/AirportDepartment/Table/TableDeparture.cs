using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CheckIn.Services;

namespace CheckIn.AirportDepartment.Table
{
    class TableDeparture : FlightItem<int>
    {
        public int Count { get; set; }

        private readonly IInputOutput _inputOutput;

        private const string Path = @"c:\Disk\net\ConsoleApp1\table.json";

        public TableDeparture(IInputOutput inputOutput)
        {
            _inputOutput = inputOutput;
        }


        public List<FlightItem<int>> WriteDataToTable()
        {
            try
            {
                List<FlightItem<int>> restoredFlightItems =
                    JsonSerializer.Deserialize<List<FlightItem<int>>>(File.ReadAllText(Path));
                
                return restoredFlightItems;
            }
            catch (IOException ex)
            {
                _inputOutput.WriteLine(ex.StackTrace);
                throw;
            }
        }
        
        public void ShowTable(List<FlightItem<int>> table)
        {
            string answer;
            do
            {
                _inputOutput.WriteLine(">> To display the departure board select the number of first flights displayed: 5 or 10");
                answer = _inputOutput.ReadLine();

            } while (!(answer.Equals("5") || answer.Equals("10")));

            _inputOutput.WriteLine(">> The Departure board:");
            Count = int.Parse(answer);

            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(
                    $"|Position: {table[i].Id}, Direction: {table[i].Direction}, Airline: {table[i].Airline}, Flight: {table[i].Flight}, Departure time: {table[i].TimeDeparture}|");
            }
        }
    }
}
