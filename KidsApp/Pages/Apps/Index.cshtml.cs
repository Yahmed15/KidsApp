using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace KidsApp.Pages.Apps
{
    public class IndexModel : PageModel
    {
        public List<App> Apps { get; set; } = new List<App>();

        public void OnGet()
        {
            // Simulate loading app data (replace with actual data retrieval logic)
            Apps = new List<App>
            {
                new App
                {
                    Title = "Learning ABCs",
                    Description = "An interactive app to help kids learn the alphabet through fun games and activities.",
                    ImageUrl = "https://m.media-amazon.com/images/S/pv-target-images/7b48c2604595834d046ca4401cf1b1a0fe8affa791487061a861a651570527a0.jpg",
                    DownloadLink = "https://example.com/download/app1"
                },
                new App
                {
                    Title = "Math Adventures",
                    Description = "A fun and engaging app to help kids improve their math skills with exciting challenges.",
                    ImageUrl = "https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2134760/header.jpg?t=1665130683",
                    DownloadLink = "https://example.com/download/app2"
                },
                // Add more apps as needed
            };
        }
    }

    public class App
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string DownloadLink { get; set; }
    }
}
