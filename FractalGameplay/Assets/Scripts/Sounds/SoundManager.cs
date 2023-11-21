using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public PlayerController playerController;
    public AudioSource playerWalkingSound;

    void Awake()
    {
        //playerController = gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerController.isMoving)
        {
            playerWalkingSound.Play();
        }
    }
}
