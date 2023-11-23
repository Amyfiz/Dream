using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] int newX;
    [SerializeField] int newY;

    private Collider2D clldr;
    private Player player;

    private Animator transition;
    [SerializeField] float transitionTime;

    void Awake()
    {
        clldr = gameObject.GetComponent<Collider2D>();
        player = GameObject.FindObjectOfType<Player>();
        transition = GameObject.Find("Fade")?.GetComponent<Animator>();
    }
    
    void Update()
    {
        Interact();
    }
    
    public void Interact()
    {
        if (clldr.IsTouching(player.GetComponent<Collider2D>()) && Input.GetKeyDown(KeyCode.F))
        {
            TeleportPlayer();
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
