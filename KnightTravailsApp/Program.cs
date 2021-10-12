using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace KnightTravailsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var movesMade = Knight.Moves((3, 3), (4, 3));
            movesMade.ForEach(move => Console.Write(move + ", "));
        }
    }
}