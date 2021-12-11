using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;
    public AnimationCurve curve;

    public KeyCode jumpKey;


    [Header("JumpCurve")]
    public float jumpSpeed;

    public float curveSpeed;
    public float currentSpeed;
    private bool jumpCurveEnabled;

    public float fallMultiplier;
    public float lowJumpMultiplier;

    [Header("JumpValue")]
    public int jumpValue;
    public int jumpsLeft;


    [Header("Raycast")]
    public bool isGroundet;
    public RaycastHit2D ray;
    public Vector2 rayDir;
    public Vector2 leftRayPos;
    public Vector2 rightRayPos;
    public float rayLength;

    [Header("KayoteTime")]
    public float kayoteDuration;
    public float currentKayoteTime;
    public bool jumpedInAir = false;

    [Header("JumpBuffer")]
    public float jumpBuffer;
    public float currentJumpBuffer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsLeft = jumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    public Vector2 JumpRequirements()
    {
        RaycastHit2D rayleft = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y) + leftRayPos, rayDir, rayLength, LayerMask.GetMask("Ground"));
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y) + leftRayPos, rayDir * rayLength, Color.black);
        RaycastHit2D rayRight = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y) + rightRayPos, rayDir, rayLength, LayerMask.GetMask("Ground"));
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y) + rightRayPos, rayDir * rayLength, Color.black);

        if (rayleft.collider != null || rayRight.collider != null)
        {
            isGroundet = true;
            jumpsLeft = jumpValue;
            currentKayoteTime = kayoteDuration;
            jumpedInAir = false;
        }
        else
        {
            isGroundet = false;
            currentKayoteTime -= Time.deltaTime;
        }


        // change gravity
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && Input.GetKeyUp(KeyCode.K))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        return JumpCurve();
    }


    public Vector2 JumpCurve()
    {
        JumpBuffer();
        if (Input.GetKeyDown(jumpKey))
        {
            if (jumpsLeft > 0 && jumpCurveEnabled == false && currentKayoteTime < 0)
            {
                currentSpeed = 0;
                jumpCurveEnabled = true;
                jumpsLeft--;
            }
            if (isGroundet && jumpCurveEnabled == false || currentKayoteTime > 0 && !jumpedInAir)
            {
                currentSpeed = 0;
                jumpCurveEnabled = true;
                jumpedInAir = true;
            }
        }
        if (Input.GetKeyUp(jumpKey))
        {
            currentSpeed = 0;
            jumpCurveEnabled = false;

        }
        if (Input.GetKey(jumpKey) && jumpCurveEnabled == true)
        {
            currentSpeed = Mathf.Clamp01(currentSpeed + Time.deltaTime * curveSpeed);
            if (currentSpeed == 1)
            {
                 
                return new Vector2(rb.velocity.x, rb.velocity.y);
            }
            return Vector2.up * curve.Evaluate(currentSpeed) * jumpSpeed;
        }
        return new Vector2(rb.velocity.x, rb.velocity.y);
    }

    public void JumpBuffer()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            currentJumpBuffer = jumpBuffer + Time.time;
        }
        if(Input.GetKey(jumpKey) && isGroundet && currentJumpBuffer > Time.time)
        {
            currentSpeed = 0;
            jumpCurveEnabled = true;
            jumpedInAir = true;
        }
    }
}
