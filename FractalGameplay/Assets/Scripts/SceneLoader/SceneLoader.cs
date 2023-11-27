using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private Player player;
    private bool canInteract;

    public bool canTP;
    
    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.F) && canTP)
        {
            LoadScene();
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player.GetComponent<Collider2D>())
        {
            canInteract = true;
        }
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other == player.GetComponent<Collider2D>())
        {
            canInteract = false;
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
