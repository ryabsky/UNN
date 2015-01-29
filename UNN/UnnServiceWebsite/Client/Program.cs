using System.IO;
using System.Xml.Serialization;
using System.Xml.Xsl;
using Client.RoomService;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RoomServiceClient();
 /*           try
            {
                client.AddClassForGroup(new Class
                {
                    ClassName = "QQQQ",
                    IsLecture = false,
                    IsLowerWeek = null,
                    Room = new Room {RoomNumber = 0, BuildingId = 12},
                    StartTime = "13:00",
                    Weekday = Weekday.Tuesday,
                    Teacher = new Teacher {LastName = "Shashkov"},
                    Groups = new[]
                    {
                        new Group
                        {
                            GroupId = 8401,
                            Direction = Direction.PMI
                        }
                    },
                });
            }
            finally
            {
*/                GenerateTimesheet(client);
 //           }

        }

        private static void GenerateTimesheet(RoomServiceClient client)
        {
            Timesheet t = client.GetTimesheet();

            var xmlSerializer = new XmlSerializer(typeof (Timesheet));
            var w = new StreamWriter("x.xml");
            xmlSerializer.Serialize(w, t);
            w.Flush();
            w.Close();

            var xslTransform = new XslCompiledTransform();
            xslTransform.Load("http://localhost/UnnServiceWebsite/Stylesheets/stylesheet_plain.xsl");
            xslTransform.Transform("x.xml", "x.html");
        }
    }
}
