using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject options;
    private Respawn respawn;
    public SaveTime speedrun;

    public bool optionsOpen = false;

    private void Start()
    {
        respawn = GameObject.Find("Player").GetComponent<Respawn>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !optionsOpen)
        {
            OpenOptions();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && optionsOpen)
        {
            CloseOptions();
            return;
        }
    }

    public void OpenOptions()
    {
        options.SetActive(true);
        optionsOpen = true;
        Time.timeScale = 0;
    }
    public void CloseOptions()
    {
        options.SetActive(false);
        Time.timeScale = 1;
        optionsOpen = false;
    }

    public void GoToMenu()
    {
        Loader.Load("MainMenu");
        speedrun.DisEnable(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        StartCoroutine(respawn.Die());
    }
    public void Quit()
    {
        Application.Quit();
    }
}
