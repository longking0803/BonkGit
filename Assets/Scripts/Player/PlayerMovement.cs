using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D player;
    [SerializeField] CapsuleCollider2D playerCollider;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private BoxCollider2D bonkerZone;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator playerAnim;

    [Header("Movement Config")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Vector2 checkSize;

    private float hInput;
    private bool doubleJumpReady;
    private bool frameGrounded;

    private void Update()
    {
        physicsCheck();
        handleInput();
    }

    private void physicsCheck()
    {
        frameGrounded = isGrounded();
        if (frameGrounded)
        {
            playerAnim.SetBool("isJumpRoll", false);
            playerAnim.SetBool("isJump", false);
        }
    }

    private void handleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

        hInput = Input.GetAxisRaw("Horizontal");
        playerAnim.SetFloat("Speed", Mathf.Abs(hInput));
        if (hInput != 0)
        {
            player.velocity = new Vector2(hInput * moveSpeed, player.velocity.y);
            if (hInput > 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }

        //atk
        if (Input.GetMouseButtonDown(0))
        {
            bonkerZone.enabled = true;
            //Debug.Log("ok ok ");
        }
    }

    void jump()
    {
        if (frameGrounded)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            playerAnim.SetBool("isJump", true);
            doubleJumpReady = true;
        }
        else if (doubleJumpReady)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            playerAnim.SetBool("isJumpRoll", true);
            doubleJumpReady = false;
        }
    }

    private bool isGrounded()
    {
        float doubleJumpTriggerHeight = 0f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, doubleJumpTriggerHeight, groundLayerMask);
        return raycastHit.collider != null;
    }







    // Ctrl + K + C to comment in bulk, Ctrl + K + U to un comment
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode

    //    //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
    //    Gizmos.DrawWireCube(transform.position, checkSize);
    //}

    //private void FixedUpdate()
    //{
    //    //isGrounded = Physics2D.OverlapBox(transform.position, checkSize, 0f, groundLayerMask);
    //    //GroundMovement();


    //}

    //void GroundMovement()
    //{
    //    float hInput = Input.GetAxisRaw("Horizontal");

    //    playerAnim.SetFloat("Speed", Mathf.Abs(hInput));

    //    if (hInput != 0)
    //    {
    //        player.velocity = new Vector2(hInput * moveSpeed, player.velocity.y);
    //        if (hInput > 0)
    //        {
    //            transform.rotation = Quaternion.identity;
    //        }
    //        else
    //        {

    //            transform.rotation = Quaternion.Euler(0, 180, 0);
    //        }
    //    }
    //}
}