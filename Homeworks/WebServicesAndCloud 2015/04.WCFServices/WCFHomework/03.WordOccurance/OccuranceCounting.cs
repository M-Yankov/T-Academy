namespace WordOccurance
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 3. Create a Web service library which accepts two string as parameters. It should return the number of times the second string contains the first string.
    ///     ○ Test it with the integrated WCF client.
    /// </summary>
    public class OccuranceCounting : IOccuranceCounting
    {
        public int Occurances(string searchTerm, string text)
        {
            if (searchTerm == null || text == null)
            {
                throw new ArgumentNullException("searchTerm or text", "The value cannot be null!");
            }

            int result = 0;
            int startFromIndex = 0;

            while (startFromIndex != -1)
            {
                int resultFromSearch = text.IndexOf(searchTerm, startFromIndex);
                startFromIndex = resultFromSearch + searchTerm.Length;
                if (resultFromSearch != -1)
                {
                    result++;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Just for practice not included in the homework.
        /// </summary>
        /// <returns>A object of type Person.</returns>
        public Person GetPerson()
        {
            return new Person
            {
                Age = 20,
                Id = 2,
                IsProgrammer = true,
                Money = 2345.12M,
                Name = "Petar Ivanov",
                Sertificates = new List<string>() { "MTSNA", "MTA", "MSDEVA+" }
            };
        }
    }
}