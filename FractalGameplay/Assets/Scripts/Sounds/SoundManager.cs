using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public PlayerController playerController;
    public AudioSource playerWalkingSound;

    void Update()
    {
        if (playerController.isMoving)
            playerWalkingSound.enabled = true;
        else
            playerWalkingSound.enabled = false;
    }
}
