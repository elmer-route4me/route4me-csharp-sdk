﻿using Route4MeSDK.DataTypes;
using System.Runtime.Serialization;

namespace Route4MeSDK.QueryTypes
{

  [DataContract]
  public sealed class OptimizationParameters : GenericParameters
  {
    [IgnoreDataMember] // Don't serialize as JSON
    [HttpQueryMemberAttribute(Name = "optimization_problem_id", EmitDefaultValue = false)]
    public string OptimizationProblemID { get; set; }

    [IgnoreDataMember] // Don't serialize as JSON
    [HttpQueryMemberAttribute(Name = "reoptimize", EmitDefaultValue = false)]
    public bool? ReOptimize { get; set; }

    /// <summary>
    /// If true will be redirected
    /// </summary>
    [IgnoreDataMember()]
    [HttpQueryMemberAttribute(Name = "redirect", EmitDefaultValue = false)]
    public System.Nullable<bool> Redirect
    {
        get { return m_Redirect; }
        set { m_Redirect = value; }
    }
    private System.Nullable<bool> m_Redirect;

    [IgnoreDataMember] // Don't serialize as JSON
    [HttpQueryMemberAttribute(Name = "show_directions", EmitDefaultValue = false)]
    public bool? ShowDirections { get; set; }

    [IgnoreDataMember] // Don't serialize as JSON
    [HttpQueryMemberAttribute(Name = "optimized_callback_url", EmitDefaultValue = false)]
    public string OptimizedCallbackURL { get; set; }

    /// <summary>
    /// The number of existing routes that should be returned per response when looking at a list of all the routes.
    /// </summary>
    [IgnoreDataMember]
    [HttpQueryMemberAttribute(Name = "limit", EmitDefaultValue = false)]
    public uint? Limit { get; set; }

    /// <summary>
    /// The page number for route listing pagination. Increment the offset by the limit number to move to the next page.
    /// </summary>
    [IgnoreDataMember]
    [HttpQueryMemberAttribute(Name = "offset", EmitDefaultValue = false)]
    public uint? Offset { get; set; }

        [DataMember(Name = "parameters", EmitDefaultValue = false)]
    public RouteParameters Parameters { get; set; }
    
    [DataMember(Name = "addresses", EmitDefaultValue = false)]
    public Address[] Addresses { get; set; }
  }
}
