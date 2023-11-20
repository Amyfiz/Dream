using UnityEngine;

public class Player : MonoBehaviour
{
    //variables for moving player left and right
    [SerializeField] public float playerSpeed;
    [SerializeField] public float moveInput;
    
    //variable for flipping player texture
    [SerializeField] public bool facingRight = true;
    [SerializeField] public bool isGrounded = true;
    [SerializeField] public Transform feetPosition;
    [SerializeField] public float checkRadius;
    [SerializeField] public LayerMask whatIsGrounded;
}