using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePlayer
{
    public class Person
    {
        public Person()
        {
        }

        public Person(string v1, int v2, string v3)
        {
            UserName = v1;
            Age = v2;
            MovieGenre = v3;
        }

        public string UserName { get; set; }
        public int Age { get; set; }
        public string MovieGenre { get; set; }
    }

    public class Movie
    {
        public Movie(string v1, string v2, int v3)
        {
            MovieGenre = v1;
            MovieName = v2;
            RecommendedAge = v3;
        }

        public string MovieGenre { get; set; }
        public string MovieName { get; set; }
        public int RecommendedAge { get; set; }
    }

    public class Accounts
    {
        List<Person> Users = new List<Person>();

        /// <summary>
        /// create an object of person 
        /// </summary>
        /// <param name="k">object of person</param>
        public void AddUser(Person k)
        {
            Users.Add(k);
        }

        /// <summary>
        /// check that the entered username is existed
        /// </summary>
        /// <param name="u">entered username</param>
        /// <returns></returns>
        public Person CheckUsers(string u)
        {
            Person result = new Person();
            foreach (Person p in Users)
                if (p.UserName == u)
                    result = p;
            if (result.MovieGenre == null) Console.WriteLine("User not found");

            return result;
        }

        /// <summary>
        /// edit user's genre
        /// </summary>
        /// <param name="p"> user</param>
        /// <param name="g">new genre</param>
        public void Edit(Person p, string g)
        {
            p.MovieGenre = g;
        }
    }

}
