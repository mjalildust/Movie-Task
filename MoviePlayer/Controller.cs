using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePlayer
{
    public class Controller
    {
        List<Movie> mList = new List<Movie>();
        List<string> GenreList = new List<string>();
        Accounts ac = new Accounts();

        /// <summary>
        /// set default values
        /// </summary>
        public void DefaultValues()
        {
            Person p1 = new Person("Brad", 38, "Drama");
            ac.AddUser(p1);
            var p2 = new Person("Dina", 8, "Action");
            ac.AddUser(p2);

            GenreList.Add("Drama");
            GenreList.Add("Fantasy");
            GenreList.Add("Comedy");
            GenreList.Add("Action");

            var m1 = new Movie("Drama", "Changeling", 13);
            mList.Add(m1);
            var m2 = new Movie("Drama", "Indecent Proposal", 13);
            mList.Add(m2);
            var m3 = new Movie("Drama", "Room", 15);
            mList.Add(m3);
            var m4 = new Movie("Drama", "Nothing But the Truth", 13);
            mList.Add(m4);
            var m5 = new Movie("Fantasy", "The Lord of the Rings: The Fellowship of the Ring", 15);
            mList.Add(m5);
            var m6 = new Movie("Fantasy", "The Green Mile", 15);
            mList.Add(m6);
            var m7 = new Movie("Fantasy", "Avatar", 13);
            mList.Add(m7);
            var m8 = new Movie("Comedy", "Once Upon a Time... in Hollywood", 15);
            mList.Add(m8);
            var m9 = new Movie("Comedy", "The Boys ", 13);
            mList.Add(m9);
            var m10 = new Movie("Comedy", "Good Boys", 15);
            mList.Add(m10);
            var m11 = new Movie("Action", "Avengers: Endgame", 15);
            mList.Add(m11);
            var m12 = new Movie("Action", "Sacred Games", 13);
            mList.Add(m12);
            var m13 = new Movie("Action", "Angel Has Fallen", 18);
            mList.Add(m13);
            var m14 = new Movie("Action", "Rambo: Last Blood", 18);
            mList.Add(m14);
            var m15 = new Movie("Action", "Fast & Furious Presents: Hobbs & Shaw", 15);
            mList.Add(m15);
        }

        /// <summary>
        /// print user information on screen
        /// </summary>
        /// <param name="p">an object of current person</param>
        public void ShowUserInfo(Person p)
        {
            Console.WriteLine("____________________________________________________________");
            Console.WriteLine(" Username : " + p.UserName + " Age :" + p.Age + " Favorite Genre : " + p.MovieGenre);
            Console.WriteLine("____________________________________________________________");
        }

        /// <summary>
        /// show list of movies and plau it
        /// </summary>
        /// <param name="p">an object of current person</param>
        public void SelectAndPlayMovie(Person p)
        {
            List<Movie> m;
            m = Movielist(p);
            WriteToConsole(m);
            SelectMovie(m, p);
        }

        /// <summary>
        /// To edit previously entered genre. Also check if entered genre is valid
        /// </summary>
        /// <param name="p">an object of current person</param>
        public void EditGenre(Person p)
        {
            try
            {
                Console.WriteLine("Enter your favorite Genre: ");
                PrintGenres();
                string EditedGenre = GetGenre();
                ac.Edit(p, EditedGenre);
                Console.Clear();
                Console.WriteLine("Done!");
                ShowUserInfo(p);
                SelectAndPlayMovie(p);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// Create a list of movies
        /// </summary>
        /// <param name="p"></param>
        /// <returns>List of movies in selected genre</returns>
        public List<Movie> Movielist(Person p)
        {
            List<Movie> m = GetList(p.MovieGenre);
            return m;
        }

        /// <summary>
        /// Get the username that is entered by user and do validation and show the information.
        /// </summary>
        /// <param name="p">an object of current person</param>
        /// <returns>an object of current person</returns>
        public Person AccessAcount(Person p)
        {
            do
            {
                string s = GetUserName();
                p = ac.CheckUsers(s);
            } while (p.UserName == null);

            ShowUserInfo(p);
            return p;
        }

        /// <summary>
        /// Get the username
        /// </summary>
        /// <returns>username</returns>
        public string GetUserName()
        {
            Console.WriteLine("Username:");
            string u = Console.ReadLine();
            return u;
        }

        /// <summary>
        /// check the limitation age of movie and play
        /// </summary>
        /// <param name="n">The movie number</param>
        /// <param name="p">An object of person</param>
        /// <param name="m">List of movies</param>
        public void PlayMovie(int n, Person p, List<Movie> m)
        {
            if (p.Age < m[n - 1].RecommendedAge)
            {
                Console.WriteLine("You are not allowed to watch this movie");
                SelectAndPlayMovie(p);
            }
            else
            {
                Console.WriteLine("movie is playing");
                Console.WriteLine("[0] Stop and choose again");
            }
        }

        /// <summary>
        /// The main switch case
        /// </summary>
        /// <param name="s">Menu number</param>
        /// <returns></returns>
        public void SwitchCase()
        {
            Person userData = new Person();
            bool canExit = true;
            Console.WriteLine("[1] Already have an account *** Login");
            Console.WriteLine("[2] Sign up");
            Console.WriteLine("[3] Quit");
            try
            {
                while (canExit == true)
                {
                    int s = Convert.ToInt32(Console.ReadLine());
                    switch (s)
                    {
                        case 1:
                            Console.Clear();
                            userData = AccessAcount(userData);
                            SelectAndPlayMovie(userData);
                            canExit = false;
                            break;

                        case 2:
                            Console.Clear();
                            CreateNewUser();
                            userData = AccessAcount(userData);
                            SelectAndPlayMovie(userData);
                            canExit = false;
                            break;

                        case 3:
                            canExit = false;
                            break;

                        default:
                            Console.WriteLine("The selection is invalid.");
                            break;
                    }
                    if (canExit == false)
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// Movie Menu
        /// </summary>
        /// <param name="m">List of menu</param>
        /// <param name="p">An object of person</param>
        public void SelectMovie(List<Movie> m, Person p)
        {
            bool Playing = false;
            int n;
            try
            {
                do
                {
                    n = Convert.ToInt32(Console.ReadLine());
                    if (Playing == false)
                    {

                        if (0 < n && n <= m.Count)
                        {
                            PlayMovie(n, p, m);
                            Playing = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Pleas stop the movie!");

                    }

                } while (n != 0 && n <= m.Count);
                if (n == 0)
                {
                    Console.Clear();
                    WriteToConsole(m);
                    SelectMovie(m, p);
                }
                else
                if (n == m.Count + 1)
                {
                    Console.Clear();
                    SwitchCase();
                }
                else
                if (n == m.Count + 2)
                {
                    EditGenre(p);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("invalid number");
                    WriteToConsole(m);
                    SelectMovie(m, p);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// create a list of movies in selected genre
        /// </summary>
        /// <param name="g">genre</param>
        /// <returns>list of movies</returns>
        public List<Movie> GetList(string g)
        {
            Console.WriteLine("Select a movie to watch");
            List<Movie> selectedGenre = new List<Movie>();
            foreach (Movie m in mList)
                if (m.MovieGenre == g)
                    selectedGenre.Add(m);
            return selectedGenre;
        }

        /// <summary>
        /// creat new user
        /// </summary>
        public void CreateNewUser()
        {
            try
            {
                Console.WriteLine("Enter your username");
                string nn = Console.ReadLine();
                Console.WriteLine("Enter your age");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your favorite Genre: ");
                PrintGenres();
                string g = GetGenre();
                var newP = new Person(nn, a, g);
                ac.AddUser(newP);
                Console.Clear();
                Console.WriteLine("User Added, Login To Continue...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// show list of the movies with selected genre on screen
        /// </summary>
        /// <param name="mov">list of movies</param>
        public void WriteToConsole(System.Collections.IEnumerable mov)
        {
            int i = 1;
            Console.WriteLine("____________________________________________________________");
            foreach (Movie o in mov)
            {
                Console.WriteLine("[" + i + "]" + "Genre : " + o.MovieGenre + "   Movie : " + o.MovieName);
                i++;
            }
            Console.WriteLine("____________________________________________________________");
            Console.WriteLine("[" + i + "] Log out");
            i++;
            Console.WriteLine("[" + i + "] Edite genre");
        }

        /// <summary>
        /// print list of genres
        /// </summary>
        public void PrintGenres()
        {
            GenreList.ForEach(i => Console.Write("{0}\t", i));
        }

        /// <summary>
        /// Check the genre
        /// </summary>
        /// <param name="g"></param>
        /// <returns>True if genre is valid</returns>
        public bool CheckGenre(string g)
        {
            bool Founded = false;
            foreach (string s in GenreList)
                if (s == g)
                    Founded = true;
            if (Founded == false)
                return false;
            return true;
        }

        /// <summary>
        /// Get and Check that user enteres valid genre
        /// </summary>
        /// <returns></returns>
        public string GetGenre()
        {
            string s = Console.ReadLine();
            bool c = CheckGenre(s);
            while (c == false)
            {
                Console.WriteLine("please enter correct genre");
                s = Console.ReadLine();
                c = CheckGenre(s);
            }
            return s;
        }
    }
}
