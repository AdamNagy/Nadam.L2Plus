using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
- Calculate of the word count of each sentences
- Split the sentences into an array of words and select the ones that start with a vowel(magánhangzó) (y is not a vowel in this case)
- Find the longest word
- Display the average word count of the sentences
- Put the words into alphabetical order and remove the duplicates (case insensitive)

 */
namespace NJ05_LINQ
{
    class Program
    {


        static void Main(string[] args)
        {
            // StringArrayTasks.Run();
            EmployeesTasks.Run();
        }


    }

    public static class EnumerableExtensions
    {
        public static T MaxByProperty<T, K>(this IEnumerable<T> source, Func<T, K> pred) where K: IComparable
        {
            if( source == null)
                throw new ArgumentNullException(nameof(source), "Cannot be null");

            // default(T) is not good in case of value type
            if (source.Count() == 0)
                return default(T);

            T max = source.First();
            foreach (var item in source)
            {
                if (pred(item).CompareTo(pred(max)) > 0 )
                    max = item;
            }

            return max;
        }
    }
}
