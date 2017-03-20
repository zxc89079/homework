using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace csharp_xml
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Station> stations = new List<Station>();

            var xml = XElement.Load(@"F:\water_info.xml");

            XNamespace gml = @"http://www.opengis.net/gml/3.2"; //宣告命名空間
            XNamespace twed= @"http://twed.wra.gov.tw/twedml/opendata";

            var StationNode = xml.Descendants(twed + "RiverStageObservatoryProfile").ToList(); //descendats?

            StationNode.Where(x => !x.IsEmpty).ToList().ForEach(stationNode =>
            {
                var ObservatoryName = stationNode.Element(twed + "ObservatoryName").Value.Trim(); //trim移除開頭結尾的空白
                var LocationAddress = stationNode.Element(twed + "LocationAddress").Value.Trim();

                var LocationByTWD67pos = stationNode.Element(twed + "LocationByTWD67").Descendants(gml + "pos").FirstOrDefault().Value.Trim();

                Station stationData = new Station();
                stationData.LocationAddress = LocationAddress;
                stationData.ObservatoryName = ObservatoryName;
                stationData.LocationByTWD67 = LocationByTWD67pos;
                stationData.CreateTime = DateTime.Now;
                stations.Add(stationData);

                Console.WriteLine("河川:"+stationData.ObservatoryName+"地址:" + stationData.LocationAddress+"座標:" + stationData.LocationByTWD67 + "\r\n");
               

            });
            Console.ReadLine();




        }
    }
}
