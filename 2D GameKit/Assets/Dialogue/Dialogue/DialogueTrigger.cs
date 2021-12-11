using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool colides;

    private void Update()
    {
        if(colides == true && Input.GetKeyDown(KeyCode.T))
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            colides = true;
        }
        else
        {
            colides = false;
        }
    }
}
