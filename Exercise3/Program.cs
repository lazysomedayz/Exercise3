namespace Exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HangmanService hangmanService = new HangmanService();
        start:
            hangmanService.Restart();
            while (true)
            {
                char input;
                try
                {
                    Console.Write("Please enter character: ");
                    input = char.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Clear();
                    goto start;
                }
                hangmanService.Input(input);
            }
        }
    }
}