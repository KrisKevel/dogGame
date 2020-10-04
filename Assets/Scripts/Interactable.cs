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
            renderer.color = Color.green;
            ActionScript actionScript = GetComponent<ActionScript>();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (DogBehaviour.Instance.CurrentAction == action)
                {
                    DogBehaviour.Instance.UnsetAction();
                    if (actionScript != null)
                    {
                        actionScript.CleanAction();
                    }
                } else
                {
                    DogBehaviour.Instance.SetAction(action, transform.position);
                    if (actionScript != null)
                    {
                        actionScript.PerformAction();
                    }
                }
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
