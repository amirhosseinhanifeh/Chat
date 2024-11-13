using Microsoft.AspNetCore.Components.WebView.Maui;

namespace ChatApp;

public partial class ExplorePage : ContentPage
{
    public ExplorePage()
    {
        InitializeComponent();
        // تنظیم RootComponent در کد C#
        blazorWebView.RootComponents.Add(new RootComponent
        {
            Selector = "#app",
            ComponentType = typeof(ChatApp.Components.Pages.Home)
        });
    }
}