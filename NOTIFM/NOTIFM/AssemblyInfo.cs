using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]


#region EmbeddedFont UrbanistFont
[assembly: ExportFont("Urbanist-Regular.ttf", Alias ="UrbanistFont")]
[assembly: ExportFont("Urbanist-Medium.ttf", Alias = "UrbanistFontMedium")]
[assembly: ExportFont("Urbanist-Bold.ttf", Alias = "UrbanistFontBold")]
#endregion