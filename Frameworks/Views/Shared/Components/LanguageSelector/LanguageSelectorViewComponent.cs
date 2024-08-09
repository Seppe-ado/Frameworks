using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace MovieSharing.Views.Shared.Components.LanguageSelector
{
    public class LanguageSelectorViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var supportedCultures = new[]
            {
            new CultureInfo("en-US"),
            new CultureInfo("nl-BE"),
            new CultureInfo("fr-FR")
            // Add more cultures as needed
        };

            var currentCulture = CultureInfo.CurrentCulture;

            var viewModel = new LanguageSelectorViewModel
            {
                SupportedCultures = supportedCultures,
                CurrentCulture = currentCulture
            };

            return View(viewModel);
        }
    }
}
