using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Accounts ac = new Accounts();
            Controller mov = new Controller();
            List<Movie> movieList = new List<Movie>();
            Person userData = new Person();
            try
            {
                mov.DefaultValues();
                mov.SwitchCase();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}