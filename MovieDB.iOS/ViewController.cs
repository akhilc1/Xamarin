using Foundation;
using System;
using UIKit;
using MovieDBSharedProject;
using System.Threading.Tasks;

namespace MovieDB.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			MovieDBRestClient restClient = new MovieDBRestClient();
			Task<PopularMovieModel> model = restClient.GetPopularMovies(1);
		}
    }
}