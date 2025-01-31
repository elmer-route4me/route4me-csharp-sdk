﻿using System.ComponentModel;

namespace Route4MeSDK.DataTypes
{
  
  public enum AlgorithmType
  {
    TSP        = 1, //single depot, single driver route
    VRP        = 2, //single depot, multiple driver, no constraints, no time windows, no capacities
    CVRP_TW_SD = 3, //single depot, multiple driver, capacitated, time windows
    CVRP_TW_MD = 4, //multiple depot, multiple driver, capacitated, time windows
    TSP_TW     = 5, //single depot, single driver, time windows
    TSP_TW_CR  = 6, //single depot, single driver, time windows, continuous optimization (minimal location shifting)
    BBCVRP     = 7, //shifts addresses from one route to another over time on a recurring schedule
    ALG_NONE  =  100,
    ALG_LEGACY_DISTRIBUTED = 101
  }


  public enum TravelMode : uint
    {
        [Description("Driving")]
        Driving,

        [Description("Walking")]
        Walking,

        [Description("Trucking")]
        Trucking,

        [Description("Cycling")]
        Cycling,

        [Description("Transit")]
        Transit
    }

  
  public enum DistanceUnit : uint
  {
    [Description("mi")]
    MI,

    [Description("km")]
    KM
  }
  
  public enum Avoid
  {
    [Description("Highways")]
    Highways,

    [Description("Tolls")]
    Tolls,

    [Description("minimizeHighways")]
    MinimizeHighways,

    [Description("minimizeTolls")]
    MinimizeTolls,

    [Description("")]
    None
  }

 
  public enum Optimize : uint
  {
    [Description("Distance")]
    Distance,
      
    [Description("Time")]
    Time,

    [Description("timeWithTraffic")]
    TimeWithTraffic
  }

  
  public enum Metric : uint
  {
    Euclidean = 1, //measures point to point distance as a straight line
    Manhattan = 2, //measures point to point distance as taxicab geometry line
    Geodesic  = 3, //measures point to point distance approximating curvature of the earth
    Matrix    = 4, //measures point to point distance by traversing the actual road network
    Exact_2D  = 5  //measures point to point distance using 2d rectilinear distance
  }

  public enum DeviceType
  {
    [Description("web")]
    Web,

    [Description("iphone")]
    IPhone,

    [Description("ipad")]
    IPad,

    [Description("android_phone")]
    AndroidPhone,

    [Description("android_tablet")]
    AndroidTablet
  }


  public enum Format
  {
    [Description("csv")]
    Csv,

    [Description("serialized")]
    Serialized,

    [Description("xml")]
    Xml,

    [Description("json")]
    Json
  }


  //an optimization problem can be at one state at any given time
  //every state change invokes a socket notification to the associated member id
  //every state change invokes a callback webhook event invocation if it was provided during the initial optimization
  public enum OptimizationState : uint
  {
    Initial             = 1,
    MatrixProcessing    = 2,
    Optimizing          = 3,
    Optimized           = 4,
    Error               = 5,
    ComputingDirections = 6
  }
  
  //if the actual polylines of the driving path between all the stops on the route should be returned
  public enum RoutePathOutput : uint
  {
    [Description("None")]
    None,

    [Description("Points")]
    Points
  }

  public enum StatusUpdateType
  {
    [Description("pickup")]
    Pickup,

    [Description("dropoff")]
    DropOff,

    [Description("noanswer")]
    NoAnswer,

    [Description("notfound")]
    NotFound,

    [Description("notpaid")]
    NotPaid,

    [Description("paid")]
    Paid,

    [Description("wrongdelivery")]
    WrongDelivery,

    [Description("wrongaddressrecipient")]
    WrongAddressRecipient,

    [Description("notpresent")]
    NotPresent,

    [Description("parts_missing")]
    PartsMissing,

    [Description("service_rendered")]
    ServiceRendered,

    [Description("follow_up")]
    FollowUp,

    [Description("left_information")]
    LeftInformation,

    [Description("spoke_with_decision_maker")]
    SpokeWithDecisionMaker,

    [Description("spoke_with_decision_influencer")]
    SpokeWithDecisionInfluencer,

    [Description("competitive_account")]
    CompetitiveAccount,

    [Description("scheduled_follow_up_meeting")]
    ScheduledFollowUpMeeting,

    [Description("scheduled_lunch")]
    ScheduledLunch,

    [Description("scheduled_product_demo")]
    ScheduledProductDemo,

    [Description("scheduled_clinical_demo")]
    ScheduledClinicalDemo,

    [Description("no_opportunity")]
    NoOpportunity
  }

  /// <summary>
  /// Territory type (circle, rectangle, polygon)
  /// </summary>
  public enum TerritoryType : uint
  {
    [Description("circle")]
    Circle,

    [Description("poly")]
    Poly,

    [Description("rect")]
    Rect
  }
}
