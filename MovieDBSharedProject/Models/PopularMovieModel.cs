using System.Collections.Generic;

namespace MovieDBSharedProject
{
    class PopularMovieModel
    {
        public int page { get; set; }
        //public ResultModel resultModel { get; set; }
        public List<MovieModel> results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    }
}