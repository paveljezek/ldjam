using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovementController : PhysicsObject
{
    public float speed = 5f;
    public int direction = -1;

    private SpriteRenderer spriteRenderer;
    private List<int> directions = new List<int> { -1, 1 };

    void Start()
    {
        // ---- Parent Constructor ----
        // (coz I am a lazy sucker and will suffer for my sins)
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
        // ---------------------------

        direction *= MaybeModifyDirection();

        spriteRenderer = GetComponent<SpriteRenderer>();
        FlipSprite();
    }

    protected override void ComputeVelocity()
    {
        targetVelocity.x = speed * direction;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Player")
        {
            Rigidbody2D prb = other.rigidbody;
            Vector2 moveAside = new Vector2(direction * 3, 2);
            prb.AddForceAtPosition(moveAside, prb.transform.position, ForceMode2D.Impulse);

            direction *= -1;
        }
     }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "LeftBouncer")
        {
            direction = 1;
        }
        else if (other.name == "RightBouncer")
        {
            direction = -1;
        }
        else if (other.tag == "Player")
        {
            
        }
        else
        {
            direction *= MaybeModifyDirection();
        }

        FlipSprite();
    }

    private int MaybeModifyDirection()
    {
        return directions[Random.Range(0, 2)];
    }

    void FlipSprite()
    {
        if (direction > 0)
            spriteRenderer.flipX = true;
        else if (direction < 0)
            spriteRenderer.flipX = false;
    }
}
