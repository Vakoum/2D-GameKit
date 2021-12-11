using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    int firstButton = 0;

    public int InputDir(KeyCode positive, KeyCode negative)
    {
        if(Input.GetKeyDown(negative) && firstButton == 0)
        {
            firstButton = 1;
        }
        if (Input.GetKeyDown(positive) && firstButton == 0)
        {
            firstButton = 2;
        }
        if (Input.GetKeyUp(negative) && Input.GetKey(positive))
        {
            firstButton = 2;
        }
        if (Input.GetKeyUp(positive) && Input.GetKey(negative))
        {
            firstButton = 1;
        }
        if (Input.GetKeyUp(negative) && !Input.GetKey(positive))
        {
            firstButton = 0;
        }
        if (Input.GetKeyUp(positive) && !Input.GetKey(negative))
        {
            firstButton = 0;
        }
        if (Input.GetKey(negative) && firstButton == 2 || Input.GetKey(negative) && !Input.GetKey(positive))
        {
            return -1;
        }
        if (Input.GetKey(positive) && firstButton == 1 || Input.GetKey(positive) && !Input.GetKey(negative))
        {
            return 1;
        }
        return 0;
    }
}
