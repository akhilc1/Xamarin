using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
using Newtonsoft.Json;

namespace MovieDBSharedProject
{
    class MovieModel
    {
       
            public string poster_path { get; set; }
            public bool adult;
            public bool Adult
            {
                get
                {
                    return adult;
                }
                set
                {
                    adult = value;
                }
            }

            public void MethodSample()
            {
                Adult = true;
            }
            public string overview { get; set; }
            public string release_date { get; set; }
            public List<int> genre_ids { get; set; }
            public int id { get; set; }
            [JsonProperty("original_title")]
            public string MovieTitle { get; set; }
            public string original_language { get; set; }
            public string title { get; set; }
            public string backdrop_path { get; set; }
            public double popularity { get; set; }
            public int vote_count { get; set; }
            public bool video { get; set; }
            public double vote_average { get; set; }
        }
    
}