using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovementController : PhysicsObject
{
    public float speed = 5f;
    private List<int> directions = new List<int> {-1, 1};
    public int direction = -1;

    void Start()
    {
        // ---- Parent Constructor ----
        // (coz I am a lazy sucker and will suffer for my sins)
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
        // ---------------------------

        direction *= MaybeModifyDirection();
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
            // TODO: make the player bounce a bit
            return;
            // Rigidbody2D prb = other.GetComponent<Rigidbody2D>();
            // Vector2 moveAside = Vector2.zero;
            // moveAside.x += targetVelocity.x * 20;
        }
        else
        {
            direction *= MaybeModifyDirection();
        }
    }

    private int MaybeModifyDirection()
    {
        return directions[Random.Range(0, 2)];
    }
}
