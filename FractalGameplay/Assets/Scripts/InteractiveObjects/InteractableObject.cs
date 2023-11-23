using System;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractableObject : MonoBehaviour, IInteractable
{
    private Collider2D clldr;
    private Player player;
    private GameObject openObject;
    
    public Animator interactAnimation;
    public Animator dialogueBoxAnimation;
    public 
    
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
        if (clldr.IsTouching(player.GetComponent<Collider2D>()))
        {
            interactAnimation.SetBool("IsOpen", true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (openObject.GetComponent<DialogueAnimator>())
                {
                    Debug.Log("Тут будет диалог, но мне его лень делать");
                }
                else
                {
                    //Делать неебенную хуйню так шоб все ахуели
                    openObject.gameObject.SetActive(true);
                    interactAnimation.SetBool("IsOpen", false);
                    Debug.Log("boom");
                    //А еще разрушать объект после этого
                }
            }
        }
        else
        {
            interactAnimation.SetBool("IsOpen", false);
        }

        if (openObject.gameObject.activeSelf)
        {
            interactAnimation.SetBool("IsOpen", false);
        }
    }

    
}
