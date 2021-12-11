using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAddScore : MonoBehaviour
{
    [SerializeField]
    private ScoreManager scoreManager;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddScore();
        }   
    }

    private void AddScore()
    {
        scoreManager.AddScore(1);
    }
}
