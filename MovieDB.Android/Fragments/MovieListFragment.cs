using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using MovieDBSharedProject;

namespace MovieDB.Android
{
    public class MovieListFragment : Fragment, ListView.IOnScrollListener
    {
       
        private MovieDBRestClient MovieRestClient;
        private PopularMovieModel PopularMovieModel;
        private MovieListAdapter MovieListAdapter;
        private ListView MovieListView;
        private int PageNumber = 1;
        private int PaginationCallCount = 1;
        private bool CanPaginate;
        public MovieListFragment()
        {
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Log.Debug("Tag", "OnCreateView");
            return inflater.Inflate(Resource.Layout.FragmentList, container, false);
        }
        public override async void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            MovieRestClient = new MovieDBRestClient();
            PopularMovieModel = new PopularMovieModel();
            Log.Debug("Tag", "OnViewCreated");

            try
            {
                MovieListAdapter = new MovieListAdapter(this.Activity, PopularMovieModel.results);
                InitalizeViews(view);
                MovieListView.Adapter = MovieListAdapter;
                PopularMovieModel MovieModel = await CallPaginationApi();
                PaginationCallCount = MovieModel.total_pages;
                CanPaginate = true;
                MovieListAdapter.MovieList = MovieModel.results;
                MovieListAdapter.NotifyDataSetChanged();
            }
            catch (Exception e)
            {
                Log.Debug("Excptn", "Exceptn");
            }
        }

        private async Task<PopularMovieModel> CallPaginationApi()
        {
            Log.Debug("Tag", "Frag MethodCall");
            return await MovieRestClient.GetPopularMovies(PageNumber);
        }

        private void InitalizeViews(View FragmentView)
        {
            MovieListView = FragmentView.FindViewById<ListView>(Resource.Id.MovieListView);
            MovieListView.SetOnScrollListener(this);
        }

        public async void OnScroll(AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount)
        {
            if ((firstVisibleItem + visibleItemCount == totalItemCount) && CanPaginate && (PaginationCallCount >= PageNumber))
            {
                CanPaginate = false;
                PageNumber++;
                PopularMovieModel response = await CallPaginationApi();

                MovieListAdapter.AppendMovieList(response.results);
                CanPaginate = true;
                Log.Debug("Pagination", " COnditionMet " + CanPaginate
                    + firstVisibleItem + " " + visibleItemCount + " " + totalItemCount);
            }
            //Log.Debug("Scroll ", firstVisibleItem + " " + visibleItemCount + " " + totalItemCount);  
        }

        public void OnScrollStateChanged(AbsListView view, [GeneratedEnum] ScrollState scrollState)
        {
            Log.Debug("Scroll ", "Scrool state change");
        }
    }
}