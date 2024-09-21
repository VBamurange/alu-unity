
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{

    public Toggle _invertYToggle;
    private string previousScene;
    public Slider BGMSlider;
    public AudioMixer audioMixer;

    private const string BGM_Volume = "BGMVolume";

    private void Start()
    {
        bool isInverted = PlayerPrefs.GetInt("InvertY", 0) == 1;
        _invertYToggle.isOn = isInverted;

        previousScene = PlayerPrefs.GetString("PreviousScene", "MainMenu");

        float savedVolume = PlayerPrefs.GetFloat(BGM_Volume, 0.75f);
        BGMSlider.value = savedVolume;

        SetBGMVolume(savedVolume);
    }

    public void Apply()
    {
        bool isInverted = _invertYToggle.isOn;
        PlayerPrefs.SetInt("InvertY", isInverted ? 1 : 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene(previousScene);
    }
  
    public void Back()
    {
        SceneManager.LoadScene(previousScene);
    }

    public void OnBGMVolumeChanged(float volume)
    {
        SetBGMVolume(volume);

        PlayerPrefs.SetFloat(BGM_Volume, volume);
        PlayerPrefs.Save();
    }

    private void SetBGMVolume(float volume)
    {
        float dB = Mathf.Log10(volume) * 20;
        if (volume == 0) dB = -80;

        audioMixer.SetFloat("BGMVolume", dB);
    }
}
