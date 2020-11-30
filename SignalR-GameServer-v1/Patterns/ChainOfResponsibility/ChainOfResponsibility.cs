using System;

namespace SignalR_GameServer_v1
{
    /// <summary>
    /// The 'Handler' abstract class
    /// </summary>
    abstract class Handler
    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract double HandleRequest(string userWord, string givenWord);
    }

    class ConcreteHandler1 : Handler
    {
        public override double HandleRequest(string userWord, string givenWord)
        {
            //ar zodis parasytas atbulai
            if (userWord == Reverse(givenWord))
            {
                Console.WriteLine("Visas zodis tinkamas grazinam 150proc");
                return 1.5;
            }
            else if (successor != null)
            {
                return successor.HandleRequest(userWord, givenWord);
            }

            return 0;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

    class ConcreteHandler2 : Handler
    {
        public override double HandleRequest(string userWord, string givenWord)
        {
            //ar visas zodis lygus
            if (userWord == givenWord)
            {
                Console.WriteLine("Visas zodis tinkamas grazinam 100proc");
                return 1;
            }
            else if (successor != null)
            {
                return successor.HandleRequest(userWord, givenWord);
            }

            return 0;
        }
    }

    class ConcreteHandler3 : Handler
    {
        public override double HandleRequest(string userWord, string givenWord)
        {
            double count = Convert.ToDouble(Compute(givenWord,userWord)) / givenWord.Length;
            Console.WriteLine(count);
            Console.WriteLine(Compute(givenWord,userWord));

            //jeigu yra lygiu daliu
            if (count < 0.3)
            {
                Console.WriteLine("Dalis zodzio tinkama grazinam 50proc");
                return 0.5;
            }
            else if (successor != null)
            {
                return successor.HandleRequest(userWord, givenWord);
            }

            return 0;
        }

        public static int Compute(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                if (string.IsNullOrEmpty(t))
                    return 0;
                return t.Length;
            }

            if (string.IsNullOrEmpty(t))
            {
                return s.Length;
            }

            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];
            
            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 1; j <= m; d[0, j] = j++) ;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    int min1 = d[i - 1, j] + 1;
                    int min2 = d[i, j - 1] + 1;
                    int min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }

            return d[n, m];
        }
    }

    class ConcreteHandler4 : Handler
    {
        public override double HandleRequest(string userWord, string givenWord)
        {
            //ar yra raidziu tinkamu
            if (userWord.Length == givenWord.Length)
            {
                Console.WriteLine("Atitinka ilgiai");
                return 0.1;
            }
            else if (successor != null)
            {
                return successor.HandleRequest(userWord, givenWord);
            }

            return 0;
        }
    }
}