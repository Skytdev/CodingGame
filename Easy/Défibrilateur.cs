using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Defib
{
    static void DefibStart(string[] args)
    {
        string LON = Console.ReadLine();
        string LAT = Console.ReadLine();
        int N = int.Parse(Console.ReadLine());
        List<Defibrilateur> defibList = new List<Defibrilateur>();

        var userLongitude = LON.Replace(',', '.');
        var userLatitude = LAT.Replace(',', '.');
        var userLongitudeDouble = Convert.ToDouble(userLongitude);
        var userLatitudeDouble = Convert.ToDouble(userLatitude);
        Console.Error.WriteLine($"/// USER LOC TRANSFORMATION");
        Console.Error.WriteLine($"LON = {LON} / LAT = {LAT}");
        Console.Error.WriteLine($"userLongReplace = {userLongitude} / userLatReplace = {userLatitude}");
        Console.Error.WriteLine($"userLongdouble = {userLongitudeDouble} / userLatDouble = {userLatitudeDouble}\n");


        for (int i = 0; i < N; i++)
        {
            string DEFIB = Console.ReadLine();
            // Console.Error.WriteLine($"{DEFIB}");

            List<string> defibArray = DEFIB.Split(';').ToList();

            var name = defibArray[1];
            var longitude = defibArray[4].Replace(',', '.');
            var latitude = defibArray[5].Replace(',', '.');

            var longitudeDouble = Convert.ToDouble(longitude);
            var latitudeDouble = Convert.ToDouble(latitude);
            Console.Error.WriteLine($"/// DEFIB LOC TRANSFORMATION");
            Console.Error.WriteLine($"defibLongR = {longitude} / defibLatR = {latitude}");
            Console.Error.WriteLine($"defibLongD = {longitudeDouble} / defibLatD = {latitudeDouble}\n");


            var defibrilateur = new Defibrilateur(
                name,
                longitudeDouble,
                latitudeDouble
            );
            defibList.Add(defibrilateur);
            Console.Error.WriteLine("");
        }

        DisplayDefib(defibList);
        DisplayUserLoc(userLongitudeDouble, userLatitudeDouble);

        var closestDefib = GetNearestDefib(defibList, userLongitudeDouble, userLatitudeDouble);


        Console.WriteLine($"{closestDefib}");
    }

    public static string GetNearestDefib(List<Defibrilateur> defiblist, double userLongitude, double userLatitude)
    {
        var distanceList = new List<DefibDistance>();

        foreach (var defib in defiblist)
        {
            var x = (defib.Longitude - userLongitude) * Math.Cos((userLatitude + defib.Latitude) / 2);
            var y = defib.Latitude - userLatitude;
            var distance = ((x * x) + (y * y));

            // Console.Error.WriteLine($"x = {x} / y = {y} / distance = {distance}");
            distanceList.Add(new DefibDistance(distance, defib.Name));
        }

        foreach (var defibDistance in distanceList)
        {
            Console.Error.WriteLine($"///////// DEFIB DISTANCE");
            Console.Error.WriteLine($"name = {defibDistance.Name} / distance = {defibDistance.Distance}");
        }

        return distanceList.MinBy(p => p.Distance).Name;
    }


    public static void DisplayDefib(List<Defibrilateur> defiblist)
    {
        for (int i = 0; i < defiblist.Count(); i++)
        {
            Console.Error.WriteLine($"//// DEFIB {i}");
            Console.Error.WriteLine($"Name = {defiblist[i].Name}");
            Console.Error.WriteLine($"Longitude = {defiblist[i].Longitude}");
            Console.Error.WriteLine($"Longitude = {defiblist[i].Latitude}");
            Console.Error.WriteLine($"\n");
        }
    }

    public static void DisplayUserLoc(double userLong, double userLat)
    {
        Console.Error.WriteLine($"//// USER LOC");
        Console.Error.WriteLine($"Longitude = {userLong}");
        Console.Error.WriteLine($"Latitude = {userLat}");
        Console.Error.WriteLine($"\n");
    }

    public class Defibrilateur
    {
        public string Name { get; }
        public double Longitude { get; }
        public double Latitude { get; }

        public Defibrilateur(string name, double longitude, double latitude)
        {
            Name = name;
            Longitude = longitude;
            Latitude = latitude;
        }
    }

    public class UserLocation
    {
        public double Longitude { get; }
        public double Latitude { get; }

        public UserLocation(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
    }

    public class DefibDistance
    {
        public double Distance { get; }
        public string Name { get; }

        public DefibDistance(double distance, string name)
        {
            Distance = distance;
            Name = name;
        }

    }
}