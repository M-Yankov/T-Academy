namespace UserProfile
{
    using System;

    public class User
    {
        public User(
            string firstName,
            string lastName,
            double rating, 
            int friendsCount, 
            int age,
            DateTime born,
            string imageUrl)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Rating = rating;
            this.Friends = friendsCount;
            this.BirthDay = born;
            this.ImageUrl = imageUrl;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Rating { get; set; }

        public string ImageUrl { get; set; }

        public int Friends { get; set; }

        public int Age { get; set; }

        public DateTime BirthDay { get; set; }
    }
}