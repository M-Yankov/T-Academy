namespace PeopleInformation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class PersonInfoReader
    {
        private IDictionary<string, List<string>> townsAndPersonds; 

        public void Process()
        {
            this.townsAndPersonds = new Dictionary<string, List<string>>();

            using (StreamReader phonesReader = new StreamReader("..\\..\\phones.txt"))
            {
                while (!phonesReader.EndOfStream)
                {
                    string line = phonesReader.ReadLine();
                    string[] fields = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                    if (!this.townsAndPersonds.ContainsKey(fields[1]))
                    {
                        this.townsAndPersonds.Add(fields[1], new List<string>());
                    }

                    this.townsAndPersonds[fields[1]].Add(line);   
                }
            }

            using (StreamReader reader = new StreamReader("..\\..\\commands.txt"))
            {
                StringBuilder result = new StringBuilder();
                while (!reader.EndOfStream)
                {
                    string methodAsString = reader.ReadLine().Trim();
                    string[] parameters = this.ExtractParameters(methodAsString);
                    if (methodAsString.Contains(","))
                    {
                        result.AppendLine(this.Find(parameters[0], parameters[1]));
                    }
                    else
                    {
                        result.AppendLine(this.Find(parameters[0]));
                    }
                }

                Console.WriteLine(result.ToString());
            }
        }

        private string Find(string name)
        {
            IList<string> result = new List<string>();
            foreach (var pair in this.townsAndPersonds)
            {
                pair.Value.Where(record => record.Contains(name)).ToList().ForEach(rec => result.Add(rec));
            }

            return string.Join("\n", result);
        }

        private string Find(string name, string town)
        {
            if (!this.townsAndPersonds.ContainsKey(town))
            {
                return string.Format("Town ({0}) does not exists in the current context.", town);
            }

            List<string> result = this.townsAndPersonds[town].Where(record => record.Contains(name)).ToList();
            return string.Join("\n", result);
        }

        private string[] ExtractParameters(string methodAsString)
        {
            int indexOfOpenBracket = methodAsString.IndexOf("(");
            int indexOfCloseBracket = methodAsString.IndexOf(")");
            int lengthOfparameters = indexOfCloseBracket - indexOfOpenBracket;
            string methodParameters = methodAsString.Substring(indexOfOpenBracket + 1, lengthOfparameters - 1);
            string[] parameters = methodParameters.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            return parameters;
        }
    }
}
