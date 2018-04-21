using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    private float lastHitTime = 0f;
    public HealthController hpControl;

    //private SpriteRenderer spriteRenderer;
    //private Animator animator;

    // Use this for initialization
    void Awake()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (((lastHitTime + 0.5f) < Time.time) && other.name.StartsWith("Enemy"))
        {
            lastHitTime = Time.time;
            hpControl.healthSub(10);
        }
    }

    private void OnTriggerEntry2D(Collider2D other)
    {
        if (other.name.StartsWith("Enemy"))
        {
            lastHitTime = Time.time;
            hpControl.healthSub(10);
        }
    }


    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        

        /*bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);*/

        targetVelocity = move * maxSpeed;
    }
}