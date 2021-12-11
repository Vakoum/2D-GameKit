using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public Sentences[] characterSentences;
}

[System.Serializable]
public class Sentences
{
    public Sprite characterPicture1;
    public Sprite characterPicture2;
    public string name;
    public string sentence;
    public float enableContinue;
}
