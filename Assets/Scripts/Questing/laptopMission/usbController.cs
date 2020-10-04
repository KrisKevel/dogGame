using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usbController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject triggerStuckObject;
    public Vector2 stuckToPosition;
    public float stuckToRotation;
    public GameObject screen_one;

    private bool waitAFrame;
    private Rigidbody2D mycomponent;
    private Rigidbody2D collidedTrueIs;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (collidedTrueIs)
        {

            mycomponent.position = stuckToPosition;
            mycomponent.rotation = stuckToRotation;
            mycomponent.Sleep();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == triggerStuckObject)
        {
            // OBJECTIVE COMPLETED!
            //Physics2D.IgnoreCollision(GetComponent<PolygonCollider2D>(), triggerStuckObject.GetComponent<BoxCollider2D>());
            mycomponent = collision.gameObject.GetComponent<Rigidbody2D>();
            
            //mycomponent.gravityScale = 0f;
            mycomponent.position = stuckToPosition;
            mycomponent.rotation = stuckToRotation;

            collidedTrueIs = mycomponent;
            waitAFrame = true;
            //mycomponent.Sleep();


            // Disable password screen;
            screen_one.SetActive(false);


        }
    }
}
