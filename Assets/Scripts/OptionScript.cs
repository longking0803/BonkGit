using UnityEngine;
using UnityEngine.Audio;

public class OptionScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;   

    //Resolution[] resolutions;

    //private void Start()
    //{
    //    resolutions = Screen.resolutions;


    //}
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
