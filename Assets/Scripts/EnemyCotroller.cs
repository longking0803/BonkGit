using UnityEngine;

public class EnemyCotroller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        if (collision.gameObject.CompareTag("Player"))
        {
           //Debug.Log(collision.name);
           Destroy(gameObject);
        }
    }
    public void die()
    {
        Destroy(gameObject);
    }
}
