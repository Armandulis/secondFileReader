using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileReader
{
    class methods
    {
        

        public void ReadJson()
        {
            List<MovieReviews> reviews;

            using (StreamReader r = new StreamReader("C://Users//Arman//source//repos//JsonReaderAndMovieReviews/ratings.json"))
            {
                string json = r.ReadToEnd();
                 reviews = JsonConvert.DeserializeObject<List<MovieReviews>>(json);
            }

            foreach (MovieReviews movieReviews in reviews)
            {
                Console.WriteLine("MoviesID:" + movieReviews.Movie);
            }
        }

        public void PrintData() {

            
        }
    }
}
