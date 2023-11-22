using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    private Collider2D clldr;
    private Player player;  
    
    public Animator startAnimation;
    
    void Awake()
    {
        clldr = gameObject.GetComponent<Collider2D>();
        player = GameObject.FindObjectOfType<Player>();
    }

    public void Update()
    {
        Interact();
    }

    public void Interact()
    {
        if (clldr.IsTouching(player.GetComponent<Collider2D>()))
        {
            startAnimation.SetBool("IsOpen", true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                //Делать неебенную хуйню так шоб все ахуели
                startAnimation.SetBool("IsOpen", false);
                Debug.Log("boom");
                //А еще разрушать объект после этого
            }
        }
        else
        {
            startAnimation.SetBool("IsOpen", false);
        }
    }

    
}
