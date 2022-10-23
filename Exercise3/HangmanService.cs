namespace Exercise3
{
    internal class HangmanService
    {
        string[] words = {
            "purpose",
            "land",
            "message",
            "date",
            "add",
            "inflate",
            "straighten",
            "cathedral",
            "invisible",
            "adult"
        };

        enum status
        {
            Correct = 0,
            Incorrect = 1,
            Duplicate = 2,
        }

        string wordToPlay;
        char[] chars;
        int remaining = 10;

        Random random = new Random();

        public void init()
        {
            remaining = 10;
            Console.Clear();
        }

        public void Restart()
        {
            init();
            int index = random.Next(0, words.Length - 1);
            wordToPlay = words[index];
            chars = new char[wordToPlay.Length];
            for (int i = 0; i < wordToPlay.Length; i++)
            {
                chars[i] = '_';
            }
            GetDisplay();
        }
        public void GetDisplay()
        {
            Console.WriteLine("============================");
            Console.WriteLine(chars);
            Console.WriteLine("============================");
        }

        public void Input(char input)
        {
            Console.Clear();
            int i;
            status status = status.Incorrect;
            for (i = 0; i < wordToPlay.Length; i++)
            {
                if (input == chars[i])
                {
                    GetDisplay();
                    Console.WriteLine("You have already tried this character.");
                    status = status.Duplicate;
                    break;
                }
                else if (input == wordToPlay[i])
                {
                    chars[i] = input;
                    if (new string(chars) == wordToPlay)
                    {
                        GetDisplay();
                        Console.WriteLine("Congratulation, you’re win.");
                        Console.ReadLine();
                        Restart();
                        break;
                    }
                    
                    status = status.Correct;
                }
            }

            if (i == wordToPlay.Length)
            {
                GetDisplay();
            }
            if (i == wordToPlay.Length && !(status == status.Correct || status == status.Duplicate))
            {
                remaining -= 1;
                Console.WriteLine("Sorry, you’re wrong. Remaining: {0}", GetRemainingTry());
            }
            if (remaining <= 0)
            {
                Console.WriteLine("You Lose!!");
                Console.ReadLine();
                Restart();
            }
        }

        public int GetRemainingTry()
        {
            return remaining;
        }
    }
}
