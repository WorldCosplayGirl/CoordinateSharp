﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;

namespace CoordinateSharp
{
    /// <summary>
    /// The main class for Celestial information
    /// </summary>
    /// <remarks>
    /// This class can calculate various pieces of solar and lunar data, based on location and date
    /// </remarks>
    public class Celestial : INotifyPropertyChanged
    {
      
        //When as rise or a set does not occur, the DateTime will return null
        /// <summary>
        /// Creates an empty Celestial object
        /// </summary>
        public Celestial()
        {
            AstrologicalSigns = new AstrologicalSigns();
            CalculateCelestialTime(0, 0, new DateTime(1900, 1, 1,0,0,0,DateTimeKind.Utc));   
        }
        private Celestial(bool hasCalcs)
        {
            
            AstrologicalSigns = new AstrologicalSigns();
            if (hasCalcs) { CalculateCelestialTime(0, 0, new DateTime(1900, 1, 1,0,0,0,DateTimeKind.Utc)); }
        }
        /// <summary>
        /// Creates a Celestial object based on a geographic lat/long coordinate and specified date
        /// </summary>
        /// <param name="lat">Decimal Format Latitude</param>
        /// <param name="longi">Decimal Format Longitude</param>
        /// <param name="geoDate">Geographic UTC DateTime</param>
        public Celestial(double lat, double longi, DateTime geoDate)
        {
            DateTime d = new DateTime(geoDate.Year, geoDate.Month, geoDate.Day, geoDate.Hour, geoDate.Minute, geoDate.Second, DateTimeKind.Utc);
            AstrologicalSigns = new AstrologicalSigns();
            CalculateCelestialTime(lat, longi, d);
        }
        /// <summary>
        /// Creates a Celestial object based on the location and date in the provided Coordinate object
        /// </summary>
        /// <param name="c">Coordinate</param>
        /// <returns>A populated Celestial object</returns>
        public static Celestial LoadCelestial(Coordinate c)
        {
            DateTime geoDate = c.GeoDate;
            DateTime d = new DateTime(geoDate.Year, geoDate.Month, geoDate.Day, geoDate.Hour, geoDate.Minute, geoDate.Second, DateTimeKind.Utc);
            Celestial cel = new Celestial(c.Latitude.ToDouble(), c.Longitude.ToDouble(), c.GeoDate);
            return cel;
        }
       
       
        /// <summary>
        /// UTC Sunset time
        /// </summary>
        public DateTime? SunSet { get; set; }
        /// <summary>
        /// UTC Sunrise time
        /// </summary>
        public DateTime? SunRise { get; set; }
        /// <summary>
        /// UTC Moonset time
        /// </summary>
        public DateTime? MoonSet { get; set; }
        /// <summary>
        /// UTC Moonrise time
        /// </summary>
        public DateTime? MoonRise { get; set; }
        /// <summary>
        /// Sun azimuth in degrees
        /// </summary>
        public double SunAzimuth { get; set; }
        /// <summary>
        /// Sun altitude in degrees
        /// </summary>
        public double SunAltitude { get; set; }
        /// <summary>
        /// Estimated moon distance from the earth in kilometers
        /// </summary>
        public double? MoonDistance { get; set; }
        /// <summary>
        /// Sun's Condition based on the provided UTC date
        /// </summary>
        public CelestialStatus SunCondition { get; set; }
        /// <summary>
        /// Moon's condition based on the provided UTC date
        /// </summary>
        public CelestialStatus MoonCondition { get; set; }

        /// <summary>
        /// Moon ilumination details based on the provided UTC date
        /// </summary>
        /// <remarks>
        /// Contains phase, phase name, fraction and angle
        /// </remarks>
        public MoonIllum MoonIllum { get; set; }
        /// <summary>
        /// Additional solar event times based on the provided UTC date and location
        /// </summary>
        /// <remarks>Contains civil and nautical dawn and dusk times.</remarks>
        public AdditionalSolarTimes AdditionalSolarTimes { get; set; }
        /// <summary>
        /// Astrological signs based on the provided UTC date
        /// </summary>
        /// <remarks>
        /// Contains zodiac, moon sign and moon name during full moon events
        /// </remarks>
        public AstrologicalSigns AstrologicalSigns { get; set; }

        /// <summary>
        /// Moon illumination phase
        /// </summary>
        /// <remarks>
        /// This property is obsolete and has moved to the MoonIllum property
        /// </remarks>
        [Obsolete("MoonPhase can be accessed through the MoonIllum property.")]
        public double MoonPhase { get { return this.MoonIllum.Phase; } }
       
        /// <summary>
        /// Calculates all celestial data. Coordinates will notify as changes occur
        /// </summary>
        /// <param name="lat">Decimal format latitude</param>
        /// <param name="longi">Decimal format longitude</param>
        /// <param name="date">Geographic DateTime</param>
        internal void CalculateCelestialTime(double lat, double longi, DateTime date)
        {

            date = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Utc);
            SunCalc.CalculateSunTime(lat, longi, date, this);
            MoonCalc.GetMoonTimes(date, lat, longi, this);
            MoonCalc.GetMoonDistance(date, this);


            SunCalc.CalculateZodiacSign(date, this);
            MoonCalc.GetMoonSign(date, this);

            MoonCalc.GetMoonIllumination(date, this);

            SunCalc.CalculateAdditionSolarTimes(date, longi, lat, this);



        }
        /// <summary>
        /// Calculate celestial data based on lat/long and utc date
        /// </summary>
        /// <param name="lat">Decimal format latitude</param>
        /// <param name="longi">Decimal format longitude</param>
        /// <param name="date">Geographic DateTime</param>
        /// <returns>Fully populated Celestial object</returns>
        public static Celestial CalculateCelestialTimes(double lat, double longi, DateTime date)
        {
            date = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Utc);
          
            Celestial c = new Celestial(false);

            SunCalc.CalculateSunTime(lat, longi, date, c);
            MoonCalc.GetMoonTimes(date, lat, longi, c);
            MoonCalc.GetMoonDistance(date, c);
            SunCalc.CalculateZodiacSign(date, c);
            MoonCalc.GetMoonSign(date, c);
            MoonCalc.GetMoonIllumination(date, c);
            SunCalc.CalculateAdditionSolarTimes(date, longi, lat, c);

            return c;
        }
        /// <summary>
        /// Calculate sun data based on lat/long and date
        /// </summary>
        /// <param name="lat">Decimal format latitude</param>
        /// <param name="longi">Decimal format longitude</param>
        /// <param name="date">Geographic DateTime</param>
        /// <returns>Partially populated Celestial object</returns>
        public static Celestial CalculateSunData(double lat, double longi, DateTime date)
        {
            date = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Utc);
          
            Celestial c = new Celestial(false);
            SunCalc.CalculateSunTime(lat, longi, date, c);
            SunCalc.CalculateZodiacSign(date, c);

            SunCalc.CalculateAdditionSolarTimes(date, longi, lat, c);

            return c;
        }
        /// <summary>
        /// Calculate moon data based on lat/long and date
        /// </summary>
        /// <param name="lat">Decimal format latitude</param>
        /// <param name="longi">Decimal format longitude</param>
        /// <param name="date">Geographic DateTime</param>
        /// <returns>Partially populated Celestial object</returns>
        public static Celestial CalculateMoonData(double lat, double longi, DateTime date)
        {
            date = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Utc);
          
            Celestial c = new Celestial(false);

            MoonCalc.GetMoonTimes(date, lat, longi, c);
            MoonCalc.GetMoonDistance(date, c);
            MoonCalc.GetMoonSign(date, c);
            MoonCalc.GetMoonIllumination(date, c);

            return c;
        }
        
        /// <summary>
        /// Property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify property changed
        /// </summary>
        /// <param name="propName">Property name</param>
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
