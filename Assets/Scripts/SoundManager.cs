using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip playerAttackHitSound,mainThemeSound;
    
    private void Start()
    {
        audioSource.PlayOneShot(mainThemeSound,0.5f);
    }
    public void PlaySound(string name)
    {
        switch (name)
        {
            case "playerAttackHitSound":
                audioSource.PlayOneShot(playerAttackHitSound);
                break;
            default:
                break;
        }
    }
}
