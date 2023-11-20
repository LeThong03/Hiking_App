using SQLite;
using System.Collections.ObjectModel;

namespace Hiking_App
{
    public class MySQLiteDatabase
    {
        private SQLiteConnection dbConnection;
        public const string DB_FILENAME = "MyDB.db3";
        public const SQLiteOpenFlags FLAGS = SQLiteOpenFlags.ReadWrite |
                                                SQLiteOpenFlags.Create |
                                                SQLiteOpenFlags.SharedCache;
        public string dbPath = "";

        public const string TRIP_TABLE = "Trip";
        public const string ID_COL = "id";
        public const string NAME_COL = "name";
        public const string LOCATION_COL = "location";
        public const string DATE_COL = "date";
        public const string DIFFICULT_COL = "difficult";
        public const string PARKING_COL = "parking";
        public const string DESCRIPTION_COL = "description";

        public MySQLiteDatabase()
        {
            init();
        }
        public void init()
        {
            dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, DB_FILENAME);
            dbConnection = new SQLiteConnection(dbPath);
            dbConnection.CreateTable<Trip>();
        }

        public int insertTrip(Trip p)
        {
            return dbConnection.Insert(p);
        }

        public ObservableCollection<Trip> loadTrip()
        {
            return (new ObservableCollection<Trip>(dbConnection.Table<Trip>().ToList()));
        }
        
        public void DeleteAllTrips()
        {
            dbConnection.DeleteAll<Trip>();
        }

    }
}
