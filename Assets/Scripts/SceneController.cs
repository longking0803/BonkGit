using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject popup;

    private bool toggle = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        toggle = !toggle;

        popup.SetActive(toggle);
        Time.timeScale = toggle ? 0f : 1f;
    }
}
