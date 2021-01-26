namespace CheckIn.AirportDepartment.Table
{
    class FlightItem<T>
    {
        public T Id { get; set; }
        public string Direction { get; set; }
        public string Airline { get; set; }
        public int Flight { get; set; }
        public  string TimeDeparture { get; set; }
    }
}
