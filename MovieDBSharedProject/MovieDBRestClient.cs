using System;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieDBSharedProject
{
    class MovieDBRestClient
    {
        public const string API_KEY_V4_READ_TOKEN = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyZDdhMTczNzlkNzdiNDI0NTYyMzZkYzUyZTI1NjUxZSIsInN1YiI6IjU3ZDExNTY2YzNhMzY4NDhjMDAwNGNlYiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.S0tHOwc84yP36Y3cnQ_xaMTd313XIq7PdpiUhjWFpxs";
        public const string API_KEY_V3 = "2d7a17379d77b42456236dc52e25651e";
        public const string BASE_URL = "https://api.themoviedb.org/3/";
        public const string ENDPOINT_POPULAR = "movie/popular?";

        public async Task<PopularMovieModel> GetPopularMovies(int PageNumber)
        {
            //Log.Debug("Tag", "Start");
            PopularMovieModel movieModel = null;
            
			StringBuilder url = new StringBuilder();
            url.Append(BASE_URL);
            url.Append(ENDPOINT_POPULAR);
            url.Append("api_key=" + API_KEY_V3);
            url.Append("&language=en-US");
            url.Append("&page=" + PageNumber);

			HttpWebRequest webRequest = new HttpWebRequest(new Uri(url.ToString()));
			webRequest.ContentType = "application/json";
			webRequest.Method = "GET";

            try
			{
				using (WebResponse WebResponse = await webRequest.GetResponseAsync())
				{
					using (Stream Stream = WebResponse.GetResponseStream())
					{
						StreamReader reader = new StreamReader(Stream);
						string response = reader.ReadToEnd();
						movieModel = new PopularMovieModel();
						movieModel = JsonConvert.DeserializeObject<PopularMovieModel>(response);
						Console.WriteLine(movieModel);
					}
				}
            }
			catch (Exception Exception)
			{
				Console.WriteLine("Log {0}", Exception.Message.ToString());
			}
			return movieModel;
        }
        public string GetAccessToken()
        {
            return null;
        }
    }
}