using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace DictionaryProject
{
    public class movie : IComparable<movie>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }

        public int CompareTo(movie other)
        {
            return this.Duration.CompareTo(other.Duration);
        }

        public void TakeMovieDetails()
        {
            Console.WriteLine("please enter the movie name");
            Name = Console.ReadLine();
            double duration = 0;
            Console.WriteLine("enter movie duration");
            while (!double.TryParse(Console.ReadLine(), out duration))
            {
                Console.WriteLine("invalid entry for duration");
            }
            Duration = duration;

        }
        public override string ToString()
        {
            return "movie id:" + Id + "name:" + Name + "duration:" + Duration;
        }
        public
            static void Main(String[] args)
        {
            new movie().TakeMovieDetails();
            new ManageMoviesUsingDictionary().PrintMenu();
            Console.ReadKey();
        }
    }
}
