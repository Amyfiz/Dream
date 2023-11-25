using UnityEngine;

public class CurtainsBreak : MonoBehaviour
{
    public GameObject closeCurtains;
    public GameObject openCurtains;
    public GameObject breakCurtains;
    private Player player;
    private Animator interactAnimation;
    private bool canInteract;
    private int counter = 0;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        interactAnimation = GameObject.Find("Interact")?.GetComponent<Animator>();
    }

    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }

        if (counter == 10)
        {
            closeCurtains.SetActive(false);
            openCurtains.SetActive(false);
            breakCurtains.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player.GetComponent<Collider2D>())
        {
            canInteract = true;
            interactAnimation.SetBool("IsOpen", true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other == player.GetComponent<Collider2D>())
        {
            canInteract = false;
            interactAnimation.SetBool("IsOpen", false);
        }
    }

    public void Interact()
    {
        if (counter < 10)
        {
            if (closeCurtains.activeSelf)
            {
                closeCurtains.SetActive(false);
                openCurtains.SetActive(true);
            } 
            else
            {
                openCurtains.SetActive(false);
                closeCurtains.SetActive(true);
            }
        }
        
        counter++;
    }
}


