namespace Our.Umbraco.MaskBackofficeV9.Configurations;

public class OurUmbracoMaskBackoffice
{
    public bool Enabled { get; set; } = false;
    public string ViewName { get; set; } = "MaskBackofficeNotFound.cshtml";
    public bool UseRedirect { get; set; } = false;
    public string RedirectUrl { get; set; }
    public string[] Domains { get; set; }
}