using System;
using System.Collections.Generic;

namespace SignalR_GameServer_v1
{
    abstract class Word
    {
        public string word { get; set; }
        public abstract Word Clone();

        public Word()
        {
        }
        public Word(string Word)
        {
            this.word = Word;
        }
        public abstract void Add(Word word);

        public abstract void Remove(Word word);

        public abstract void Display(int depth);

        public abstract String GetItem(int level);
    }

    class RandomWords : Word
    {
        List<String> firstWordList = new List<String>();

        List<String> secondWordList = new List<String>();

        List<String> thirdWordList = new List<String>();
        public RandomWords()
        {
            firstWordList.Add("PAntanas");
            firstWordList.Add("PBudelis");
            firstWordList.Add("PButelis");
            firstWordList.Add("PKompas");
            firstWordList.Add("POrbita");
            
            secondWordList.Add("ALapas");
            secondWordList.Add("ALaidas");
            secondWordList.Add("AMykolas");
            secondWordList.Add("AJonukas");
            secondWordList.Add("ANegalima");
            
            thirdWordList.Add("TTelefonas");
            thirdWordList.Add("TAtsuktuvas");
            thirdWordList.Add("TMargarita");
            thirdWordList.Add("TLaikas");
            thirdWordList.Add("TMokomasis");
            thirdWordList.Add("TLOGIKA");
        }

        public RandomWords(string word)
        {
            this.word = word;
        }

        public override Word Clone()
        {
            throw new NotImplementedException();
        }

        public override void Add(Word word)
        {
            throw new NotImplementedException();
        }
        public override void Remove(Word word)
        {
            throw new NotImplementedException();
        }
        public override void Display(int depth)
        {
            throw new NotImplementedException();
        }
        public override String GetItem(int level)
        {
            switch (level)
            {
                case 1:
                    Random random = new Random();
                    int start = random.Next(0, firstWordList.Count);
                    string newWord = firstWordList[start];
                    firstWordList.RemoveAt(start);

                    return newWord;
                case 2:
                    Random random2 = new Random();
                    int start2 = random2.Next(0, secondWordList.Count);
                    string newWord2 = secondWordList[start2];
                    secondWordList.RemoveAt(start2);

                    return newWord2;
                case 3:
                    Random random3 = new Random();
                    int start3 = random3.Next(0, thirdWordList.Count);
                    string newWord3 = thirdWordList[start3];
                    thirdWordList.RemoveAt(start3);

                    return newWord3;
            }

            return "";
        }
        
    }

    class RandomLetters : Word
    {
        List<String> firstWordList = new List<String>();

        List<String> secondWordList = new List<String>();

        List<String> thirdWordList = new List<String>();
        public RandomLetters()
        {
            firstWordList.Add("Pzxzxzx");
            firstWordList.Add("Pbcbcbc");
            firstWordList.Add("Pcvcvcv");
            firstWordList.Add("Polololo");
            firstWordList.Add("Pkikikiki");
            
            secondWordList.Add("Artrtrtrt");
            secondWordList.Add("Aqwqwqw");
            secondWordList.Add("Auiuiuiui");
            secondWordList.Add("Apopopo");
            secondWordList.Add("Anrnrnrn");
            
            thirdWordList.Add("Tsesese");
            thirdWordList.Add("Tasasas");
            thirdWordList.Add("Tasasas");
            thirdWordList.Add("Tvbvbvb");
            thirdWordList.Add("Tgsgssg");
            thirdWordList.Add("Tsdgdgdxc");
            thirdWordList.Add("Tvxcvxcv");
            thirdWordList.Add("Tgdfgdfg");
        }

        public RandomLetters(string letters)
        {
            this.word = letters;
        }
        public override Word Clone()
        {
            throw new NotImplementedException();
        }

        public override void Add(Word word)
        {
            throw new NotImplementedException();
        }
        public override void Remove(Word word)
        {
            throw new NotImplementedException();
        }
        public override void Display(int depth)
        {
            throw new NotImplementedException();
        }
        public override String GetItem(int level)
        {
            switch (level)
            {
                case 1:
                    Random random = new Random();
                    int start = random.Next(0, firstWordList.Count);
                    string newWord = firstWordList[start];
                    firstWordList.RemoveAt(start);

                    return newWord;
                case 2:
                    Random random2 = new Random();
                    int start2 = random2.Next(0, secondWordList.Count);
                    string newWord2 = secondWordList[start2];
                    secondWordList.RemoveAt(start2);

                    return newWord2;
                case 3:
                    Random random3 = new Random();
                    int start3 = random3.Next(0, thirdWordList.Count);
                    string newWord3 = thirdWordList[start3];
                    thirdWordList.RemoveAt(start3);

                    return newWord3;
            }

            return "";
        }
    }

    class RandomSentence : Word
    {
        List<String> firstWordList = new List<String>();

        List<String> secondWordList = new List<String>();

        List<String> thirdWordList = new List<String>();
        public RandomSentence()
        {
            firstWordList.Add("PNoriu namo");
            firstWordList.Add("PMano namas didelis");
            firstWordList.Add("PKompiuteris naujas");
            firstWordList.Add("PPuodelis pilnas kavos");

            secondWordList.Add("Aausines kraunasi");
            secondWordList.Add("AMilaknis pataiko");
            secondWordList.Add("ATelefoniukas senas");
            secondWordList.Add("SNeturiu nieko");

            thirdWordList.Add("TServeris veikia");
            thirdWordList.Add("Tubuntu sistema");
            thirdWordList.Add("TKieras kartonas");
            thirdWordList.Add("TLenta ne malka");
        }
        public RandomSentence(string word)
        {
            this.word = word;
        }

        public override Word Clone()
        {
            throw new NotImplementedException();
        }

        public override void Add(Word word)
        {
            throw new NotImplementedException();
        }
        public override void Remove(Word word)
        {
            throw new NotImplementedException();
        }
        public override void Display(int depth)
        {
            throw new NotImplementedException();
        }
        public override String GetItem(int level)
        {
            switch (level)
            {
                case 1:
                    Random random = new Random();
                    int start = random.Next(0, firstWordList.Count);
                    string newWord = firstWordList[start];
                    firstWordList.RemoveAt(start);

                    return newWord;
                case 2:
                    Random random2 = new Random();
                    int start2 = random2.Next(0, secondWordList.Count);
                    string newWord2 = secondWordList[start2];
                    secondWordList.RemoveAt(start2);

                    return newWord2;
                case 3:
                    Random random3 = new Random();
                    int start3 = random3.Next(0, thirdWordList.Count);
                    string newWord3 = thirdWordList[start3];
                    thirdWordList.RemoveAt(start3);

                    return newWord3;
            }

            return "";
        }
    }

    abstract class Creator
    {
        public abstract Word FirstLevel();

        public abstract Word SecondLevel();

        public abstract Word ThirdLevel();
    }

    class RandomWordsCreator : Creator
    {

        static FlyweightFactory factory = new FlyweightFactory();

        Word rw = factory.GetFlyweight("RW");
        
        public override Word FirstLevel()
        {
            return new RandomLetters(rw.GetItem(1));
        }
        public override Word SecondLevel()
        {
            return new RandomLetters(rw.GetItem(2));
        }
        public override Word ThirdLevel()
        {
            return new RandomLetters(rw.GetItem(3));
        }

        public RandomWordsCreator()
        {
        }
    }

    class RandomLettersCreator : Creator
    {
        static FlyweightFactory factory = new FlyweightFactory();

        Word rl = factory.GetFlyweight("RL");
        public override Word FirstLevel()
        {
            return new RandomLetters(rl.GetItem(1));
        }
        public override Word SecondLevel()
        {
            return new RandomLetters(rl.GetItem(2));
        }
        public override Word ThirdLevel()
        {
            return new RandomLetters(rl.GetItem(3));
        }

        public RandomLettersCreator()
        {
        }
    }

    class RandomSentenceCreator : Creator
    {
        static FlyweightFactory factory = new FlyweightFactory();

        Word rs = factory.GetFlyweight("RS");
        public override Word FirstLevel()
        {
            return new RandomSentence(rs.GetItem(1));
        }
        public override Word SecondLevel()
        {
            return new RandomSentence(rs.GetItem(2));
        }
        public override Word ThirdLevel()
        {
            return new RandomSentence(rs.GetItem(3));
        }
        public RandomSentenceCreator()
        {
        }
    }
}