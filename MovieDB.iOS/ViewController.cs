using Foundation;
using System;
using UIKit;
using MovieDBSharedProject;
using System.Threading.Tasks;

namespace MovieDB.iOS
{
	public partial class ViewController : UIViewController
	{
		Task<PopularMovieModel> modelData;
		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

		}

		public void callMovieApi()
		{
			MovieDBRestClient restClient = new MovieDBRestClient();
			modelData = restClient.GetPopularMovies(1);
		}
	}
}