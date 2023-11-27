using UnityEngine;

public class Quit : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player.GetComponent<Collider2D>())
        {
            Application.Quit();
            Debug.Log("I quit...");
        }
    }
}
