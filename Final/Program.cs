using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("C:/Files/VM.txt"))
            {
                var line = sr.ReadLine();
                String[] wordsArray;
                Dictionary<string, int> myDict = new Dictionary<string, int>();


                while (line != null)
                {
                    wordsArray = line.Split(' ', ',', '.', '-', '<', '>', '"', '!', '?', '[', ']', '(', ')', '\\', '/', '=', ';');

                    for (int i = 0; i < wordsArray.Length; i++)
                    {
                        wordsArray[i] = wordsArray[i].ToLower();
                        if (wordsArray[i] == "" || wordsArray[i] == "p") continue; 
                        if (myDict.ContainsKey(wordsArray[i]))
                        {
                            myDict[wordsArray[i]] += 1;
                        } else
                        {
                            myDict.Add(wordsArray[i], 1);

                        }
                        
                    }
                    line = sr.ReadLine();

                }

                var sortedDict = from entry in myDict orderby entry.Value descending select entry;
       
                using (StreamWriter sw = new StreamWriter("C:/Files/Result.txt"))
                {
                    foreach (var pair in sortedDict)
                        sw.WriteLine("{0} - {1}", pair.Key, pair.Value);

                }

            }
        }
    }
}
