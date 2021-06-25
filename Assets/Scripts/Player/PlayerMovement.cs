using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D player;
    [SerializeField] CapsuleCollider2D playerCollider;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private BoxCollider2D bonkerZone;

    [SerializeField] private Animator playerAnim;

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
         //  playerAnim.SetBool("isJumpRoll", true);
           playerAnim.SetBool("isJump", true);
           
        }
        if (!isGrounded)
        {
            // playerAnim.SetBool("isJumpRoll", false);
            playerAnim.SetBool("isJump", false);
        }

        //atk
        if (Input.GetMouseButtonDown(0))
        {
            bonkerZone.enabled = true;
            Debug.Log("ok ok ");
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

        playerAnim.SetFloat("Speed", Mathf.Abs(hInput));

        if (hInput != 0)
        {
            player.velocity = new Vector2(hInput * moveSpeed, player.velocity.y);
            if (hInput > 0)
            {
                transform.rotation = Quaternion.identity;
            }
            else
            {
               
                transform.rotation = Quaternion.Euler(0, 180, 0);
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