using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour, IInteractable
{
    private Collider2D clldr;
    private Player player;  
    


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
        if (clldr.IsTouching(player.GetComponent<Collider2D>()) && Input.GetKeyDown(KeyCode.F))
        {
            //Instantiate(gameObject.GetComponent<Text>());
        }
    }

    
}
