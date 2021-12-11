using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Anim")]
public class Anim : ScriptableObject
{
    public bool speedbased;

    public Anims[] anims;
}

[System.Serializable]
public class Anims
{
    public string animName;
    public float animSpeed;
    public AnimationCurve animFrameSpeed;
    public Sprite[] sprites;
    public int[] funktions; // first is funktion and second their ative frames
}
