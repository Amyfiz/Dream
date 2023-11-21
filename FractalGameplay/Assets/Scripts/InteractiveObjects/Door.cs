using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] int newX;
    [SerializeField] int newY;

    private Collider2D clldr;
    private Player player;

    void Awake()
    {
        clldr = gameObject.GetComponent<Collider2D>();
        player = GameObject.FindObjectOfType<Player>();
    }
    
    void Update()
    {
        Interact();
    }
    
    public void Interact()
    {
        if (clldr.IsTouching(player.GetComponent<Collider2D>()))
        {
            //Debug.Log("touching");
            if (Input.GetKeyDown(KeyCode.F))
            {
                player.transform.position = new Vector3(newX, newY, player.transform.position.z);
                Debug.Log("im working bitch");
            }
        }
    }
}
