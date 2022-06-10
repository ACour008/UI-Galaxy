using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Root
{
    public OjibweNameBuilder OjibweNameCreator = new OjibweNameBuilder();
    public EnglishNameBuilder EnglishNameCreator = new EnglishNameBuilder();

    public NameBuilder GetStarNamesFor(Language language)
    {
        if (language == Language.OJIBWE)
        {
            return OjibweNameCreator;
        }
        else
        {
            return EnglishNameCreator;
        }
    }
}
