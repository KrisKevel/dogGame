using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DogController : MonoBehaviour
{
    public static DogController Instance;

    public float MovementSpeed;
    public float dayLenght = 120;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D dogsRigidBody;
    private Animator animator;

    private bool movementSideways; 
    private bool movementAway;
    private bool movementTowards;

    private float _dayTimeLeft;
    private Vector3 _movementDirection = Vector3.zero;

    private void Awake()
    {
        Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        dogsRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        _dayTimeLeft = dayLenght;
        movementSideways = false;
        movementAway = false;
        movementTowards = false;
    }

    void Update()
    {
        float moveY = 0f;
        float moveX = 0f;

        if (Input.GetKey("w"))
        {
            movementAway = true;
            animator.SetBool("WalkAway", movementAway);
            moveY = +1f;
        }
        if (Input.GetKey("s"))
        {
            movementTowards = true;
            animator.SetBool("WalkTowards", movementTowards);
            moveY = -1f;
        }
        if (Input.GetKey("d"))
        {
            movementSideways = true;
            animator.SetBool("WalkSide", movementSideways);
            //Change sprite orientation accordingly to movement direction
            if (!spriteRenderer.flipX)
            {
                spriteRenderer.flipX = true;
            }

            moveX = +1f;
        }
        if (Input.GetKey("a"))
        {
            movementSideways = true;
            animator.SetBool("WalkSide", movementSideways);
            //Change sprite orientation accordingly to movement direction
            if (spriteRenderer.flipX)
            {
                spriteRenderer.flipX = false;
            }

            moveX = -1f;
        }

        if (!movementSideways)animator.SetBool("WalkSide", movementSideways);
        else movementSideways = false;

        if (!movementAway) animator.SetBool("WalkAway", movementAway);
        else movementAway = false;

        if (!movementTowards) animator.SetBool("WalkTowards", movementTowards);
        else movementTowards = false;


        _movementDirection = new Vector3(moveX, moveY).normalized;

        if (_movementDirection.magnitude != 0)
        {
            DogBehaviour.Instance.UnsetAction();
        }

        _dayTimeLeft -= Time.deltaTime;
        if(_dayTimeLeft <= 0)
        {
            //Switch the day
        }
    }

    private void FixedUpdate()
    {
        dogsRigidBody.MovePosition(transform.position + _movementDirection * MovementSpeed * Time.deltaTime);
    }

    void OnTriggerEnter()
    {
        //Object interaction
    }
}