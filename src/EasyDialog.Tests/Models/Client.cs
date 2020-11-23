using System;

namespace EasyDialog.Tests.Models
{
    public enum Sex
    {
        Male,
        Female
    }

    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public bool IsPerformanceArtist { get; set; }
        public int HighLoadsCount;

        public static Client Get()
        {
            return new Client()
            {
                Id = 4516,
                FirstName = "Billy",
                LastName = "Harrington",
                BirthDate = DateTime.Today.AddYears(-30),
                Sex = Sex.Male,
                IsPerformanceArtist = true,
                HighLoadsCount = 6,
            };
        }
    }
}
