using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DogController : MonoBehaviour
{
    public float MovementSpeed;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;

    private Vector3 _movementDirection = Vector3.zero;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();  
    }

    void Start()
    {
    }

    void Update()
    {
        float moveY = 0f;
        float moveX = 0f;

        if (Input.GetKey("w"))
        {
            moveY = +1f;
        }
        if (Input.GetKey("s"))
        {
            moveY = -1f;
        }
        if (Input.GetKey("d"))
        {
            //Change sprite orientation accordingly to movement direction
            if (!spriteRenderer.flipY)
            {
                spriteRenderer.flipY = true;
            }

            moveX = +1f;
        }
        if (Input.GetKey("a"))
        {
            //Change sprite orientation accordingly to movement direction
            if (spriteRenderer.flipY)
            {
                spriteRenderer.flipY = false;
            }

            moveX = -1f;
        }

        _movementDirection = new Vector3(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(transform.position + _movementDirection * MovementSpeed * Time.deltaTime);
    }
}
