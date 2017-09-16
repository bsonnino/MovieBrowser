
using System;
using Xamarin.Forms;

namespace MovieBrowser.Views
{
	public partial class AboutPage : ContentPage
	{
		public AboutPage()
		{
			InitializeComponent();
		    var tapGestureRecognizer = new TapGestureRecognizer();
		    tapGestureRecognizer.Tapped += (s, e) => {
		        Device.OpenUri(new Uri(((Label)s).Text));
		    };
		    UrlLabel.GestureRecognizers.Add(tapGestureRecognizer);
        }
	}
}
