using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActivateTimeline : MonoBehaviour
{
    private PlayableDirector director;

    void Start()
    {
        director = GetComponent<PlayableDirector>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            director.Play();
        }
    }
}
