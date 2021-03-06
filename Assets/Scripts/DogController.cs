﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DogController : MonoBehaviour
{
    public static DogController Instance;

    public float MovementSpeed;
    private float _movementSpeed;
    public float dayLenght = 120;

    public bool asleep;

    private float _sus;
    public float Suspicion
    {
        get
        {
            return _sus;
        }
        set
        {
            _sus = Mathf.Clamp(value, 0, 1);
            UIController.Instance.SetSuspicious(_sus);
        }
    }

    public bool _chase;
    public bool Chase
    {
        set
        {
            _chase = value;
            animator.SetBool("Chase", value);
        }
        get
        {
            return _chase;
        }
    }

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D dogsRigidBody;
    private Animator animator;

    private bool movementSideways; 
    private bool movementAway;
    private bool movementTowards;

    private int _dayCount;
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
        _dayCount = 0;
        _dayTimeLeft = dayLenght;
        movementSideways = false;
        movementAway = false;
        movementTowards = false;
        _movementSpeed = MovementSpeed;
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

        if (!movementSideways) animator.SetBool("WalkSide", movementSideways);
        else movementSideways = false;

        if (!movementAway) animator.SetBool("WalkAway", movementAway);
        else movementAway = false;

        if (!movementTowards) animator.SetBool("WalkTowards", movementTowards);
        else movementTowards = false;


        _movementDirection = new Vector3(moveX, moveY).normalized;

        if (_movementDirection.magnitude * _movementSpeed > 0)
        {
            Chase = false;
            animator.SetBool("Sleep", false);
            DogBehaviour.Instance.UnsetAction();
        }

        _dayTimeLeft -= Time.deltaTime;
        if(_dayTimeLeft <= 0)
        {
            //Switch the day
            _dayCount++;
        }
    }

    private void FixedUpdate()
    {
        dogsRigidBody.MovePosition(transform.position + _movementDirection * _movementSpeed * Time.deltaTime);
    }

    public void Sleep()
    {
        asleep = true;
        animator.SetBool("Sleep", asleep);
        Debug.Log("sleep");
    }

    public void StopMovement()
    {
        _movementSpeed = 0;
    }

    public void ResumeMovement()
    {
        _movementSpeed = MovementSpeed;
    }

}