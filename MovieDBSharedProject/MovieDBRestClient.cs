using System;
using System.Net;
using System.Text;
using System.IO;
//using Android.Util;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using MovieDB.Android;

namespace MovieDBSharedProject
{
    class MovieDBRestClient
    {
        public const String API_KEY_V4_READ_TOKEN = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyZDdhMTczNzlkNzdiNDI0NTYyMzZkYzUyZTI1NjUxZSIsInN1YiI6IjU3ZDExNTY2YzNhMzY4NDhjMDAwNGNlYiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.S0tHOwc84yP36Y3cnQ_xaMTd313XIq7PdpiUhjWFpxs";
        public const String API_KEY_V3 = "2d7a17379d77b42456236dc52e25651e";

        public const String BASE_URL = "https://api.themoviedb.org/3/";
        public const String ENDPOINT_POPULAR = "movie/popular?";

        public MovieDBRestClient()
        {
        }

        public async Task<PopularMovieModel> GetPopularMovies(int PageNumber)
        {
            //Log.Debug("Tag", "Start");
            PopularMovieModel movieModel = null;
            StringBuilder url = new StringBuilder();
            url.Append(BASE_URL);
            url.Append(ENDPOINT_POPULAR);
            url.Append("api_key=" + API_KEY_V3);
            url.Append("&language=en-US");
            //Log.Debug("Tag", "2222222");

            url.Append("&page=" + PageNumber);
            //Log.Debug("URL: ", url.ToString());
            HttpWebRequest HttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(new Uri(url.ToString()));
            HttpWebRequest.ContentType = "application/json";
            HttpWebRequest.Method = "GET";

            try
            {
                //Log.Debug("Tag", "3333333");

                using (WebResponse WebResponse = await HttpWebRequest.GetResponseAsync())
                {
                    //Log.Debug("Tag", "44444444");

                    using (Stream Stream = WebResponse.GetResponseStream())
                    {
                        //Log.Debug("Tag", "5555555");

                        StreamReader reader = new StreamReader(Stream);
                        string response = reader.ReadToEnd();
                        movieModel = new PopularMovieModel();
                        //JObject jsonResponse = JObject.Parse(response);
                        movieModel = JsonConvert.DeserializeObject<PopularMovieModel>(response);
                        //Log.Debug("Tag", "666666");
                        Console.WriteLine(movieModel.ToString());
                    }
                }

            }
            catch (Exception Exception)
            {
                var exception = Exception;
                //Log.Debug("Log", exception.Message.ToString());
            }
            return movieModel;
        }
        public String GetAccessToken()
        {
            return null;
        }
    }

	class AddedByAnand
	{
	}
}