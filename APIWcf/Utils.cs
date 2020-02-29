using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWcf
{
    public class Utils
    {
        public static int GetRandomNumber()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);
            int value = random.Next(1, 999999);

            return value;
        }
    }
}