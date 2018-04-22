using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    public List<AnimatorController> idleAnimationControllers;
    public List<AnimatorController> walkingAnimationControllers;
    public List<AnimatorController> attackingAnimationControllers;

    private SpriteRenderer spriteRenderer;
    private WeaponController weaponController;
    private Animator animator;

    public enum MovementState
    {
        Idle,
        Walking,
        Attacking
    }

    protected MovementState moveState = MovementState.Idle;


    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        weaponController = GetComponent<WeaponController>();
        animator = GetComponentInChildren<Animator>();
    }

    private int getCurrentWeapon()
    {
        return (int)weaponController.getCurrentWeapon();
    }

    public void setAccordingWeaponAnimation(WeaponController.Weapons wepType)
    {
        switch (moveState) {
            case MovementState.Idle:
                animator.runtimeAnimatorController = idleAnimationControllers[getCurrentWeapon()];
            break;
            case MovementState.Walking:
                animator.runtimeAnimatorController = walkingAnimationControllers[getCurrentWeapon()];
            break;
            case MovementState.Attacking:
                animator.runtimeAnimatorController = walkingAnimationControllers[getCurrentWeapon()];
            break;
            default:
                print("Go home computer, you're drunk.");
            break;
        }
    }

    public void setAnimationState(MovementState ms)
    {
        // TODO: allow locking so that, e.g. attack animations get finished?

        // don't restart the animation if already running
        if (moveState == ms)
            return;

        moveState = ms;
        switch(ms)
        {
            case MovementState.Idle:
                animator.runtimeAnimatorController = idleAnimationControllers[getCurrentWeapon()];
                break;
            case MovementState.Walking:
                animator.runtimeAnimatorController = walkingAnimationControllers[getCurrentWeapon()];
                break;
            case MovementState.Attacking:
                animator.runtimeAnimatorController = walkingAnimationControllers[getCurrentWeapon()];
                break;
            default:
                print("Go home computer, you're drunk.");
                break;
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

        if(spriteRenderer != null)
        {
            if (move.x > 0.05f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.05)
                spriteRenderer.flipX = true;
        }

        targetVelocity = move * maxSpeed;
        if (Mathf.Abs(move.x) < 0.05f) 
        {
            setAnimationState(MovementState.Idle);
        }
        else
        {
            setAnimationState(MovementState.Walking);
        }

    }
}