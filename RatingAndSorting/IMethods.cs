using Entities.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatingAndSorting
{
    public interface IMethods
    {
        // 1. On input N, what are the number of reviews from reviewer N?
        int AmountOfReviews();
        //2. On input N, what is the average rate that reviewer N had given?
        double AvarageRateReviewer();
        // 3. On input N and G, how many times has reviewer N given a movie grade G?
         int AmountOfTimesReviewerRadedG();
        //4. On input N, how many have reviewed movie N? 
         int AmountOfReviewsForMovie();
        //5. On input N, what is the average rate the movie N had received?
         double AvarageMovieGrade();
        //6. On input N and G, how many times had movie N received grade G?         int AmountOfMovieRecievedGrade();
        //7. What is the id(s) of the movie(s) with the highest number of top rates (5)?
        MovieReviews Top5Movies();
        //8. What reviewer(s) had done most reviews?
        MovieReviews TopReviewers();
        //9. On input N, what is top N of movies? The score of a movie is its average rate.
         void TopMovies();
        // 10. On input N, what are the movies that reviewer N has reviewed?
        //The list should be sorted decreasing by rate first, and date secondly.
        IOrderedEnumerable<MovieReviews> ListOfMoviesFromReviever();
        //11. On input N, what are the reviewers that have reviewed movie N? 
        //The list should be sorted decreasing by rate first, and date secondly
         IOrderedEnumerable<MovieReviews> ReviewersOfMovie();
    }
}
