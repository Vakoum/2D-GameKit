using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public string nextScene;
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (AnimationFinished())
        {
            LoadScene(nextScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("EndLevel");
        }
    }

    public bool AnimationFinished()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Nextscene") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            return true;
        }

        return false;
    }

    public void LoadScene(string scene)
    {
        Loader.Load(scene);
    }
}
