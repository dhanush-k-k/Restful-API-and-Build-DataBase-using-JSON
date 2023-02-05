/*************************************************************************************
 * Project Name     : Access a RESTful resource and build a small database of quotes *                                                    
 * Name             : Dhanush Kumar Komalapura Kumar                                 *
 * Source File Name : main.cs                                                        *                                         
 **********************************************************************************/

/// *******************************USINGS*******************************************
/// System namespace defines commonly-used values and reference data types
/// Newtonsoft.Json.Linq' namespace provides methods to work with JSON objects/ JSON response received from the HTTPClient
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.IO;

/// *******************************NAMESPACE*****************************************
namespace assignment_10
{
    /// ***************************PROGRAM CLASS*************************************
    /// Identifier  : Program
    /// Purpose     : To accessing Restful API to query 10 quotes 
    class Program
    {
        /// *********************************METHOD***************************************
        /// Identifier  : WritetoFile
        /// Purpose     : This writes the dictionary items into a file 
        /// Returns     : writes the quotes to a file 
        private static void WritetoFile(string path, Dictionary<string, string> Quotes)
        {
            /// Write the quotes to a file in the format. Includes the file with submission. “<quote>” -- <author>
            File.WriteAllLines(path, Quotes.Select(quote => string.Format("\"<{0}>\"--<{1}>\n\n", quote.Value, quote.Key)));
        }

        /// *********************************METHOD***************************************
        /// Identifier  : Print
        /// Purpose     : This prints author key quotes, key value pairs in dictionry collection
        /// Returns     : printed key quotes and key value pairs 
        private static void Print(Dictionary<string, string> Quotes)
        {
            foreach (var quote in Quotes)
            {
                Console.WriteLine(quote.Key + "-" + quote.Value);
            }
        }

        /// *********************************METHOD***************************************
        /// Identifier  : Task, GetQuotes()
        /// Purpose     : This sends and retrives HTTP response and parse into an JSON array
        /// Returns     : the quotes  
        public static async Task<Dictionary<string, string>> GetQuotes()
        {
            /// Hits the API and the response contains the JSON data
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://type.fit/api/quotes");

            /// This extracts the JSON data
            JArray jobject = new JArray(); 
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                jobject = JArray.Parse(responseString);
            }
            else
            {
                Console.WriteLine("Error occured, the status code is: {0}", response.StatusCode);
            }

            /// Create a dictionary to store the value
            Dictionary<string, string> Quotes = new Dictionary<string, string>();

            /// This gets the first 10 quotes
            for (int i = 0; i <= 10; i++)
            {
                string author = jobject[i]["author"].ToString();
                string text = jobject[i]["text"].ToString();

                /// skip if the author name/key is same
                if (Quotes.ContainsKey(author))
                {
                    continue;
                }
                else
                {
                    Quotes.Add(author, text);
                }
            }
            return Quotes;

        }

        /// ******************************MAIN FUNCTION************************************
        /// Function    : Main
        /// Purpose     : Main is created as 'Async' class for aynchrous programming 
        /// Arguments   : String array is the command line argument             
        static async Task Main(string[] args)
        {
            Dictionary<string, string> Quotes = await GetQuotes();
            
            /// print the contents in the Quotes
            Console.WriteLine("The list of quotes extracted are \n");
            Print(Quotes);

            /// Sorts quotes from shortest to longest string based on the Length of the value
            /// Sorts the Value of dictionary and it gets converted to IOrderedEnumerable
            var SortedQuotes = Quotes.OrderBy(x => x.Value.Length).ToDictionary(i => i.Key, i => i.Value); ;
            Console.WriteLine("\nThe sorted list of quotes information from quote shortest to longest is stored in " +
                "your D:\\ drive with file name SortedQuotes.txt");

            /// write the sorted quotes to a file of format .txt
            WritetoFile("D:\\SortedQuotes.txt", SortedQuotes);
        }
    }
}
