using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using PetsSearchApplication.Constants;

namespace PetsSearchApi
{
  public class PetsRouteConstraint : IRouteConstraint
  {
    public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
      var candidate = values[routeKey]?.ToString();
      return Enum.TryParse(candidate, ignoreCase: true, out PetTypeEnum result);      
    }
  }
}