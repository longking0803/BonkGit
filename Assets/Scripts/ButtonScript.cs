using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hoverSound, selectSound;

    public void PlayHoverSound()
    {
        audioSource.PlayOneShot(hoverSound);
    }
    public void PlaySelectSound()
    {
        audioSource.PlayOneShot(selectSound);
    }
}
