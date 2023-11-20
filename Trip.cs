using SQLite;

namespace Hiking_App
{
    [Table("Trip")]
    public class Trip
    {
        [PrimaryKey, AutoIncrement]
        public int TripId { get; set; }
        public string TripName { get; set; }
        public string TripLocation { get; set; }
        public DateTime Tripdate { get; set; }
        public string Difficult { get; set; }
        public bool Parking { get; set; }
        public string TripDescription { get; set; }
        public Trip() { }

        public Trip(int tripId, string tripName, string tripLocation, DateTime date, string difficult, bool parking, string tripDescription)
        {
            TripId = tripId;
            TripName = tripName;
            TripLocation = tripLocation;
            Tripdate = date;
            Difficult = difficult;
            Parking = parking;
            TripDescription = tripDescription;
        }
    }
}
