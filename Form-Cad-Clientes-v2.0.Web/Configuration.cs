using MudBlazor;
using MudBlazor.Utilities;

namespace Form_Cad_Clientes_v2._0.Web;

public static class Configuration
{
    public const string HttpClient = "Form-Cad-Clientes-v2.0.Web.HttpClient";

    public static string BackendUrl = "http://localhost:5176";
    public static MudTheme Theme = new()
    {
        Typography = new Typography
        {
            Default = new Default
            {
                FontFamily = ["Raleway" , "sans-serif"],
            }
        },
        Palette = new PaletteLight
        {
            Primary = new MudColor("#1EFA2D"),
            PrimaryContrastText = new MudColor("#000000"),
            Secondary = Colors.LightGreen.Darken3,
            Background = Colors.Grey.Lighten4,
            AppbarBackground = new MudColor("#1EFA2D"),
            AppbarText = Colors.Shades.Black,
            TextPrimary = Colors.Shades.Black,
            DrawerText = Colors.Shades.White,
            DrawerBackground = Colors.Green.Darken4
        },
        PaletteDark = new PaletteDark
        {
            Primary = "#b9030f",
            Secondary = Colors.LightGreen.Darken3,
            AppbarBackground = "#b9030f",
            AppbarText = Colors.Shades.Black,
        }
    };
}