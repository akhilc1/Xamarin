using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;


namespace MovieDB.Android
{
    [Activity(Label = "MovieDB.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private FrameLayout FrameLayoutInstance;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            MovieListFragment ListFragment = new MovieListFragment();
            Log.Debug("Tag", "OnCreate");
            FrameLayoutInstance = FindViewById<FrameLayout>(Resource.Id.Container);
            FragmentManager manager = this.FragmentManager;
            var FragmentTransaction = manager.BeginTransaction();
            FragmentTransaction.Replace(Resource.Id.Container, ListFragment);
            FragmentTransaction.Commit();
        }
    }
}

