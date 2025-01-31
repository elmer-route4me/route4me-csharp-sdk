﻿using Route4MeSDK.DataTypes;
using Route4MeSDK.Examples;
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Route4MeSDKTest
{
  [TestFixture]
  public class DumbTest
  {
    [Test]
    public void TestNothing()
    {
      Assert.That(true, Is.True);
    }
  }

  internal sealed class Program
  {
    static void Main(string[] args)
    {
      Route4MeExamples examples = new Route4MeExamples();
       
      DataObject dataObject = null;

      DataObject dataObject1 = examples.SingleDriverRoute10Stops();
      dataObject = dataObject1;
      DataObjectRoute routeSingleDriverRoute10Stops = (dataObject != null && dataObject.Routes != null && dataObject.Routes.Length > 0) ? dataObject.Routes[0] : null;
      string routeId_SingleDriverRoute10Stops = (routeSingleDriverRoute10Stops != null) ? routeSingleDriverRoute10Stops.RouteID : null;

      if (routeSingleDriverRoute10Stops != null)
        examples.ResequenceRouteDestinations(routeSingleDriverRoute10Stops);
      else
        System.Console.WriteLine("ResequenceRouteDestinations not called. routeSingleDriverRoute10Stops == null.");

      if (routeSingleDriverRoute10Stops != null)
          examples.ResequenceReoptimizeRoute(routeId_SingleDriverRoute10Stops);
      else
          System.Console.WriteLine("ResequenceReoptimizeRoute not called. routeSingleDriverRoute10Stops == null.");

      int[] destinationIds = examples.AddRouteDestinations(routeId_SingleDriverRoute10Stops);
      if (destinationIds != null && destinationIds.Length > 0)
      {
        examples.RemoveRouteDestination(routeId_SingleDriverRoute10Stops, destinationIds[0]);
      }

      DataObject dataObject2 = examples.SingleDriverRoundTrip();
      dataObject = dataObject2;
      string routeId_SingleDriverRoundTrip = (dataObject != null && dataObject.Routes != null && dataObject.Routes.Length > 0) ? dataObject.Routes[0].RouteID : null;

      string routeIdToMoveTo = routeId_SingleDriverRoundTrip;
      int routeDestinationIdToMove = (dataObject1 != null && dataObject1.Routes != null && dataObject1.Routes.Length > 0 && dataObject1.Routes[0].Addresses.Length > 1 && dataObject1.Routes[0].Addresses[1].RouteDestinationId != null) ? dataObject1.Routes[0].Addresses[1].RouteDestinationId.Value : 0;
      int afterDestinationIdToMoveAfter = (dataObject2 != null && dataObject2.Routes != null && dataObject2.Routes.Length > 0 && dataObject2.Routes[0].Addresses.Length > 1 && dataObject2.Routes[0].Addresses[0].RouteDestinationId != null) ? dataObject2.Routes[0].Addresses[0].RouteDestinationId.Value : 0;
      if (routeIdToMoveTo != null && routeDestinationIdToMove != 0 && afterDestinationIdToMoveAfter != 0)
      {
        examples.MoveDestinationToRoute(routeIdToMoveTo, routeDestinationIdToMove, afterDestinationIdToMoveAfter);
      }
      else
      {
        System.Console.WriteLine("MoveDestinationToRoute not called. routeDestinationId = {0}, afterDestinationId = {1}.", routeDestinationIdToMove, afterDestinationIdToMoveAfter);
      }

      string optimizationProblemID = examples.SingleDriverRoundTripGeneric();

      dataObject = examples.MultipleDepotMultipleDriver();
      string routeId_MultipleDepotMultipleDriver = (dataObject != null && dataObject.Routes != null && dataObject.Routes.Length > 0) ? dataObject.Routes[0].RouteID : null;

      dataObject = examples.MultipleDepotMultipleDriverTimeWindow();
      string routeId_MultipleDepotMultipleDriverTimeWindow = (dataObject != null && dataObject.Routes != null && dataObject.Routes.Length > 0) ? dataObject.Routes[0].RouteID : null;

      dataObject = examples.SingleDepotMultipleDriverNoTimeWindow();
      string routeId_SingleDepotMultipleDriverNoTimeWindow = (dataObject != null && dataObject.Routes != null && dataObject.Routes.Length > 0) ? dataObject.Routes[0].RouteID : null;

      dataObject = examples.MultipleDepotMultipleDriverWith24StopsTimeWindow();
      string routeId_MultipleDepotMultipleDriverWith24StopsTimeWindow = (dataObject != null && dataObject.Routes != null && dataObject.Routes.Length > 0) ? dataObject.Routes[0].RouteID : null;

      dataObject = examples.SingleDriverMultipleTimeWindows();
      string routeId_SingleDriverMultipleTimeWindows = (dataObject != null && dataObject.Routes != null && dataObject.Routes.Length > 0) ? dataObject.Routes[0].RouteID : null;

      if (optimizationProblemID != null)
        examples.GetOptimization(optimizationProblemID);
      else
        System.Console.WriteLine("GetOptimization not called. optimizationProblemID == null.");
      
      examples.GetOptimizations();

      if (optimizationProblemID != null)
      {
        dataObject = examples.AddDestinationToOptimization(optimizationProblemID, true);
      }
      else
      {
        System.Console.WriteLine("AddDestinationToOptimization not called. optimizationProblemID == null.");
        dataObject = null;
      }

      if (optimizationProblemID != null)
      {
        Address destinationToRemove = (dataObject != null && dataObject.Addresses.Length > 0) ? dataObject.Addresses[dataObject.Addresses.Length - 1] : null;
        if (destinationToRemove != null)
          examples.RemoveDestinationFromOptimization(optimizationProblemID, destinationToRemove.RouteDestinationId.Value, false);
        else
          System.Console.WriteLine("RemoveDestinationFromOptimization not called. destinationToRemove == null.");
      }
      else
        System.Console.WriteLine("RemoveDestinationFromOptimization not called. optimizationProblemID == null.");

      if (optimizationProblemID != null)
        examples.ReOptimization(optimizationProblemID);
      else
        System.Console.WriteLine("ReOptimization not called. optimizationProblemID == null.");

      if (routeId_SingleDriverRoute10Stops != null)
      {
        examples.UpdateRoute(routeId_SingleDriverRoute10Stops);
        examples.ReoptimizeRoute(routeId_SingleDriverRoute10Stops);
        bool getRouteDirections = true;
        bool getRoutePathPoints = true;
        examples.GetRoute(routeId_SingleDriverRoute10Stops, getRouteDirections, getRoutePathPoints);
      }
      else
      {
        System.Console.WriteLine("UpdateRoute, ReoptimizeRoute, GetRoute not called. routeId_SingleDriverRoute10Stops == null.");
      }

      examples.GetRoutes();
      examples.GetUsers();

      if (routeId_SingleDriverRoute10Stops != null)
        examples.LogCustomActivity("Test User Activity " + DateTime.Now.ToString(), routeId_SingleDriverRoute10Stops);
      else
        System.Console.WriteLine("LogCustomActivity not called. routeId_SingleDriverRoute10Stops == null.");

      if (routeId_SingleDriverRoute10Stops != null)
        examples.GetActivities(routeId_SingleDriverRoute10Stops);
      else
        System.Console.WriteLine("GetActivities not called. routeId_SingleDriverRoute10Stops == null.");

      if (routeIdToMoveTo != null && routeDestinationIdToMove != 0)
      {
        examples.GetAddress(routeIdToMoveTo, routeDestinationIdToMove);

        examples.AddAddressNote(routeIdToMoveTo, routeDestinationIdToMove);
        examples.AddAddressNoteWithFile(routeIdToMoveTo, routeDestinationIdToMove);
        examples.GetAddressNotes(routeIdToMoveTo, routeDestinationIdToMove);
      }
      else
      {
        System.Console.WriteLine("AddAddressNote, GetAddress, GetAddressNotes not called. routeIdToMoveTo == null || routeDestinationIdToMove == 0.");
      }

      string routeId_DuplicateRoute = null;
      if (routeId_SingleDriverRoute10Stops != null)
        routeId_DuplicateRoute = examples.DuplicateRoute(routeId_SingleDriverRoute10Stops);
      else
        System.Console.WriteLine("DuplicateRoute not called. routeId_SingleDriverRoute10Stops == null.");

      //disabled by default, not necessary for optimization tests
      //not all accounts are capable of storing gps data
      /*if (routeId_SingleDriverRoute10Stops != null)
      {
        examples.SetGPSPosition(routeId_SingleDriverRoute10Stops);
        examples.TrackDeviceLastLocationHistory(routeId_SingleDriverRoute10Stops);
      }
      else
      {
        System.Console.WriteLine("SetGPSPosition, TrackDeviceLastLocationHistory not called. routeId_SingleDriverRoute10Stops == null.");
      }*/

      List<string> routeIdsToDelete = new List<string>();
      if (routeId_SingleDriverRoute10Stops != null)
        routeIdsToDelete.Add(routeId_SingleDriverRoute10Stops);
      if (routeId_SingleDriverRoundTrip != null)
        routeIdsToDelete.Add(routeId_SingleDriverRoundTrip);
      if (routeId_DuplicateRoute != null)
        routeIdsToDelete.Add(routeId_DuplicateRoute);
      if (routeId_MultipleDepotMultipleDriver != null)
        routeIdsToDelete.Add(routeId_MultipleDepotMultipleDriver);
      if (routeId_MultipleDepotMultipleDriverTimeWindow != null)
        routeIdsToDelete.Add(routeId_MultipleDepotMultipleDriverTimeWindow);
      if (routeId_SingleDepotMultipleDriverNoTimeWindow != null)
        routeIdsToDelete.Add(routeId_SingleDepotMultipleDriverNoTimeWindow);
      if (routeId_MultipleDepotMultipleDriverWith24StopsTimeWindow != null)
        routeIdsToDelete.Add(routeId_MultipleDepotMultipleDriverWith24StopsTimeWindow);
      if (routeId_SingleDriverMultipleTimeWindows != null)
        routeIdsToDelete.Add(routeId_SingleDriverMultipleTimeWindows);

      if (routeIdsToDelete.Count > 0)
        examples.DeleteRoutes(routeIdsToDelete.ToArray());
      else
        System.Console.WriteLine("routeIdsToDelete.Count == 0. DeleteRoutes not called.");

      // Remove optimization
      if (optimizationProblemID != null)
      {
          List<string> lsOptIDs = new List<string>();
          lsOptIDs.Add(optimizationProblemID);
          examples.RemoveOptimization(lsOptIDs.ToArray());
      }
      else
          System.Console.WriteLine("RemoveOptimization not called. optimizationProblemID == null.");


      // Address Book
      AddressBookContact contact1 = examples.AddAddressBookContact();
      AddressBookContact contact2 = examples.AddAddressBookContact();
      examples.GetAddressBookContacts();
      if (contact1 != null)
      {
        contact1.last_name = "Updated " + (new Random()).Next().ToString();
        examples.UpdateAddressBookContact(contact1);
      }
      else
      {
        System.Console.WriteLine("contact1 == null. UpdateAddressBookContact not called.");
      }
      List<string> addressIdsToRemove = new List<string>();
      if (contact1 != null)
          addressIdsToRemove.Add(contact1.address_id.ToString());
      if (contact2 != null)
          addressIdsToRemove.Add(contact2.address_id.ToString());
      examples.RemoveAddressBookContacts(addressIdsToRemove.ToArray());


      // Avoidance Zones
      string territoryId = examples.AddAvoidanceZone();
      examples.GetAvoidanceZones();
      if (territoryId != null)
        examples.GetAvoidanceZone(territoryId);
      else
        System.Console.WriteLine("GetAvoidanceZone not called. territoryId == null.");
      if (territoryId != null)
        examples.UpdateAvoidanceZone(territoryId);
      else
        System.Console.WriteLine("UpdateAvoidanceZone not called. territoryId == null.");
      if (territoryId != null)
        examples.DeleteAvoidanceZone(territoryId);
      else
        System.Console.WriteLine("DeleteAvoidanceZone not called. territoryId == null.");


      // Orders
      Order order1 = examples.AddOrder();
      Order order2 = examples.AddOrder();
      examples.GetOrders();
      if (order1 != null)
      {
        order1.EXT_FIELD_last_name = "Updated " + (new Random()).Next().ToString();
        examples.UpdateOrder(order1);
      }
      else
      {
        System.Console.WriteLine("order1 == null. UpdateOrder not called.");
      }
      List<string> orderIdsToRemove = new List<string>();
      if (order1 != null)
        orderIdsToRemove.Add(order1.order_id.ToString());
      if (order2 != null)
          orderIdsToRemove.Add(order2.order_id.ToString());
      examples.RemoveOrders(orderIdsToRemove.ToArray());


      examples.GenericExample();
      examples.GenericExampleShortcut();

      System.Console.WriteLine("");
      System.Console.WriteLine("Press any key");
      System.Console.ReadKey();
    }
  }
}
