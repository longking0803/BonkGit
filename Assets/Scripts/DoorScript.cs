using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private DataManager dataManager;
    [SerializeField] private GameObject image;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == "The Level 2")
            {
                image.SetActive(true);
                //StartCoroutine(wait(20));
            }
            else
            {
                dataManager.NextLevel();
            }
        }
    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        //dataManager.NextLevel();
    }
}
