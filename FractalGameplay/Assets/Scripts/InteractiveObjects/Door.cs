using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] int newX;
    [SerializeField] int newY;

    private Collider2D collider;
    private Player player;

    void Awake()
    {
        collider = gameObject.GetComponent<Collider2D>();
        player = GameObject.FindObjectOfType<Player>();
    }


    void Update()
    {
        Interact();
    }


    public void Interact()
    {
        if (collider.IsTouching(player.GetComponent<Collider2D>()))
        {
            Debug.Log("touching");
            if (Input.GetKeyDown(KeyCode.F))
            {
                player.transform.position = new Vector3(newX, newY, player.transform.position.z);
            }
        }
    }
}
