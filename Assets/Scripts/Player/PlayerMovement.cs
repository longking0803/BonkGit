using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D player;
    [SerializeField] CapsuleCollider2D playerCollider;
    [SerializeField] private LayerMask groundLayerMask;

    //[SerializeField] private Animator playerAnim;

    [Header("Movement Config")]
    [SerializeField] private float moveSpeed;

    [SerializeField] private float jumpForce;
    [SerializeField] private Vector2 checkSize;


    private bool isGrounded;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            player.velocity = Vector2.up * jumpForce;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(transform.position, checkSize, 0f, groundLayerMask);
        GroundMovement();


    }

    void GroundMovement()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        if (hInput != 0)
        {
            player.velocity = new Vector2(hInput * moveSpeed, player.velocity.y);
            if (hInput > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.identity;
            }
        }
    }

    void Jump()
    {

    }



    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, checkSize);
    }
}