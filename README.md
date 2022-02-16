# Getting started

This package will allow you to mask the umbraco backoffice behind a subdomain.

### Installation

Our.Umbraco.MaskBackoffice is available from [Our Umbraco](https://our.umbraco.com/packages/backoffice-extensions/ourumbracomaskbackoffice/), [NuGet](https://www.nuget.org/packages/Our.Umbraco.MaskBackoffice), or as a manual download directly from GitHub.

#### NuGet package repository
To [install from NuGet](https://www.nuget.org/packages/Our.Umbraco.MaskBackoffice), run the following command in your instance of Visual Studio.

    PM> Install-Package Our.Umbraco.MaskBackoffice

# Usage (V2 - Umbraco V9)

You will need to add the following keys to your appsettings.json:

      "OurUmbracoMaskBackoffice": {
        "Enabled": boolean,
        "ViewName": string,
        "UseRedirect": boolean,
        "RedirectUrl": string,
        "Domains": [
          string
        ]
      }

# Configuration

## Enabled
This configuration setting will enable / disable the route override.

## ViewName
This configuration setting sets the view to be shown when returning a not found result, this defaults to "MaskBackofficeNotFound.cshtml"

## UseRedirect
This configuration setting will enable use of a redirect url instead of returning a not found error.

## RedirectUrl
This configuration setting sets the redirect target, it can be a absolute or relative url.

## Domains
This configuration is the domains / subdomains you would like to allow access to the backoffice.


# Usage (V1 - Umbraco V8)

You will need to add the following keys to your Web.Config:

    <add key="Our.MaskBackoffice.Redirect" value=""/>
    <add key="Our.MaskBackoffice.Enabled" value=""/>
    <add key="Our.MaskBackoffice.Domain" value=""/>

# Configuration

## Our.MaskBackoffice.Redirect
This configuration setting allows you to set the destination the user will end up if trying to access the backoffice on a non allowed subdomain.

## Our.MaskBackoffice.Enabled
This configuration setting will enable / disable the route override.

## Our.MaskBackoffice.Domain
This configuration is the subdomain(s) you would like to use to access the backoffice.
Seperate multiple subdomains with a comma.


# Contribution guidelines

To raise a new bug, create an issue on the GitHub repository. To fix a bug or add new features, fork the repository and send a pull request with your changes. Feel free to add ideas to the repository's issues list if you would to discuss anything related to the package.

# Who do I talk to?
This project is maintained by [Aaron Sadler](https://aaronsadler.uk) and contributors. If you have any questions about the project please contact me through [Twitter](https://twitter.com/AaronSadlerUK), or by raising an issue on GitHub.

# License

Copyright &copy; 2020 [Aaron Sadler](https://aaronsadler.uk), and other contributors

Licensed under the MIT License.
