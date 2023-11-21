using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] int newX;
    [SerializeField] int newY;
    private GameObject player;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            player.transform.position = new Vector3(newX, newY, 0);
        }
    }
}
