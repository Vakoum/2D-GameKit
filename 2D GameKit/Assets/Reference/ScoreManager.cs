using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScoreManager")]
public class ScoreManager : ScriptableObject
{
    [SerializeField]
    private int score;

    private void OnEnable()
    {
        score = 0;
    }
    public void AddScore(int ammount)
    {
        score += ammount;
    }
}
