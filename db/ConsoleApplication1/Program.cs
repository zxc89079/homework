using db.model;
using db.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var importservice = new db.service.import();
            var db = new db.Repository.stationrep();

            var stations = import.FindStations(@"F:\water_info.xml");

            stations
              .ToList().ForEach(station =>
            {
             db.Create(stations);
            });

            // var station = importservice.FindStations(@"F:\water_info.xml");
            // var stations = db.FindAllStations();

            //  ShowStation(stations);

            // Console.ReadKey(); //暫停
        }

        /*  public static void ShowStation(List<Station> stations)
          {

              Console.WriteLine(string.Format("共收到{0}筆監測站的資料", stations.Count));
              stations.ForEach(x =>
              {
                  Console.WriteLine(string.Format("站點名稱：{0},地址:{1}", x.ObservatoryName, x.LocationAddress));


              });


          }*/
    }
}
