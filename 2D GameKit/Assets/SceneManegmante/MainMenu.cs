using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void EnablePage(GameObject toEnable)
    {
        toEnable.SetActive(true);
    }
    public void DisablePage(GameObject toDisable)
    {
        toDisable.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
