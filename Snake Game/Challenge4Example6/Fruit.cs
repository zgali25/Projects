// Define the Fruit class
namespace Challenge4Example6
{
    internal class Fruit
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public Fruit()
        {
            Random random = new Random();
            XPosition = random.Next(2, Console.WindowWidth - 2);
            YPosition = random.Next(2, Console.WindowHeight - 2);
        }

        public override string ToString()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            return ((char)64).ToString();
        }
    }
}




