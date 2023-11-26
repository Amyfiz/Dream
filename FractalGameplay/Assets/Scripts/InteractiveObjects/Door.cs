using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] int newX;
    [SerializeField] int newY;

    private Player player;
    private Animator interactAnimation;
    private bool canInteract;

    private Animator transition;
    [SerializeField] float transitionTime;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        transition = GameObject.Find("Fade")?.GetComponent<Animator>();
        interactAnimation = GameObject.Find("Interact")?.GetComponent<Animator>();
    }
    
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.F))
        {
            TeleportPlayer();
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

    public void TeleportPlayer()
    {
        StartCoroutine(Transition());
        player.transform.position = new Vector3(newX, newY, player.transform.position.z);
    }

    IEnumerator Transition()
    {
        transition.SetTrigger("Start");
        transition.SetTrigger("Finish");
        yield return new WaitForSeconds(transitionTime);
    }
}
