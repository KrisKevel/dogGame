using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    public float MovementSpeed;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
    }

    void Update()
    {

        //Movement
        Vector2 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += MovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= MovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            //Change sprite orientation accordingly to movement direction
            if (!spriteRenderer.flipY)
            {
                spriteRenderer.flipY = true;
            }

            pos.x += MovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            //Change sprite orientation accordingly to movement direction
            if (spriteRenderer.flipY)
            {
                spriteRenderer.flipY = false;
            }

            pos.x -= MovementSpeed * Time.deltaTime;
        }

        transform.position = pos;

        
    }
}
