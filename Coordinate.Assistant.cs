﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoordinateSharp
{
    /// <summary>
    /// Used to pass coordinate formatting values to the Coordinate object
    /// </summary>
    public class CoordinateFormatOptions
    {
        /// <summary>
        /// Set default values with the constructor.
        /// </summary>
        public CoordinateFormatOptions()
        {
            Format = CoordinateFormatType.Degree_Minutes_Seconds;
            Round = 3;
            Display_Leading_Zeros = false;
            Display_Trailing_Zeros = false;
            Display_Symbols = true;
            Display_Degree_Symbol = true;
            Display_Minute_Symbol = true;
            Display_Seconds_Symbol = true;
            Display_Hyphens = false;
            Position_First = true;
        }
        /// <summary>
        /// Coordinate format type.
        /// </summary>
        public CoordinateFormatType Format { get; set; }
        /// <summary>
        /// Rounds Coordinates to the set value.
        /// </summary>
        public int Round { get; set; }
        /// <summary>
        /// Displays leading zeros.
        /// </summary>
        public bool Display_Leading_Zeros { get; set; }
        /// <summary>
        /// Display trailing zeros.
        /// </summary>
        public bool Display_Trailing_Zeros { get; set; }
        /// <summary>
        /// Allow symbols to display.
        /// </summary>
        public bool Display_Symbols { get; set; }
        /// <summary>
        /// Display degree symbols.
        /// </summary>
        public bool Display_Degree_Symbol { get; set; }
        /// <summary>
        /// Display minute symbols.
        /// </summary>
        public bool Display_Minute_Symbol { get; set; }
        /// <summary>
        /// Display secons symbol.
        /// </summary>
        public bool Display_Seconds_Symbol { get; set; }
        /// <summary>
        /// Display hyphens between values.
        /// </summary>
        public bool Display_Hyphens { get; set; }
        /// <summary>
        /// Show coordinate position first.
        /// Will show last if set 'false'.
        /// </summary>
        public bool Position_First { get; set; }
    }
    /// <summary>
    /// Coordinate Format Types
    /// </summary>
    public enum CoordinateFormatType
    {
        /// <summary>
        /// Decimal Degree Format
        /// </summary>
        /// <remarks>
        /// Example: N 40.456 W 75.456
        /// </remarks>
        Decimal_Degree,
        /// <summary>
        /// Decimal Degree Minutes Format
        /// </summary>
        /// <remarks>
        /// Example: N 40º 34.552' W 70º 45.408'
        /// </remarks>
        Degree_Decimal_Minutes,
        /// <summary>
        /// Decimal Degree Minutes Format
        /// </summary>
        /// <remarks>
        /// Example: N 40º 34" 36.552' W 70º 45" 24.408'
        /// </remarks>
        Degree_Minutes_Seconds,
        /// <summary>
        /// Decimal Format
        /// </summary>
        /// <remarks>
        /// Example: 40.57674 -70.46574
        /// </remarks>
        Decimal
    }
    /// <summary>
    /// Used for UTM/MGRS Conversions
    /// </summary>
    internal class LatZones
    {
        public static List<string> longZongLetters = new List<string>(new string[]{"C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T",
        "U", "V", "W", "X"});
    }
    /// <summary>
    /// Used for handling diagraph determination
    /// </summary>
    internal class Digraphs
    {
        private List<Digraph> digraph1;
        private List<Digraph> digraph2;      

        private String[] digraph1Array = { "A", "B", "C", "D", "E", "F", "G", "H",
        "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X",
        "Y", "Z" };

        private String[] digraph2Array = { "V", "A", "B", "C", "D", "E", "F", "G",
        "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V" };

        public Digraphs()
        {
            digraph1 = new List<Digraph>();
            digraph2 = new List<Digraph>();

            digraph1.Add(new Digraph() { Zone = 1, Letter = "A" });
            digraph1.Add(new Digraph() { Zone = 2, Letter = "B" });
            digraph1.Add(new Digraph() { Zone = 3, Letter = "C" });
            digraph1.Add(new Digraph() { Zone = 4, Letter = "D" });
            digraph1.Add(new Digraph() { Zone = 5, Letter = "E" });
            digraph1.Add(new Digraph() { Zone = 6, Letter = "F" });
            digraph1.Add(new Digraph() { Zone = 7, Letter = "G" });
            digraph1.Add(new Digraph() { Zone = 8, Letter = "H" });
            digraph1.Add(new Digraph() { Zone = 9, Letter = "J" });
            digraph1.Add(new Digraph() { Zone = 10, Letter = "K" });
            digraph1.Add(new Digraph() { Zone = 11, Letter = "L" });
            digraph1.Add(new Digraph() { Zone = 12, Letter = "M" });
            digraph1.Add(new Digraph() { Zone = 13, Letter = "N" });
            digraph1.Add(new Digraph() { Zone = 14, Letter = "P" });
            digraph1.Add(new Digraph() { Zone = 15, Letter = "Q" });
            digraph1.Add(new Digraph() { Zone = 16, Letter = "R" });
            digraph1.Add(new Digraph() { Zone = 17, Letter = "S" });
            digraph1.Add(new Digraph() { Zone = 18, Letter = "T" });
            digraph1.Add(new Digraph() { Zone = 19, Letter = "U" });
            digraph1.Add(new Digraph() { Zone = 20, Letter = "V" });
            digraph1.Add(new Digraph() { Zone = 21, Letter = "W" });
            digraph1.Add(new Digraph() { Zone = 22, Letter = "X" });
            digraph1.Add(new Digraph() { Zone = 23, Letter = "Y" });
            digraph1.Add(new Digraph() { Zone = 24, Letter = "Z" });
            digraph1.Add(new Digraph() { Zone = 1, Letter = "A" });

            digraph2.Add(new Digraph() { Zone = 0, Letter = "V"});
            digraph2.Add(new Digraph() { Zone = 1, Letter = "A" });
            digraph2.Add(new Digraph() { Zone = 2, Letter = "B" });
            digraph2.Add(new Digraph() { Zone = 3, Letter = "C" });
            digraph2.Add(new Digraph() { Zone = 4, Letter = "D" });
            digraph2.Add(new Digraph() { Zone = 5, Letter = "E" });
            digraph2.Add(new Digraph() { Zone = 6, Letter = "F" });
            digraph2.Add(new Digraph() { Zone = 7, Letter = "G" });
            digraph2.Add(new Digraph() { Zone = 8, Letter = "H" });
            digraph2.Add(new Digraph() { Zone = 9, Letter = "J" });
            digraph2.Add(new Digraph() { Zone = 10, Letter = "K" });
            digraph2.Add(new Digraph() { Zone = 11, Letter = "L" });
            digraph2.Add(new Digraph() { Zone = 12, Letter = "M" });
            digraph2.Add(new Digraph() { Zone = 13, Letter = "N" });
            digraph2.Add(new Digraph() { Zone = 14, Letter = "P" });
            digraph2.Add(new Digraph() { Zone = 15, Letter = "Q" });
            digraph2.Add(new Digraph() { Zone = 16, Letter = "R" });
            digraph2.Add(new Digraph() { Zone = 17, Letter = "S" });
            digraph2.Add(new Digraph() { Zone = 18, Letter = "T" });
            digraph2.Add(new Digraph() { Zone = 19, Letter = "U" });
            digraph2.Add(new Digraph() { Zone = 20, Letter = "V" });         
        }

        internal int getDigraph1Index(String letter)
        {
            for (int i = 0; i < digraph1Array.Length; i++)
            {
                if (digraph1Array[i].Equals(letter))
                {
                    return i + 1;
                }
            }

            return -1;
        }

        internal int getDigraph2Index(String letter)
        {
            for (int i = 0; i < digraph2Array.Length; i++)
            {
                if (digraph2Array[i].Equals(letter))
                {
                    return i;
                }
            }

            return -1;
        }
       
        internal String getDigraph1(int longZone, double easting)
        {
            int a1 = longZone;
            double a2 = 8 * ((a1 - 1) % 3) + 1;

            double a3 = easting;
            double a4 = a2 + ((int)(a3 / 100000)) - 1;
            return digraph1.Where(x=>x.Zone == Math.Floor(a4)).FirstOrDefault().Letter;
        }

        internal String getDigraph2(int longZone, double northing)
        {
            int a1 = longZone;
            double a2 = 1 + 5 * ((a1 - 1) % 2);
            double a3 = northing;
            double a4 = (a2 + ((int)(a3 / 100000)));
            a4 = (a2 + ((int)(a3 / 100000.0))) % 20;
            a4 = Math.Floor(a4);
            if (a4 < 0)
            {
                a4 = a4 + 19;
            }
            return digraph2.Where(x => x.Zone == Math.Floor(a4)).FirstOrDefault().Letter;
        }

    }
    /// <summary>
    /// Diagraph model
    /// </summary>
    internal class Digraph
    {
        public int Zone { get; set; }
        public string Letter { get; set; }
    }
    /// <summary>
    /// Used for setting whether a coordinate part is latitudinal or longitudinal
    /// </summary>
    public enum CoordinateType
    {
        /// <summary>
        /// Latitude
        /// </summary>
        Lat,
        /// <summary>
        /// Longitude
        /// </summary>
        Long
    }
    /// <summary>
    /// Used to set a coordinate parts position
    /// </summary>
    public enum CoordinatesPosition
    {
        /// <summary>
        /// North
        /// </summary>
        N,
        /// <summary>
        /// East
        /// </summary>
        E,
        /// <summary>
        /// South
        /// </summary>
        S,
        /// <summary>
        /// West
        /// </summary>
        W
    }
    /// <summary>
    /// Used to display a celestial condition for a set day
    /// </summary>
    public enum CelestialStatus
    {
        /// <summary>
        /// Celestial body rises and sets on the set day.
        /// </summary>
        RiseAndSet,
        /// <summary>
        /// Celestial body is down all day
        /// </summary>
        DownAllDay,
        /// <summary>
        /// Celestial body is up all day
        /// </summary>
        UpAllDay,
        /// <summary>
        /// Celestial body rises, but does not set on the set day
        /// </summary>
        NoRise,
        /// <summary>
        /// Celestial body sets, but does not rise on the set day
        /// </summary>
        NoSet
    }
    /// <summary>
    /// Moon Illumination Information
    /// </summary>
    public class MoonIllum
    {
        /// <summary>
        /// Moon's fraction
        /// </summary>
        public double Fraction { get; set; }
        /// <summary>
        /// Moon's Angle
        /// </summary>
        public double Angle { get; set; }
        /// <summary>
        /// Moon's phase
        /// </summary>
        public double Phase { get; set; }
        /// <summary>
        /// Moon's phase name for the specified day
        /// </summary>
        public string PhaseName { get; set; }

    }
    /// <summary>
    /// Astrological Signs
    /// </summary>
    public class AstrologicalSigns
    {
        /// <summary>
        /// Astrological Zodiac Sign
        /// </summary>
        public string MoonName { get; set; }
        /// <summary>
        /// Astrological Moon Sign
        /// </summary>
        public string MoonSign { get; set; }
        /// <summary>
        /// Astrological Zodiac Sign
        /// </summary>
        public string ZodiacSign { get; set; }
    }
    /// <summary>
    /// Additional Solar Time Information
    /// </summary>
    public class AdditionalSolarTimes
    {
        /// <summary>
        /// Create an AdditionalSolarTimes object.
        /// </summary>
        public AdditionalSolarTimes()
        {
            //Set dates to avoid null errors. If year return 1900 event did not occur.
            CivilDawn = new DateTime(1900,1,1,0,0,0,DateTimeKind.Utc);
            CivilDusk = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            NauticalDawn = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            NauticalDusk = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        }
        /// <summary>
        /// Returns Civil Dawn Time
        /// </summary>
        public DateTime? CivilDawn { get; set; }
        /// <summary>
        /// Returns Civil Dusk Time
        /// </summary>
        public DateTime? CivilDusk { get; set; }
        /// <summary>
        /// Returns Nautical Dawn Time
        /// </summary>
        public DateTime? NauticalDawn { get; set; }
        /// <summary>
        /// Returns Nautical Dusk Time
        /// </summary>
        public DateTime? NauticalDusk { get; set; }
    }
    /// <summary>
    /// Turn on/off eager loading of certain properties
    /// </summary>
    public class EagerLoad
    {
        /// <summary>
        /// Create an EagerLoad object
        /// </summary>
        public EagerLoad()
        {      
            Celestial = true;        
        }
  
        /// <summary>
        /// Eager load celestial information
        /// </summary>
        public bool Celestial { get; set; }     
    }
    
}
