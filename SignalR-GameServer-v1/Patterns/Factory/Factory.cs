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
            firstWordList.Add("Antanas");
            firstWordList.Add("Butelis");
            firstWordList.Add("Budelis");
            firstWordList.Add("Kirvis");
            firstWordList.Add("Ponas");
            firstWordList.Add("Adata");
            firstWordList.Add("Lukas");
            firstWordList.Add("Pelė");
            firstWordList.Add("Laidas");
            firstWordList.Add("Indas");
            firstWordList.Add("Bliūdas");
            firstWordList.Add("Ekranas");
            firstWordList.Add("Limpa");
            
            secondWordList.Add("Lipdukas");
            secondWordList.Add("Piniginė");
            secondWordList.Add("Servėtėlė");
            secondWordList.Add("Raktelis");
            secondWordList.Add("Tašė");
            secondWordList.Add("Ilgintuvas");
            secondWordList.Add("Bonka");
            secondWordList.Add("Šiaudas");
            secondWordList.Add("Mašina");
            secondWordList.Add("Sniegas");
            secondWordList.Add("Medis");
            secondWordList.Add("Laukas");
            secondWordList.Add("Tvora");
            
            thirdWordList.Add("Telefonas");
            thirdWordList.Add("Atsuktuvas");
            thirdWordList.Add("Margarita");
            thirdWordList.Add("Miegojimas");
            thirdWordList.Add("Slidinėjimas");
            thirdWordList.Add("Replės");
            thirdWordList.Add("Proginis");
            thirdWordList.Add("Kardanas");
            thirdWordList.Add("Ratas");
            thirdWordList.Add("Turbina");
            thirdWordList.Add("Kapotas");
            thirdWordList.Add("Durelės");
            
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
            firstWordList.Add("asddaffsf");
            firstWordList.Add("gfdgfg");
            firstWordList.Add("bbvbnv");
            firstWordList.Add("hjhjnb");
            firstWordList.Add("fgfcv");
            firstWordList.Add("cvcvdg");
            firstWordList.Add("gdfgdfvdb");
            firstWordList.Add("asddsc");
            firstWordList.Add("gdfgddg");
            firstWordList.Add("vxcdsfq");
            
            secondWordList.Add("qdsfsf");
            secondWordList.Add("vxcvasdadw");
            secondWordList.Add("qqmmpojk");
            secondWordList.Add("zxcfsfe");
            secondWordList.Add("fsefdxcv");
            secondWordList.Add("qdsdsaf");
            secondWordList.Add("vxcfsdadw");
            secondWordList.Add("qqmsdmpojk");
            secondWordList.Add("zxcxfsfe");
            secondWordList.Add("xcvefcv");
            
            thirdWordList.Add("xcvertasdljk");
            thirdWordList.Add("jklfgsdf");
            thirdWordList.Add("sdfxcvgfh");
            thirdWordList.Add("fsd");
            thirdWordList.Add("xcvdrgd");
            thirdWordList.Add("rdgdg");
            thirdWordList.Add("gdfgdfgdfg");
            thirdWordList.Add("dgqqd");
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
            firstWordList.Add("Noriu namo");
            firstWordList.Add("Mano namas didelis");
            firstWordList.Add("Kompiuteris naujas");
            firstWordList.Add("Puodelis pilnas kavos");

            secondWordList.Add("Ausines kraunasi");
            secondWordList.Add("Milaknis pataiko");
            secondWordList.Add("Telefoniukas senas");
            secondWordList.Add("Neturiu nieko");

            thirdWordList.Add("Serveris veikia");
            thirdWordList.Add("Ubuntu sistema");
            thirdWordList.Add("Kietas kartonas");
            thirdWordList.Add("Lenta ne malka");
            
            firstWordList.Add("proin elementum");
            firstWordList.Add("aliquam faucibus");
            firstWordList.Add("quisque imperdiet");
            firstWordList.Add("eleifend elit");

            secondWordList.Add("vel malesuada");
            secondWordList.Add("mauris aliquet");
            secondWordList.Add("tempor sit");
            secondWordList.Add("sed gravida");

            thirdWordList.Add(" sollicitudin eget");
            thirdWordList.Add("odio porta");
            thirdWordList.Add("consectetur auctor");
            thirdWordList.Add("rhoncus tristique");
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