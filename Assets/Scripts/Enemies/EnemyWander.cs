using UnityEngine;

public class EnemyWander : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    [Header("References")]
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Collider2D enemyWallCheckCollider;

    [Header("Movement Config")]
    [SerializeField] private float wanderSpeed;

    private bool isPatrol;
    private bool isFlip;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        isPatrol = true;
        wanderSpeed = wanderSpeed * -1;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isPatrol)
        {
            isFlip = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
            Patrol();
        }
    }

    private void Patrol()
    {
        if (isFlip || enemyWallCheckCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        enemyRb.velocity = new Vector2(wanderSpeed * Time.fixedDeltaTime, enemyRb.velocity.y);
    }

    private void Flip()
    {
        isPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        wanderSpeed *= -1;
        isPatrol = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireCube(offset, checkSize);
    }
}