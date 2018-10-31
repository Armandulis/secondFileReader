using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace FileReader
{
    public class Methods
    {
        IEnumerable<MovieReviews> reviews;


        public void ReadJson()
        {

            var sw = new Stopwatch();
            Console.WriteLine("Reading file...");
            sw.Start();
            using (StreamReader r = new StreamReader("C://Users//Arman//source//repos//JsonReaderAndMovieReviews/ratings.json"))
            {
                string json = r.ReadToEnd();
                reviews = JsonConvert.DeserializeObject<IEnumerable<MovieReviews>>(json);
            }
            sw.Stop();
            Console.WriteLine("time for it to read the file: " + sw.Elapsed);
            Console.ReadLine();

            Top5Movies();




        }
        // 1. On input N, what are the number of reviews from reviewer N?
        public void AmountOfReviews()
        {

            int counter = 0;

            foreach (MovieReviews movieReviews in reviews)
            {
                if (movieReviews.Reviewer == 571)
                {
                    counter++;
                }
            }

            Console.WriteLine("Number of reviews reviewer has given:" + counter);
            Console.ReadLine();

        }

        //2. On input N, what is the average rate that reviewer N had given?
        public void AvarageRateReviewer()
        {
            int counter = 0;
            int avarageRating = 0;

            foreach (MovieReviews movieReviews in reviews)
            {
                if (movieReviews.Reviewer == 1)
                {
                    avarageRating = avarageRating + movieReviews.Grade;
                    counter++;
                }
            }
            var total = avarageRating / counter;

            Console.WriteLine("Avarge reviewer's rate:" + total);
            Console.ReadLine();

        }
        // 3. On input N and G, how many times has reviewer N given a movie grade G?
        public void AmountOfTimesReviewerRadedG()
        {
            int counter = 0;

            foreach (MovieReviews movieReviews in reviews)
            {
                if (movieReviews.Reviewer == 4 && movieReviews.Grade == 4)
                {
                    counter++;
                }
            }
            Console.WriteLine("The amount of times reviewer rated rated G" + counter);
            Console.ReadLine();


        }

        //4. On input N, how many have reviewed movie N? 
        public void AmountOfReviewsForMovie()
        {
            int counter = 0;

            foreach (MovieReviews movieReviews in reviews)
            {
                if (movieReviews.Movie == 781196)
                {
                    counter++;
                }
            }
            Console.WriteLine("Number of reviews movie was given:" + counter);
            Console.Read();
        }

        //5. On input N, what is the average rate the movie N had received?
        public void AvarageMovieGrade()
        {
            int counter = 0;
            int avarageRating = 0;

            foreach (MovieReviews movieReviews in reviews)
            {
                if (movieReviews.Movie == 781196)
                {
                    avarageRating = avarageRating + movieReviews.Grade;
                    counter++;
                }
            }
            var total = avarageRating / counter;

            Console.WriteLine("Avarge Movie's rate:" + total);
            Console.ReadLine();

        }

        //6. On input N and G, how many times had movie N received grade G?
        public void AmountOfMovieRecievedGrade()
        {
            int counter = 0;

            foreach (MovieReviews movieReviews in reviews)
            {
                if (movieReviews.Movie == 781196 && movieReviews.Grade == 4)
                {
                    counter++;
                }
            }
            Console.WriteLine("The amount of times movie have recieved grade G" + counter);
            Console.ReadLine();
        }

        //7. What is the id(s) of the movie(s) with the highest number of top rates (5)?
        public void Top5Movies()
        {

            List < MovieReviews > listOfMovies5 = new List<MovieReviews>();
            foreach (var item in reviews)
            {
                if ( item.Grade == 5) { listOfMovies5.Add(item); }
            }


            var rew = listOfMovies5.GroupBy(i => i.Movie);
            MovieReviews currentMost = null;
            MovieReviews tempRev =null;
            int mosedSummedGroup =0;
            foreach (var group in rew)
            {
                var currentGroupSum = 0;

                foreach (var item in group)
                {
                    currentGroupSum++;
                    tempRev = item;
                }

                if (currentGroupSum > mosedSummedGroup)
                {
                    currentMost = tempRev;
                }
            }

            Console.WriteLine("Reviewer: " + currentMost.Reviewer + " Grade: " + currentMost.Grade + " Date: " + currentMost.Date + " Movie: " + currentMost.Movie);
            Console.ReadLine();
           

        }

        //8. What reviewer(s) had done most reviews?
        public void TopReviewers()
        {
            var rew = reviews.GroupBy(i => i.Reviewer).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();

            var objRew = reviews.FirstOrDefault(r => r.Reviewer == rew);

            Console.WriteLine("reviewer(s) had done most reviews: " + objRew.Reviewer);
            Console.ReadLine();
            ListOfMoviesFromReviever(objRew.Reviewer);

        }

        //9. On input N, what is top N of movies? The score of a movie is its average rate.
        public void TopMovies()
        {
            var movieIDs = reviews.GroupBy(i => i.Movie);

            MovieReviews topMovie = null;
            MovieReviews tempTop = null;
            double topAvrg = 0;

            foreach (var group in movieIDs)
            {
                int counter = 0;
                int total = 0;
                double averageTmp = 0;
                foreach (var item in group)
                {
                    total = total + item.Grade;
                    counter++;
                    tempTop = item;
                }
                averageTmp = total / counter;

                if (averageTmp > topAvrg)
                {
                    topAvrg = averageTmp;
                    topMovie = tempTop;
                }
            }



            


            Console.WriteLine("reviewer(s) had done most reviews: ");
            Console.ReadLine();

        }

        // 10. On input N, what are the movies that reviewer N has reviewed?
        //The list should be sorted decreasing by rate first, and date secondly.
        public void ListOfMoviesFromReviever(int reviewerN)
        {
            var counter = 0;
            List<MovieReviews> pictedList = new List<MovieReviews>();
            var sw = new Stopwatch();
            sw.Start();
            foreach (MovieReviews movieReviews in reviews)
            {
                if (movieReviews.Reviewer == reviewerN)
                {
                    counter++;
                    pictedList.Add(movieReviews);
                }
            }

            List<MovieReviews> sortedList = pictedList.OrderBy(m => m.Date).OrderBy(m => m.Grade).ToList();

            foreach (MovieReviews movieReview in sortedList)
            {
                Console.WriteLine("Reviewer: " + movieReview.Reviewer +" Grade: " + movieReview.Grade + " Date: " + movieReview.Date);
            }
            sw.Stop();
            Console.WriteLine("Total reviews done by reviewer: " + counter + " timer: " + sw.Elapsed);
            Console.WriteLine();
            Console.ReadLine();
        }

        //11. On input N, what are the reviewers that have reviewed movie N? The list should be sorted decreasing by rate first, and date secondly
        public void ReviewersOfMovie()
        {
            List<MovieReviews> wowList = new List<MovieReviews>();

            foreach (MovieReviews movieReviewer in reviews)
            {
                if (movieReviewer.Movie == 781196)
                {

                    wowList.Add(movieReviewer);

                }
            }
            List<MovieReviews> sortedList = wowList.OrderBy(m => m.Date).OrderBy(m => m.Grade).ToList();
            foreach (MovieReviews movieReviewer in sortedList)
            {
                Console.WriteLine("Grade: " + movieReviewer.Grade + " Date: " + movieReviewer.Date );

            }
            Console.ReadLine();

        }

    }

}
