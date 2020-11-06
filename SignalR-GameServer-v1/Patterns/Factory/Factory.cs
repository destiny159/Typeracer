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
        public abstract Word FactoryMethod();
    }

    class RandomWordsCreator : Creator
    {

        List<String> wordList = new List<String>();
        public override Word FactoryMethod()
        {
            Random random = new Random();
            int start = random.Next(0, wordList.Count);
            string newWord = wordList[start];
            wordList.RemoveAt(start);

            return new RandomLetters(newWord);
        }

        public RandomWordsCreator()
        {
            wordList.Add("Antanas");
            wordList.Add("Budelis");
            wordList.Add("Butelis");
            wordList.Add("Kompas");
            wordList.Add("Orbita");
            wordList.Add("Lapas");
            wordList.Add("Laidas");
            wordList.Add("Mykolas");
            wordList.Add("Jonukas");
            wordList.Add("Negalima");
            wordList.Add("Telefonas");
            wordList.Add("Atsuktuvas");
            wordList.Add("Margarita");
            wordList.Add("Laikas");
        }
    }

    class RandomLettersCreator : Creator
    {
        List<String> wordList = new List<String>();
        public override Word FactoryMethod()
        {
            Random random = new Random();
            int start = random.Next(0, wordList.Count);
            string newWord = wordList[start];
            wordList.RemoveAt(start);

            return new RandomLetters(newWord);
        }

        public RandomLettersCreator()
        {
            wordList.Add("zxzxzx");
            wordList.Add("xcxcxc");
            wordList.Add("cvcvcv");
            wordList.Add("vbvbvb");
            wordList.Add("bnbnbn");
            wordList.Add("nmnmnm");
            wordList.Add("asasas");
            wordList.Add("qwqwqw");
            wordList.Add("wewewe");
            wordList.Add("ererer");
            wordList.Add("rtrtrt");
            wordList.Add("tytyty");

        }
    }

    class RandomSentenceCreator : Creator
    {
        List<String> wordList = new List<String>();
        public override Word FactoryMethod()
        {
            Random random = new Random();
            int start = random.Next(0, wordList.Count);
            string newWord = wordList[start];
            wordList.RemoveAt(start);

            return new RandomLetters(newWord);
        }

        public RandomSentenceCreator()
        {
            wordList.Add("Noriu namo");
            wordList.Add("Mano namas didelis");
            wordList.Add("Kompiuteris naujas");
            wordList.Add("Puodelis pilnas kavos");
            wordList.Add("ausines kraunasi");
            wordList.Add("Milaknis pataiko");
            wordList.Add("Telefoniukas senas");
            wordList.Add("Neturiu nieko");
            wordList.Add("Serveris veikia");
            wordList.Add("ubuntu sistema");
            wordList.Add("Kieras kartonas");
            wordList.Add("Lenta ne malka");
        }
    }
}