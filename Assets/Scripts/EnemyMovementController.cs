using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovementController : PhysicsObject
{
    public float speed = 5f;
    private List<int> directions = new List<int> {-1, 1};
    public int direction = -1;
    private SpriteRenderer spriteRenderer;

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
        else if (other.name == "Player")
        {
            Rigidbody2D prb = other.GetComponent<Rigidbody2D>();
            Vector2 moveAside = new Vector2(direction * 3, 2);
            prb.AddForceAtPosition(moveAside, prb.transform.position, ForceMode2D.Impulse);
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
