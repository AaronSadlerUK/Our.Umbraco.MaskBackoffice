﻿using System;
using System.Collections;
using System.Web;
using System.Web.Routing;

public class DomainConstraint : IRouteConstraint
{
    private readonly string[] domains;

    public DomainConstraint(params string[] domains)
    {
        if (domains != null)
            this.domains = domains;
        else
            throw new ArgumentNullException(nameof(domains));
    }

    public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
    {
        string domain =
#if DEBUG
            // A domain specified as a query parameter takes precedence 
            // over the hostname (in debug compile only).
            // This allows for testing without configuring IIS with a 
            // static IP or editing the local hosts file.
            httpContext.Request.QueryString["domain"];
#else
                null;
#endif
        if (string.IsNullOrEmpty(domain))
            domain = httpContext.Request.Headers["HOST"];

        return ((IList) domains).Contains(domain);
    }
}