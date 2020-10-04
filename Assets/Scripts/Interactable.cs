using UnityEngine;

public class Interactable : MonoBehaviour
{
    //Component for interactable objects in the scene
    public float Radius = 3f;
    public DogBehaviour.DogAction action;
    private SpriteRenderer renderer;

    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if ((DogController.Instance.transform.position - transform.position).magnitude < Radius)
        {
            renderer.color = Color.red;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DogBehaviour.Instance.SetAction(action, transform.position);
            }
        } else
        {
            renderer.color = Color.white;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }


}
