﻿using Entities.Json;
using Infrastructure.Data;
using RatingAndSorting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FileReader
{
    class Printer
    {
        readonly IMethods methods;

        public Printer() {

            var sw = new Stopwatch();

            Console.WriteLine("Reading file...");
            sw.Start();

            var jr = new JRatingsReader();

            methods = new Methods(jr.ReadJson());

            sw.Stop();

            Console.WriteLine("time for program to read the file: " + sw.Elapsed);
            Console.ReadLine();

            Functions();
        }

        public void Functions()
        {

            //1
            Console.WriteLine("Number of reviews reviewer has given: " + methods.AmountOfReviews());
            Console.ReadLine();
            //2
            Console.WriteLine("Avarge reviewer's rate:" + methods.AvarageRateReviewer());
            Console.ReadLine();
            //3
            Console.WriteLine("The amount of times reviewer rated rated G" + methods.AmountOfTimesReviewerRadedG());
            Console.ReadLine();
            //4
            Console.WriteLine("Number of reviews movie was given:" + methods.AmountOfReviewsForMovie());
            Console.Read();
            //5
            Console.WriteLine("Avarge Movie's rate:" + methods.AvarageMovieGrade());
            Console.ReadLine();
            //6
            Console.WriteLine("The amount of times movie have recieved grade G" + methods.AmountOfMovieRecievedGrade());
            Console.ReadLine();
            //7
            var topMovie = methods.Top5Movies();
            Console.WriteLine(" Best movie that scored most 5: " + topMovie.Movie);
            Console.ReadLine();
            //8
            var reviewer = methods.TopReviewers();
            Console.WriteLine("reviewer(s) had done most reviews: " + reviewer.Reviewer);
            Console.ReadLine();
            //9

            //10
            var sortedList = methods.ListOfMoviesFromReviever();
            Console.WriteLine("Reviewer have reviewed these movies: ");
            foreach (MovieReviews movieReview in sortedList)
            {
                
                Console.WriteLine("Movie: "+ movieReview.Movie +" Grade: " + movieReview.Grade + " Date: " + movieReview.Date);
            }
            Console.ReadLine();
            //11
            sortedList = methods.ReviewersOfMovie();
            Console.WriteLine("Reviewers that have reviewed this movie: ");
            foreach (MovieReviews movieReviewer in sortedList)
            {
                Console.WriteLine("Reviewer: "+ movieReviewer.Reviewer +" Grade: " + movieReviewer.Grade + " Date: " + movieReviewer.Date);

            }
            Console.ReadLine();





        }

       

    }
}
