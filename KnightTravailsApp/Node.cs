using System.Collections.Generic;
using System.Linq;

namespace KnightTravailsApp
{
    public class Node
    {
        private int Max { get; } = 7;
        private int Min { get; } = 0;
        private (int, int)[] Moves { get; } =
        {
            (1, 2),
            (2, 1),
            (-1, 2),
            (-2, 1),
            (-1, -2),
            (-2, -1),
            (1, -2),
            (2, -1)
        };
        
        public (int, int) Position { get; set; }
        public List<Node> PossiblePositions { get; set; }
        public Node Parent { get; set; }

        public Node((int, int) position, Node parent)
        {
            Position = position;
            Parent = parent;
        }

        public List<Node> CalculatePossiblePositions()
        {
            var (item1, item2) = Position;
            var possiblePositions = Moves
                .Select(move => new Node((item1 + move.Item1, item2 + move.Item2), this))
                .Where(move => move.Position.Item1 >= Min && 
                               move.Position.Item1 <= Max && 
                               move.Position.Item2 >= Min && 
                               move.Position.Item2 <= Max);
            
            return possiblePositions.ToList();
        }
    }
}