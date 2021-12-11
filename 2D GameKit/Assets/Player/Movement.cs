using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public AnimationCurve speedCurve;
    private Controller controller;
    private Jump jump;

    [Header("Speed")]
    public float curveSpeed;
    private float currentSpeed = 0;
    public float walkSpeed;

    [Header("Special")]
    public float rayLength;
    public float wallDisruption;

    public KeyCode left;
    public KeyCode right;
    public KeyCode down;
    public KeyCode up;

    public enum movementTypes
    {
        Platfromer,
        none
    }

    public movementTypes currentMovementType;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<Controller>();
        jump = GetComponent<Jump>();
    }

    void Update()
    {
        
        switch (currentMovementType)
        {
            case movementTypes.Platfromer:
                rb.velocity = new Vector2(Move(Vector2.right, controller.InputDir(right, left)).x, jump.JumpRequirements().y);
                break;
            case movementTypes.none:
                rb.velocity = new Vector2(0, 0);
                break;
        }
    }

    public Vector2 Move(Vector2 dir, float way)
    {
        RaycastHit2D rayleft = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -dir, rayLength, LayerMask.GetMask("Ground"));
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), -dir * rayLength,Color.black);
        RaycastHit2D rayright = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), dir, rayLength, LayerMask.GetMask("Ground"));
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), dir * rayLength, Color.black);


        currentSpeed = Mathf.MoveTowards(currentSpeed, way, Time.deltaTime * curveSpeed);
        if(rayleft.collider != null)
        {
            currentSpeed = Mathf.Clamp(currentSpeed, -wallDisruption, 1f);

        }
        if (rayright.collider != null)
        {
            currentSpeed = Mathf.Clamp(currentSpeed, -1f, wallDisruption);
        }
        float animSpeed = speedCurve.Evaluate(currentSpeed);
        return dir * new Vector2(currentSpeed, currentSpeed) * walkSpeed;
    }
}
