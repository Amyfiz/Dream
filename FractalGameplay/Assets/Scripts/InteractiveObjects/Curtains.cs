using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Curtains : MonoBehaviour
{
    private Collider2D clldr;
    private Player player;
    
    void Awake()
    {
        clldr = gameObject.GetComponent<Collider2D>();
        player = GameObject.FindObjectOfType<Player>();
    }
    void Update()
    {
        if (clldr.IsTouching(player.GetComponent<Collider2D>()) && Input.GetKeyDown(KeyCode.F))
        {
            Destroy(gameObject);
        }
    }
}
