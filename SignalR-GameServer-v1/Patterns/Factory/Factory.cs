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
    }

    class RandomWords : Word
    {
        public RandomWords()
        {
        }

        public RandomWords(string word)
        {
            this.word = word;
        }

        public override Word Clone()
        {
            throw new NotImplementedException();
        }
    }

    class RandomLetters : Word
    {
        public RandomLetters()
        {
        }

        public RandomLetters(string letters)
        {
            this.word = letters;
        }
        public override Word Clone()
        {
            throw new NotImplementedException();
        }
    }

    class RandomSentence : Word
    {
        public RandomSentence()
        {
        }

        public RandomSentence(string word)
        {
            this.word = word;
        }

        public override Word Clone()
        {
            throw new NotImplementedException();
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

        List<String> firstWordList = new List<String>();

        List<String> secondWordList = new List<String>();

        List<String> thirdWordList = new List<String>();
        public override Word FirstLevel()
        {
            Random random = new Random();
            int start = random.Next(0, firstWordList.Count);
            string newWord = firstWordList[start];
            firstWordList.RemoveAt(start);

            return new RandomLetters(newWord);
        }
        public override Word SecondLevel()
        {
            Random random = new Random();
            int start = random.Next(0, secondWordList.Count);
            string newWord = secondWordList[start];
            secondWordList.RemoveAt(start);

            return new RandomLetters(newWord);
        }
        public override Word ThirdLevel()
        {
            Random random = new Random();
            int start = random.Next(0, thirdWordList.Count);
            string newWord = thirdWordList[start];
            thirdWordList.RemoveAt(start);

            return new RandomLetters(newWord);
        }

        public RandomWordsCreator()
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
    }

    class RandomLettersCreator : Creator
    {
        List<String> firstWordList = new List<String>();

        List<String> secondWordList = new List<String>();

        List<String> thirdWordList = new List<String>();
        public override Word FirstLevel()
        {
            Random random = new Random();
            int start = random.Next(0, firstWordList.Count);
            string newWord = firstWordList[start];
            firstWordList.RemoveAt(start);

            return new RandomLetters(newWord);
        }
        public override Word SecondLevel()
        {
            Random random = new Random();
            int start = random.Next(0, secondWordList.Count);
            string newWord = secondWordList[start];
            secondWordList.RemoveAt(start);

            return new RandomLetters(newWord);
        }
        public override Word ThirdLevel()
        {
            Random random = new Random();
            int start = random.Next(0, thirdWordList.Count);
            string newWord = thirdWordList[start];
            thirdWordList.RemoveAt(start);

            return new RandomLetters(newWord);
        }

        public RandomLettersCreator()
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
    }

    class RandomSentenceCreator : Creator
    {
       List<String> firstWordList = new List<String>();

        List<String> secondWordList = new List<String>();

        List<String> thirdWordList = new List<String>();
        public override Word FirstLevel()
        {
            Random random = new Random();
            int start = random.Next(0, firstWordList.Count);
            string newWord = firstWordList[start];
            firstWordList.RemoveAt(start);

            return new RandomLetters(newWord);
        }
        public override Word SecondLevel()
        {
            Random random = new Random();
            int start = random.Next(0, secondWordList.Count);
            string newWord = secondWordList[start];
            secondWordList.RemoveAt(start);

            return new RandomLetters(newWord);
        }
        public override Word ThirdLevel()
        {
            Random random = new Random();
            int start = random.Next(0, thirdWordList.Count);
            string newWord = thirdWordList[start];
            thirdWordList.RemoveAt(start);

            return new RandomLetters(newWord);
        }

        public RandomSentenceCreator()
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
    }
}