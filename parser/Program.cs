using System;
using System.IO;

namespace Parser
{
    class Program
    {

        /*
            Known Gtfs files, based on gtfs.org specification
        */
        public static string[] _knownGtfsFiles = new string[]
        {
            "agency.txt",
            "stops.txt",
            "routes.txt",
            "trips.txt",
            "stop_times.txt",
            "calendar.txt",
            "calendar_dates.txt",
            "fare_attributes.txt",
            "fare_rules.txt",
            "fare_products.txt",
            "fare_leg_rules.txt",
            "fare_transfer_rules.txt",
            "areas.txt",
            "stop_areas.txt",
            "shapes.txt",
            "frequencies.txt",
            "transfers.txt",
            "pathways",
            "levels.txt",
            "translations.txt",
            "feed_into.txt",
            "attributions.txt"
        };

        static int Main(string[] args)
        {

            DirectoryInfo _dirInfos = new DirectoryInfo(args[0]);
            
            if(!_dataFolderExists(_dirInfos))
            {
                Console.WriteLine("Path error : " + args[0]);
                return -1;
            }

            Console.WriteLine("Reading folder : " + _dirInfos.Name);

            foreach(var file in _dirInfos.EnumerateFiles())
            {
                string fileName = file.Name;
                string filePath = args[0] + fileName;
                string[] fileLines = new string[0];

                if(!_knownGtfsFiles.Contains(fileName)) continue;

                fileLines = File.ReadAllLines(filePath);

                Console.WriteLine(fileLines[0]);

            }

            return 0;
        }

        public static Boolean _dataFolderExists(DirectoryInfo di){
            try{
                return di.Exists;
            }catch(Exception e){
                Console.WriteLine("Proccess failed: " + e.ToString());
                return false;
            }
            finally{}
        }

        
    }
}