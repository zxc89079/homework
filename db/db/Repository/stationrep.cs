using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace db.Repository
{
    public class stationrep
    {
        private const string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\homework-master\db\ConsoleApplication1\db_data\water_data.mdf;Integrated Security=True";


        public void Create(List<model.Station> stations)
        {
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            foreach (var station in stations)
            {
                var command = new System.Data.SqlClient.SqlCommand("", connection);
                command.CommandText = string.Format(@"
INSERT        INTO    water(LocationAddress, ObservatoryName, LocationByTWD67, CreateTime)
VALUES          (N'{0}',N'{1}',N'{2}',N'{3}')
", station.LocationAddress, station.ObservatoryName, station.LocationByTWD67, station.CreateTime.ToString("yyyy/MM/dd"));

                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
