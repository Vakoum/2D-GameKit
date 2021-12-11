using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class Loader
{
    private static Action onLoadCallback;

    public static void Load(string scene)
    {
        // Set the loader callback action to load the target scene
        onLoadCallback = () =>
        {
            SceneManager.LoadScene(scene);
        };
        
        // Load the Loading Scene
        SceneManager.LoadScene("Loading");
    }

    public static void LoaderCallback()
    {
        // triggert  after the first update wich lets the scene refresh
        // exicute the loader  callback action wich will load the target scene
        if(onLoadCallback != null)
        {
            onLoadCallback();
            onLoadCallback = null;
        }
    }
}
