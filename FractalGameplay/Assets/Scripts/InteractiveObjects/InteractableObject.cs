using System;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractableObject : MonoBehaviour, IInteractable
{
    private Collider2D clldr;
    private Player player;
    public GameObject openObject;
    private bool isDialogueBoxOpen;
    private Animator interactAnimation;
    private bool canInteract;

    void Awake()
    {
        clldr = gameObject.GetComponent<Collider2D>();
        player = FindObjectOfType<Player>();
        interactAnimation = GameObject.Find("Interact")?.GetComponent<Animator>();
        openObject = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = true;
            interactAnimation.SetBool("IsOpen", true);
            openObject.gameObject.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = false;
            interactAnimation.SetBool("IsOpen", false);
            openObject.SetActive(false);
            
            if (openObject.GetComponent<DialogueAnimator>() != null)
            {
                openObject.GetComponent<DialogueAnimator>().startAnimation.SetBool("IsOpen", false);
            }
        }
    }

    public void Interact()
    {
        if (openObject.GetComponent<DialogueAnimator>() != null)
        {
            isDialogueBoxOpen = openObject.GetComponent<DialogueAnimator>().startAnimation.GetBool("IsOpen");
        }

        if (!isDialogueBoxOpen)
        {
            interactAnimation.SetBool("IsOpen", false);

            if (openObject.GetComponent<DialogueAnimator>() != null)
            {
                openObject.GetComponent<DialogueAnimator>().Activate();
                Debug.Log("открываем диалог");
            }
            else
            {
                //Делать неебенную хуйню так шоб все ахуели
                interactAnimation.SetBool("IsOpen", false);
                Debug.Log("Закрываем Фку, открываем окошко");
                //А еще разрушать объект после этого
            }
        }
    }
}
