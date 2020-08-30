# Getting started

This package will allow you to mask the umbraco backoffice behind a subdomain.

### Installation

Our.Umbraco.MaskBackoffice is available from [Our Umbraco](https://our.umbraco.com/packages/backoffice-extensions/ourumbracomaskbackoffice/), [NuGet](https://www.nuget.org/packages/Our.Umbraco.MaskBackoffice), or as a manual download directly from GitHub.

#### NuGet package repository
To [install UI from NuGet](https://www.nuget.org/packages/Our.Umbraco.MaskBackoffice), run the following command in your instance of Visual Studio.

    PM> Install-Package Our.Umbraco.MaskBackoffice

# Usage

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
