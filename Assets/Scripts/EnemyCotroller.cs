using UnityEngine;

public class EnemyCotroller : MonoBehaviour

{
    [SerializeField] private Animator targetAnim;
    [SerializeField] private float health;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //Debug.Log(collision.name);
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        //Debug.Log(collision.name);
    //        //targetAnim.SetTrigger("isDie");

    //    }
    //}

    public void Destroy()
    {
        Destroy(gameObject);

    }
    public void hit()
    {
        health -= 1;
        if (health <= 0)
        {
            targetAnim.SetTrigger("isDie");
        }
    }
}
