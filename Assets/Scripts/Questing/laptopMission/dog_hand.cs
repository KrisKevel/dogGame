using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog_hand : MonoBehaviour
{
    private Vector3 _movementDirection = Vector3.zero;
    private Rigidbody2D dogsRigidBody;
    public float MovementSpeed;
    public GameObject ignoreWhenSpace;
    public GameObject otherHand;
    public GameObject[] boundModels;
    //public GameObject[] ignoreObjects;


    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;

    private void Awake()
    {
        //Instance = this;
        //spriteRenderer = GetComponent<SpriteRenderer>();
        dogsRigidBody = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(otherHand.GetComponent<PolygonCollider2D>(), GetComponent<PolygonCollider2D>());
        for (int i = 0; i < boundModels.Length; i++)
        {
            Physics2D.IgnoreCollision(boundModels[i].GetComponent<BoxCollider2D>(), GetComponent<PolygonCollider2D>());
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        float moveY = 0f;
        float moveX = 0f;

        if (Input.GetKey(up))
        {
            //movementAway = true;
            //animator.SetBool("WalkAway", movementAway);
            moveY = +1f;
        }
        if (Input.GetKey(down))
        {
            //movementTowards = true;
            //animator.SetBool("WalkTowards", movementTowards);
            moveY = -1f;
        }
        if (Input.GetKey(right))
        {
            /*movementSideways = true;
            animator.SetBool("WalkSide", movementSideways);
            //Change sprite orientation accordingly to movement direction
            if (!spriteRenderer.flipX)
            {
                spriteRenderer.flipX = true;
            }*/

            moveX = +1f;
        }
        if (Input.GetKey(left))
        {
            /*movementSideways = true;
            animator.SetBool("WalkSide", movementSideways);
            //Change sprite orientation accordingly to movement direction
            if (spriteRenderer.flipX)
            {
                spriteRenderer.flipX = false;
            }*/

            moveX = -1f;
        }

        /*
        if (!(Input.GetKey("space")))
        {
            Physics2D.IgnoreCollision(ignoreWhenSpace.GetComponent<PolygonCollider2D>(), GetComponent<PolygonCollider2D>());
        } else
        {
            Physics2D.IgnoreCollision(ignoreWhenSpace.GetComponent<PolygonCollider2D>(), GetComponent<PolygonCollider2D>(), false);
        }*/

        _movementDirection = new Vector3(moveX, moveY).normalized;


    }

    private void FixedUpdate()
    {
        // KEEP PAWS INBOUNDS.

        if ((dogsRigidBody.position.y >= -2.1 & _movementDirection.y > 0)||(dogsRigidBody.position.y <= -6.1 & _movementDirection.y < 0))
        {
            _movementDirection.y = 0f;
        }

        if((dogsRigidBody.position.x <= -10 & _movementDirection.x < 0) || (dogsRigidBody.position.x >= 10 & _movementDirection.x > 0))
        {
            _movementDirection.x = 0f;
        }

        dogsRigidBody.MovePosition(transform.position + _movementDirection * MovementSpeed * Time.deltaTime);
    }


}
