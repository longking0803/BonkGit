using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D player;
    [SerializeField] CapsuleCollider2D playerCollider;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private LayerMask enemiesLayerMask;
    [SerializeField] private BoxCollider2D bonkerZone;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator playerAnim;

    [Header("Movement Config")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Vector2 checkSize;
    [SerializeField] private float attackRadius;

    private float hInput;
    private bool doubleJumpReady;
    private bool frameGrounded;
    

    private void Update()
    {
        
        handleInput();
    }

    private void physicsCheck()
    {
        frameGrounded = Physics2D.OverlapBox(transform.position, checkSize, 0f, groundLayerMask);
        if (frameGrounded)
        {
            playerAnim.SetBool("isJumpRoll", false);
            playerAnim.SetBool("isJump", false);
        }
        //if (!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        //{
        //    bonkerZone.enabled = false;
        //}
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
                transform.rotation = Quaternion.identity;
            }
            else
            {

                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        //atk
        if (Input.GetMouseButtonDown(0))
        {
            playerAnim.SetTrigger("isAttack");
            //attack();
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
            playerAnim.SetTrigger("isJumpRoll 0");
            //playerAnim.SetBool("isJumpRoll", true);
            doubleJumpReady = false;
        }
    }

    private bool isGrounded()
    {
        float doubleJumpTriggerHeight = 0f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, doubleJumpTriggerHeight, groundLayerMask);
        return raycastHit.collider != null;
    }

    public void AlertObservers(string message)
    {
        if (message.Equals("AttackAnimationEnded"))
        {
            bonkerZone.enabled = false;
            // Do other things based on an attack ending.
        }
    }

    private void attackEnded()
    {
        bonkerZone.enabled = false;
    }

    public void attack()
    {
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position+new Vector3(1f,0f,0f), attackRadius, enemiesLayerMask);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyCotroller>().die();
        }
    }

    // Ctrl + K + C to comment in bulk, Ctrl + K + U to un comment
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode

        //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
        Gizmos.DrawWireCube(transform.position, checkSize);
        Gizmos.DrawWireSphere(transform.position + new Vector3(1f, 0f, 0f), attackRadius);
    }

    private void FixedUpdate()
    {
        //isGrounded = Physics2D.OverlapBox(transform.position, checkSize, 0f, groundLayerMask);
        //GroundMovement();
        physicsCheck();

    }

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