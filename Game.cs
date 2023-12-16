namespace BullsAndCows
{
    internal class Game
    {
        public List<string> UsedNumbers { get; private set; } = [];
        public Point LastTryBullsCows { get; private set; }
        public string TheNumber { get; private set; }
        public bool Winner { get; private set; }
        public int MovesCount { get; private set; }
        
        static internal (bool, string) IsTheNumberCorrect(string inputNumber)
        {
            var isNullOrEmpty = string.IsNullOrEmpty(inputNumber);
            var isItNotANumber = !inputNumber.All(c => char.IsDigit(c));
            var isLengthLessThanFour = inputNumber.Length is not 4;
            var isNumberStartsWithZero = string.IsNullOrEmpty(inputNumber) || inputNumber.First() is '0';
            var areThereDuplicateDigits = inputNumber.Distinct().Count() is not 4;

            return (isNullOrEmpty, isItNotANumber, isLengthLessThanFour, isNumberStartsWithZero, areThereDuplicateDigits) switch
            {
                (true, _, _, _, _) => (false, "Input number is empty"),
                (_, true, _, _, _) => (false, "It is not a number"),
                (_, _, true, _, _) => (false, "The number must be 4 digits"),
                (_, _, _, true, _) => (false, "Must not start with zero"),
                (_, _, _, _, true) => (false, "Duplicate digits are not allowed in a number"),
                _ => (true, "Correct")
            };
        }

        internal bool IsTheNumberAlreadyUsed(string number) => UsedNumbers.Contains(number);

        internal static Point GetBullsAndCows(string inputNumber, string opponentNumber)
        {
            Point bullsCows = new(0, 0);
            for (int i = 0; i < inputNumber.Length; i++)
            {
                if (inputNumber[i] == opponentNumber[i]) bullsCows.X++;
                else if (opponentNumber.Contains(inputNumber[i])) bullsCows.Y++;
            }
            return bullsCows;
        }

        public virtual void Move(Game opponent, string inputNumber = "") { }

        internal class Player : Game
        {
            public Player(string theNumber) => TheNumber = theNumber;
            
            public override void Move(Game opponent, string inputNumber)
            {
                MovesCount++;
                LastTryBullsCows = GetBullsAndCows(inputNumber, opponent.TheNumber);
                UsedNumbers.Add(inputNumber);
                Winner = LastTryBullsCows.X is 4;
            }
        }

        internal class AI : Game
        {
            readonly List<string> possibleNumbers = [];
            string? _lastTryNumber;
            readonly Random _random = new();
            int _lastTryIndex;

            public AI()
            {
                possibleNumbers = Enumerable.Range(1023, 9877 - 1023).Where(x => x.ToString().Distinct().Count() is 4).ToList().ConvertAll(e => e.ToString());
                TheNumber = GetNumber(possibleNumbers);
            }

            internal string GetNumber(List<string> list) =>
                list[_random.Next(list.Count)].First() is not '0' ? list[_random.Next(list.Count)] : GetNumber(list);

            public override void Move(Game opponent, string inputNumber = "")
            {
                MovesCount++;
                _lastTryNumber = GuessTheNumber();
                LastTryBullsCows = GetBullsAndCows(_lastTryNumber, opponent.TheNumber);
                UsedNumbers.Add(_lastTryNumber);
                Winner = LastTryBullsCows.X is 4;
                UpdatePossibleNumbers();
            }

            private string GuessTheNumber()
            {
                _lastTryIndex = _random.Next(0, possibleNumbers.Count);
                return possibleNumbers[_lastTryIndex];
            }

            private void UpdatePossibleNumbers()
            {
                string tryIt = possibleNumbers[_lastTryIndex];
                possibleNumbers.RemoveAll(item =>
                {
                    Point bullsCows = GetBullsAndCows(tryIt, item);
                    return bullsCows.X != LastTryBullsCows.X || bullsCows.Y != LastTryBullsCows.Y;
                });
            }
        }
    }
}