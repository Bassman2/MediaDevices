using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDeviceApp.Mvvm
{
    public static class Enums
    {
        //public static List<T> IgnoreExceptions<T>(this IEnumerable<T> source)
        //{
        //    foreach (T s in source)
        //    {
        //        try
        //        {
        //            yield return s;
        //        }
        //        catch ()
        //        { }
        //    }
        //}

        public static IEnumerable<T> CatchExceptions<T>(this IEnumerable<T> src, Action<Exception> action = null)
        {
            using (var enumerator = src.GetEnumerator())
            {
                bool next = true;

                while (next)
                {
                    try
                    {
                        next = enumerator.MoveNext();
                    }
                    catch (Exception ex)
                    {
                        if (action != null)
                        {
                            action(ex);
                        }
                        continue;
                    }

                    if (next)
                    {
                        yield return enumerator.Current;
                    }
                }
            }
        }
    }
}
