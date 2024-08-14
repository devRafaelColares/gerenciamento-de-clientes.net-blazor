using MudBlazor;

namespace Form_Cad_Clientes_v2._0.Web;

public static class Configuration
{
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
            Primary = Colors.LightGreen.Accent3,
            Secondary = Colors.LightGreen.Darken3,
            Background = Colors.Grey.Lighten4,
            AppbarText = Colors.Shades.Black,
            AppbarBackground = Colors.LightGreen.Accent3,
            TextPrimary = Colors.Shades.Black,
            PrimaryContrastText = Colors.Shades.Black,
            DrawerText = Colors.Shades.Black,
            DrawerBackground = Colors.LightGreen.Lighten4,
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