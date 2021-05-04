using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class ManageMoviesUsingDictionary : IMov<movie>
    {
        public Dictionary<int, movie> movies;
        public ManageMoviesUsingDictionary()
        {
            movies = new Dictionary<int, movie>();
        }
        public int GenerateId()
        {
            if (movies.Count == 0)
                return 1;
            List<int> ids = movies.Keys.ToList();
            ids.Sort();
            int id = ids[ids.Count - 1];
            id++;
            return id;

        }
        public movie CreateMovie()
        {
            movie movie = new movie();
            movie.Id = GenerateId();
            movie.TakeMovieDetails();
            return movie;
        }
        public int GetMovieIndexById(int id)
        {
            return movies.Keys.ToList().IndexOf(id);
        }
        public movie UpdateMovieName(int id, string name)
        {
            movie movie = null;
            int idx = GetMovieIndexById(id);
            if (idx != -1)
            {
                movies[idx].Name = name;
                movie = movies[idx];
            }
            return movie;
        }
        public void PrintMovieById()
        {
            Console.WriteLine("please enter movie id to be deleted");
            int id = Convert.ToInt32(Console.ReadLine());
            int idx = GetMovieIndexById(id);
            if (idx >= 0)
                PrintMovie(movies[idx]);
            else
                Console.WriteLine("no such movie");

        }
        public void DeleteMovie()
        {
            Console.WriteLine("please enter the movie to be deleted");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                movies.Remove(GetMovieIndexById(id));

            }
            catch (Exception e)
            {
                Console.WriteLine("oops something went wrong");
            }

        }
        public movie UpdateMovieDuration(int id, double duration)
        {
            movie movie = null;
            int idx = GetMovieIndexById(id);
            if (idx != -1)
            {
                movies[idx].Duration = duration;
                movie = movies[idx];
            }
            return movie;
        }
        public void PrintMovieById(int id)
        {
            int idx = GetMovieIndexById(id);
            if (idx != -1)
            {
                PrintMovie(movies[idx]);
            }
            else
                Console.WriteLine("no such movie");

        }
        public void PrintAllMovies()
        {
            if (movies.Count == 0)
                Console.WriteLine("no movies present");
            else
            {
                foreach (var item in movies)
                {

                    PrintMovie(item.Value);
                }
            }
        }
        public void Add(movie t)
        {
            try
            {
                t.Id = GenerateId();
                movies.Add(t.Id, t);
            }
            catch
            {
                Console.WriteLine("not a correct input");
            }
        }
        public void AddMovies()
        {
            int choice = 0;
            do
            {
                movie movie = CreateMovie();

                movies.Add(movie.Id, movie);
                Console.WriteLine("do you wish to add another movie?if yes enter any number");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());

                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("not a correct input");
                }

            } while (choice != 0);
        }
        public void SortMovies()
        {
            var myList = movies.ToList();

            if (movies.Count != 0)
            {
                myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            }

            else
                Console.WriteLine("no elements to be sorted");
        }
        public void PrintMovie(movie movie)
        {
            Console.WriteLine("---------");
            Console.WriteLine(movie);
            Console.WriteLine("--------");
        }
        public void UpdateMovie()
        {
            Console.WriteLine("please enter movie id for updation");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("what do u want to update name or duartion or both");
            string choice = Console.ReadLine();
            string name;
            double duration;
            switch (choice)
            {
                case "name":
                    Console.WriteLine("please enter name");
                    name = Console.ReadLine();
                    UpdateMovieName(id, name);
                    break;
                case "duration":
                    Console.WriteLine("please enter duration");
                    while (!double.TryParse(Console.ReadLine(), out duration))
                    {
                        Console.WriteLine("invalid entry");

                    }
                    UpdateMovieDuration(id, duration);
                    break;
                case "both":
                    Console.WriteLine("please enter new name");
                    name = Console.ReadLine();
                    UpdateMovieName(id, name);
                    Console.WriteLine("enter new duration");
                    while (!double.TryParse(Console.ReadLine(), out duration))
                    {
                        Console.WriteLine("invalid entry.try again");

                    }
                    UpdateMovieDuration(id, duration);
                    break;
                default:
                    Console.WriteLine("please enter valid choice");
                    break;
            }
        }

        public void PrintMenu()
        {
            int choice = 0;
            {
                Console.WriteLine("menu");
                Console.WriteLine("1.add a movie");
                Console.WriteLine("2.add a list of movies");
                Console.WriteLine("3.update a movie");
                Console.WriteLine("4.delete a movie");
                Console.WriteLine("5.print the movie id");
                Console.WriteLine("6.print movie");
                Console.WriteLine("7.sort movie");
                Console.WriteLine("8.exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreateMovie();
                        break;
                    case 2:
                        AddMovies();
                        break;
                    case 3:
                        UpdateMovie();
                        break;
                    case 4:
                        DeleteMovie();
                        break;
                    case 5:
                        PrintMovieById();
                        break;
                    case 6:
                        PrintAllMovies();
                        break;
                    case 7:
                        SortMovies();
                        break;
                    default:
                        Console.WriteLine("please enter the val choice");
                        break;
                }
            } while (choice != 8) ;
        }




        //static void Main(String[] args)
        //{
        // new ManageMovies().PrintMenu();
        // Console.ReadKey();
        // }
    }
}