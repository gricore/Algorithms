using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solution_1
{
    class Program
    {
        #region Main

        static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            // Read text
            string theText = Console.ReadLine();
            // Start Recurtion            
            var list = GetVariantList(new List<string>() { theText });
            // Write List to console
            WriteList(list);
            // Wait for key-pressing
            Console.ReadLine();
        }

        #endregion

        #region Solution method

        static List<string> GetVariantList(List<string> textList)
        {
            if (textList.First().Length == 2)
                return InsertToEveryWhere(textList.First());

            List<string> newList = new List<string>();

            foreach (var item in textList)
            {
                var pab = GetVariantList(new List<string>() { item.Remove(item.Length - 1, 1) });
               
                foreach (var newItem in pab)
                {
                    newList.AddRange(InsertToEveryWhere(newItem, textList.First().Last()));
                }
            }

            return newList;
        }

        #endregion

        #region Utilities

        static List<string> InsertToEveryWhere(string s, char ch)
        {
            List<string> variantList = new List<string>();

            for (int i = 0; i < s.Length + 1; i++)
            {
                var insertedText = s.Insert(i, ch.ToString());
                variantList.Add(insertedText);
            }

            return variantList;
        }

        static List<string> InsertToEveryWhere(string s)
        {
            // Get Last Element
            char lastElement = s.Last();
            // Remove Last Element and get new string
            string newText = s.Remove(s.Length - 1, 1);

            List<string> variantList = new List<string>();
            for (int i = 0; i < newText.Length + 1; i++)
            {
                var insertedText = newText.Insert(i, lastElement.ToString());
                variantList.Add(insertedText);
            }

            return variantList;
        }

        public static void WriteList(IList<string> list)
        {
            int index = 0;
            foreach (var item in list)
            {
                index++;
                Console.WriteLine(index.ToString() + ": " + item);
            }
        }

        #endregion
    }
}
