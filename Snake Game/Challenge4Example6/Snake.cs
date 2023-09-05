// Define the Snake class
namespace Chapter4Example6
{
    internal class Snake
    {
        public LinkedList<(int, int)> Body { get; set; }
        public int Length { get; set; }
        public int HeadXPosition => Body.First.Value.Item1;
        public int HeadYPosition => Body.First.Value.Item2;

        public Snake(int xPosition, int yPosition)
        {
            Body = new LinkedList<(int, int)>();
            Body.AddFirst((xPosition, yPosition));
            Length = 1;
        }

        public void MoveLeft() { Move(HeadXPosition - 1, HeadYPosition); }
        public void MoveRight() { Move(HeadXPosition + 1, HeadYPosition); }
        public void MoveUp() { Move(HeadXPosition, HeadYPosition - 1); }
        public void MoveDown() { Move(HeadXPosition, HeadYPosition + 1); }

        private void Move(int newX, int newY)
        {
            Body.AddFirst((newX, newY));
            if (Body.Count > Length) Body.RemoveLast();
        }

        public override string ToString()
        {
            foreach ((int, int) part in Body)
            {
                Console.SetCursorPosition(part.Item1, part.Item2);
                Console.Write("O");
            }
            return "";
        }
    }

}

