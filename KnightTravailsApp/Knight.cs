using System.Collections.Generic;

namespace KnightTravailsApp
{
    public class Knight
    {
        public static List<(int, int)> Moves((int, int) startingPosition, (int, int) endingPosition)
        {
            var positions = new List<(int, int)>();
            var current = FindPosition(startingPosition, endingPosition);
            while (current is not null)
            {
                positions.Add(current.Position);
                current = current.Parent;
            }

            positions.Reverse();
            return positions;
        }

        private static Node FindPosition((int, int) startingPosition, (int, int) endingPosition)
        {
            var toVisit = new Queue<Node>();
            var current = new Node(startingPosition, null);
            while (current.Position != endingPosition)
            {
                foreach (var possiblePosition in current.CalculatePossiblePositions())
                {
                    toVisit.Enqueue(possiblePosition);
                }

                current = toVisit.Dequeue();
            }

            return current;
        }
    }
}