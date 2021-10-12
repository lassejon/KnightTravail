using System.Collections.Generic;
using System.Linq;

namespace KnightTravailsApp
{
    public class Knight
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
        
        private (int, int) Position { get; set; }
        private List<(int, int)> PossiblePositions { get; set; }
        private (int, int) Parent { get; set; }

        public Knight((int, int) position, (int, int) parent)
        {
            Position = position;
            Parent = parent;
            PossiblePositions = CalculatePossiblePositions(position);
        }
        
        public List<(int, int)> KnightMoves((int, int) startingPosition, (int, int) endingPosition)
        {
            var moves = new List<(int, int)>();
            var movesToMake = new Queue<(int, int)>();
            var currentPosition = startingPosition;
            while (currentPosition != endingPosition)
            {
                var possibleMoves = PossibleMoves(currentPosition);
                foreach (var possibleMove in possibleMoves)
                {
                    movesToMake.Enqueue(possibleMove);
                }
                moves.Add(currentPosition);
                currentPosition = movesToMake.Dequeue();
            }
            moves.Add(currentPosition);

            return moves;
        }
        
        private List<(int, int)> CalculatePossiblePositions((int, int) position)
        {
            var (item1, item2) = position;
            var possiblePositions = Moves
                .Select(move => (item1 + move.Item1, item2 + move.Item2))
                .Where(move => move.Item1 >= Min && move.Item1 <= Max && move.Item2 >= Min && move.Item2 <= Max);
            
            return possiblePositions.ToList();
        }
    }
}