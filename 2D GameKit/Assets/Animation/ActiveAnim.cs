using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAnim : MonoBehaviour
{
    [SerializeField]
    private Anim anim;
    private SpriteRenderer spriteRenderer;
    private int currentAnim = 0;


    private int currentSprite = 0;
    private float currentAnimTime = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayAnimation();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeAnim(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeAnim(1);
        }
    }


    public void ChangeAnim(int chosenAnim)
    {
        currentAnim = chosenAnim;
        currentAnimTime = 0;
        currentSprite = 0;
        Debug.Log(currentAnim);
    }


    void PlayAnimation()
    {
        if(Mathf.RoundToInt(anim.anims[currentAnim].animFrameSpeed.Evaluate(currentAnimTime)) >= anim.anims[currentAnim].sprites.Length)
        {
            currentAnimTime = 0;
            currentSprite = 0;
            return;
        }
        if (Mathf.RoundToInt(anim.anims[currentAnim].animFrameSpeed.Evaluate(currentAnimTime)) < anim.anims[currentAnim].sprites.Length)
        {
            Debug.Log(currentSprite);
            currentSprite = Mathf.RoundToInt(anim.anims[currentAnim].animFrameSpeed.Evaluate(currentAnimTime));
            currentAnimTime += Time.deltaTime * anim.anims[currentAnim].animSpeed;
            SetAnimFrame(currentSprite);
        }
    }

    void SetAnimFrame(int sprite)
    {
        spriteRenderer.sprite = anim.anims[currentAnim].sprites[sprite];
        ActivateFunktion();
    }

    void ActivateFunktion()
    {
        for (int i = 0; i < anim.anims[currentAnim].funktions.Length; i++)
        {
            if(anim.anims[currentAnim].funktions[i] == currentSprite)
            {
                // add funktion here
            }
        }
    }
}