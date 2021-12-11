using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SaveTime")]
public class SaveTime : ScriptableObject
{
    public float Time;
    private bool timerEnabled = true;

    public void AddTime(float timeToAdd)
    {
        if (Enabled())
        {
            Time += timeToAdd;
        }
    }
    public float GetTime()
    {
        return Time;
    }
    public void ResetTime()
    {
        Time = 0;
    }
    public bool Enabled()
    {
        return timerEnabled;
    }
    public void DisEnable(bool enabled)
    {
        timerEnabled = enabled;
    }
}
