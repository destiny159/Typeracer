using System;
using System.Collections.Generic;

namespace SignalR_GameServer_v1
{
  abstract class AbstractClass
  {
    public  Creator wordCreators = new RandomWordsCreator();
    public Creator randomLettersCreators = new RandomLettersCreator();
    public Creator sentenceCreators = new RandomSentenceCreator();
    public abstract Word GenerateWord();
    public abstract Word GenerateRandomLetters();
    public abstract Word GenerateSentence();
 
    public Word[] TemplateMethod()
    {
        Word[] wordList = new Word[3];
        wordList[0]= GenerateWord();
        wordList[1]= GenerateRandomLetters();
        wordList[2]= GenerateSentence();
        return wordList;
    }

  }

  class FirstLevelWord : AbstractClass
  {
    public override Word GenerateWord()
    {

        return wordCreators.FirstLevel();
    }
    public override Word GenerateRandomLetters()
    {
 
        return randomLettersCreators.FirstLevel();
    }
    public override Word GenerateSentence()
    {

        return sentenceCreators.FirstLevel();
    }
  }
 
  class SecondLevelWord : AbstractClass

  {
     public override Word GenerateWord()
    {
        return wordCreators.SecondLevel();
    }
    public override Word GenerateRandomLetters()
    {
        return randomLettersCreators.SecondLevel();
    }
    public override Word GenerateSentence()
    {
        return sentenceCreators.SecondLevel();
    }
  }

  class ThirdLevelWord : AbstractClass

  {
    public override Word GenerateWord()
    {
        return wordCreators.ThirdLevel();
    }
    public override Word GenerateRandomLetters()
    {
        return randomLettersCreators.ThirdLevel();
    }
    public override Word GenerateSentence()
    {
        return sentenceCreators.ThirdLevel();
    }
  }
}