using MovieBrowser.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MovieBrowser
{
	public partial class App
	{
        public App()
		{
			InitializeComponent();

			SetMainPage();
		}

		public static void SetMainPage()
		{
		    Current.MainPage = new NavigationPage(new MoviesPage());
		}
	}
}
