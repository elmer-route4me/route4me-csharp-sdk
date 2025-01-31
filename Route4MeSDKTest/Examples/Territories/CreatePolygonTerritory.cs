﻿using Route4MeSDK.DataTypes;
using Route4MeSDK.QueryTypes;
using System;

namespace Route4MeSDK.Examples
{
    public sealed partial class Route4MeExamples
    {
        /// <summary>
        /// Create Territory with Polygon Shape
        /// </summary>
        public void CreatePolygonTerritory()
        {
            // Create the manager with the api key
            Route4MeManager route4Me = new Route4MeManager(c_ApiKey);

            AvoidanceZoneParameters territoryParameters = new AvoidanceZoneParameters
            {
                TerritoryName = "Test Territory",
                TerritoryColor = "ff0000",
                Territory = new Territory
                {
                    Type = TerritoryType.Poly.Description(),
                    Data = new string[] {
			            "37.569752822786455,-77.47833251953125",
			            "37.75886716305343,-77.68974800109863",
			            "37.74763966054455,-77.6917221069336",
			            "37.74655084306813,-77.68863220214844",
			            "37.7502255383101,-77.68125076293945",
			            "37.74797991274437,-77.67498512268066",
			            "37.73327960206065,-77.6411678314209",
			            "37.74430510679532,-77.63172645568848",
			            "37.76641925847049,-77.66846199035645"
		            }
                }
            };

            // Run the query
            string errorString = "";
            TerritoryZone territory = route4Me.CreateTerritory(territoryParameters, out errorString);

            Console.WriteLine("");

            if (territory != null)
            {
                Console.WriteLine("CreatePolygonTerritory executed successfully");

                Console.WriteLine("Territory ID: {0}", territory.TerritoryId);
            }
            else
            {
                Console.WriteLine("CreatePolygonTerritory error: {0}", errorString);
            }
        }
    }
}
