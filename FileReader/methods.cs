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
        List<MovieReviews> reviews;


        public void ReadJson()
        {
            
            var sw = new Stopwatch();
            sw.Start();
            using (StreamReader r = new StreamReader("C://Users//Arman//source//repos//JsonReaderAndMovieReviews/ratings.json"))
            {
                string json = r.ReadToEnd();
                 reviews = JsonConvert.DeserializeObject<List<MovieReviews>>(json);
            }
            sw.Stop();
            Console.WriteLine("time for it to read the file: " + sw.Elapsed);

            ListOfMoviesFromReviever();
        }
        // 1. On input N, what are the number of reviews from reviewer N?
        public void AmountOfReviews() {

            int counter = 0;

            foreach (MovieReviews movieReviews in reviews)
            {
                if (movieReviews.Reviewer == 1)
                {
                    counter++;
                }
            }

            Console.WriteLine("Number of reviews reviewer has given:" + counter);
            Console.Read();

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
            Console.Read();

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

        // 10. On input N, what are the movies that reviewer N has reviewed?
        //The list should be sorted decreasing by rate first, and date secondly.
        public void ListOfMoviesFromReviever()
        {
            List<MovieReviews> pictedList = new List<MovieReviews>();

            foreach (MovieReviews movieReviews in reviews)
            {
                if (movieReviews.Reviewer==1)
                {
                    pictedList.Add(movieReviews);
                }
            }

            List<MovieReviews> sortedList = pictedList.OrderBy(m => m.Date).OrderBy(m => m.Grade).ToList();

            foreach (MovieReviews movieReview in sortedList)
            {
                Console.WriteLine("Grade: " + movieReview.Grade + " Date: " + movieReview.Date);
            }
            Console.ReadLine();
        }


        private static void Quick_Sort(int[] arr, int left, int right)
            {
                if (left < right)
                {
                    int pivot = Partition(arr, left, right);

                    if (pivot > 1)
                    {
                        Quick_Sort(arr, left, pivot - 1);
                    }
                    if (pivot + 1 < right)
                    {
                        Quick_Sort(arr, pivot + 1, right);
                    }
                }

            }

            private static int Partition(int[] arr, int left, int right)
            {
                int pivot = arr[left];
                while (true)
                {

                    while (arr[left] < pivot)
                    {
                        left++;
                    }

                    while (arr[right] > pivot)
                    {
                        right--;
                    }

                    if (left < right)
                    {
                        if (arr[left] == arr[right]) return right;

                        int temp = arr[left];
                        arr[left] = arr[right];
                        arr[right] = temp;


                    }
                    else
                    {
                        return right;
                    }
                }
            }
            public void asd()
            {
                int[] arr = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };

                Console.WriteLine("Original array : ");
                foreach (var item in arr)
                {
                    Console.Write(" " + item);
                }
                Console.WriteLine();

                Quick_Sort(arr, 0, arr.Length - 1);

                Console.WriteLine();
                Console.WriteLine("Sorted array : ");

                foreach (var item in arr)
                {
                    Console.Write(" " + item);
                }
                Console.WriteLine();
            }
        }
    }
