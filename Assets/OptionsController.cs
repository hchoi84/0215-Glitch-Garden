using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = default;
    [SerializeField] private float defaultVolume = 0.5f;
    private MusicPlayer musicPlayer;

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    private void Update()
    {
        if(musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
    }

    public void Default()
    {
        volumeSlider.value = defaultVolume;
    }
}
