using UnityEngine;

public class Jump1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public AnimationCurve curve;

    public float jumpSpeed;

    public float curveSpeed;
    private float currentSpeed;

    public float fallMultiplier;
    public float lowJumpMultiplier;

    public int jumpValue;
    public int jumpsLeft;

    public bool isGroundet;
    


    public RaycastHit2D ray;

    private void Start()
    {
        jumpsLeft = jumpValue;
    }

    void Update()
    {
        isGroundet = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("Ground"));

        if (isGroundet)
        {
            jumpsLeft = jumpValue;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if(jumpsLeft > 0)
            {
                currentSpeed = 0;
                jumpsLeft--;
            }
            if(isGroundet)
            {
                currentSpeed = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            currentSpeed = 0;
        }
        if (Input.GetKey(KeyCode.K))
        {
            currentSpeed = Mathf.Clamp01(currentSpeed + Time.deltaTime * curveSpeed);
            if(currentSpeed == 1)
            {
                return;
            }
            rb.velocity = Vector2.up * curve.Evaluate(currentSpeed) * jumpSpeed;
        }

        // change gravity
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && Input.GetKeyUp(KeyCode.K))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }


}
