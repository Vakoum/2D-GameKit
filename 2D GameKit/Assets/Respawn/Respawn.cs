using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private SpriteRenderer sprite;
    private GameObject spawnPoint;
    private Animator anim;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        spawnPoint = GameObject.Find("RespawnPoint");
        anim = GameObject.Find("SpawnAnim").GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Die());
        }
    }
    public IEnumerator Die()
    {
        //Disable importatn player parts
        sprite.enabled = false;
        anim.SetTrigger("Respawn");

        yield return new WaitForSeconds(0.5f);

        CreateAtRespawn();
    }

    private void CreateAtRespawn()
    {
        this.transform.position = spawnPoint.transform.position;
        // Enable playercomponents
        sprite.enabled = true;
    }
}
