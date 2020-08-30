using Our.Umbraco.MaskBackoffice.Components;
using Our.Umbraco.MaskBackoffice.Controllers;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.MaskBackoffice.Composers
{
    public class RegisterMaskBackofficeRouteComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<MaskBackofficeRouteController>(Lifetime.Request);
            composition.Components().Append<RegisterMaskBackofficeRouteComponent>();
        }
    }
}
