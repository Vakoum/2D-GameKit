using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedrunManager : MonoBehaviour
{
    [SerializeField]
    private SaveTime saveTime;

    private float currentTime = 0;


    void Update()
    {
        SetCurrentTime();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SaveTime();
        }
    }

    private void SetCurrentTime()
    {
        currentTime = Time.time;
    }
    public void SaveTime()
    {
        saveTime.AddTime(currentTime);
    }
}
