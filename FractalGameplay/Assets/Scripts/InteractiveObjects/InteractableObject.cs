using System;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractableObject : MonoBehaviour, IInteractable
{
    private Collider2D clldr;
    private Player player;
    private GameObject openObject;
    private bool isDialogueBoxOpen;
    
    public Animator interactAnimation;
    
    void Awake()
    {
        clldr = gameObject.GetComponent<Collider2D>();
        player = FindObjectOfType<Player>();
        openObject = transform.GetChild(0).gameObject;
    }

    public void Update()
    {
        Interact();
    }

    public void Interact()
    {
        if (openObject.GetComponent<DialogueAnimator>() != null)
        {
            isDialogueBoxOpen = openObject.GetComponent<DialogueAnimator>().startAnimation.GetBool("IsOpen");
        }
        
        if (clldr.IsTouching(player.GetComponent<Collider2D>()) && !isDialogueBoxOpen)
        {
            interactAnimation.SetBool("IsOpen", true);
            Debug.Log("Interact");

            if (Input.GetKeyDown(KeyCode.F) && !openObject.activeSelf)
            {
                openObject.gameObject.SetActive(true);

                if (openObject.GetComponent<DialogueAnimator>() != null)
                {
                    Debug.Log("Тут будет диалог, но мне его лень делать");
                    openObject.GetComponent<DialogueAnimator>().Activate();
                }
                else
                {
                    //Делать неебенную хуйню так шоб все ахуели
                    interactAnimation.SetBool("IsOpen", false);
                    Debug.Log("boom");
                    //А еще разрушать объект после этого
                }
            }
        }
        else
        {
            interactAnimation.SetBool("IsOpen", false);
            openObject.SetActive(false);
        }
        
        if (openObject.gameObject.activeSelf || isDialogueBoxOpen)
        {
            interactAnimation.SetBool("IsOpen", false);
        }
    }

    
}
