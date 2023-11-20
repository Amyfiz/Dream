using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rigidbody;
    //private Animator animator;

    //get component Rigidbody when game started
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rigidbody = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        player.isGrounded =
            Physics2D.OverlapCircle(player.feetPosition.position, player.checkRadius, player.whatIsGrounded);

        rigidbody.velocity = new Vector2(player.moveInput * player.playerSpeed, rigidbody.velocity.y);

        //animator.SetBool("IsMoving", player.moveInput * player.playerSpeed != 0);

    }

    //flipping player texture
    private void PlayerFlip()
    {
        player.facingRight = !player.facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void FixedUpdate()
    {
        player.moveInput = Input.GetAxis("Horizontal");

        //flipping player according to side they're facing
        if (!player.facingRight && player.moveInput > 0)
            PlayerFlip();
        else if (player.facingRight && player.moveInput < 0)
            PlayerFlip();
    }
}