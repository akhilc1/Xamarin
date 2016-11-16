using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using Java.Lang;

namespace MovieDB.Android
{
    class MovieListAdapter : BaseAdapter<MovieModel>
    {

        public List<MovieModel> MovieList { get; set; }
        private Activity Activity;
        public MovieListAdapter(Activity Activity, List<MovieModel> MovieList)
        {
            //MovieList = new List<MovieModel>();
            this.MovieList = MovieList;
            this.Activity = Activity;
        }

        public void AppendMovieList(List<MovieModel> liems)
        {
            MovieList.AddRange(liems);
            NotifyDataSetChanged();
        }
        public override MovieModel this[int position]
        {
            get
            {
                if (MovieList == null)
                {
                    return null;
                }
                else
                {
                    return MovieList[position];
                }
            }
        }

        public override int Count
        {
            get
            {
                if (MovieList == null)
                {
                    return 0;
                }
                else
                {
                    return MovieList.Count;
                }
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ViewHolder Holder;
            Log.Debug("GetView", "GetView");
            if (convertView == null)
            {
                convertView = Activity.LayoutInflater.Inflate(Resource.Layout.MovieCell, null);
                Holder = new ViewHolder();
                Holder.MovieNameTV = convertView.FindViewById<TextView>(Resource.Id.MovieName);
                convertView.Tag = Holder;
            }
            else
            {
                Holder = (ViewHolder)convertView.Tag;
            }
            Holder.MovieNameTV.Text = MovieList[position].MovieTitle;
            return convertView;
        }
        private class ViewHolder : Object
        {
            public TextView MovieNameTV;
        }
    }

}