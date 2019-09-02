using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviePlayer;
using System.Collections.Generic;

namespace UnitTestMoviePlayer
{

    [TestClass]
    public class UnitTestMovie
    {
        /// <summary>
        /// Test that list of movies for a specific genre is correct or not
        /// </summary>
        [TestMethod]
        public void TestGetList()
        {
            try
            {
                Controller MovieController = new Controller();
                MovieController.DefaultValues();
                List<Movie> expected = new List<Movie>();
                var m1 = new Movie("Drama", "Changeling", 13);
                expected.Add(m1);
                var m2 = new Movie("Drama", "Indecent Proposal", 13);
                expected.Add(m2);
                var m3 = new Movie("Drama", "Room", 15);
                expected.Add(m3);
                var m4 = new Movie("Drama", "Nothing But the Truth", 13);
                expected.Add(m4);
                List<Movie> result = MovieController.GetList("Drama");
                Assert.AreEqual(expected.Count, result.Count);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Test CheckUsers method to check the username is valid or not
        /// </summary>
        [TestMethod]
        public void TestCheckUsers()
        {
            Accounts UserAccounts = new Accounts();
            List<Person> Users = new List<Person>();
            UserAccounts.AddUser(new Person("Brad", 38, "Drama"));
            Person expected = new Person("Brad", 38, "Drama");
            Person result = UserAccounts.CheckUsers("Brad");
            Assert.AreEqual(expected.UserName, result.UserName);
            Assert.AreEqual(expected.MovieGenre, result.MovieGenre);
            Assert.AreEqual(expected.Age, result.Age);
        }
        /// <summary>
        /// Test CheckGenre function to check the entered genre is valid or not
        /// </summary>
        [TestMethod]
        public void TestCheckGenre()
        {
            Controller UserController = new Controller();
            UserController.DefaultValues();
            bool expected = true;
            bool result = UserController.CheckGenre("Comedy");
            Assert.AreEqual(expected, result);
        }
    }
}
