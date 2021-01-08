using System;
using System.Collections.Generic;
using System.Text;

namespace HW._15
{
    internal class Motorcycle
    {
        public string Model { get; private set; }
        public int Year { get; private set; }
        public Guid Id { get; private set; }
        public int Odometer { get; private set; }

        internal Motorcycle()
        {
            Model = default;
            Year = default;
            Id = Guid.NewGuid();
            Odometer = default;
        }

        internal Motorcycle(string model, int year, int odometer)
        {
            Model = model;
            Year = year;
            Id = Guid.NewGuid();
            Odometer = odometer;
        }

        internal Motorcycle(Guid id, string model, int year, int odometer)
        {
            Model = model;
            Year = year;
            this.Id = id;
            Odometer = odometer;
        }
    }
}