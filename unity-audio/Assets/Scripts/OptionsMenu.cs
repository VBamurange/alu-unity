
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{

    public Toggle _invertYToggle;
    private string previousScene;
    public Slider BGMSlider;
    public Slider SFXSlider;
    public AudioMixer audioMixer;

    private const string BGM_Volume = "BGMVolume";
    private const string SFX_Volume = "SFXVolume";

    private void Start()
    {
        bool isInverted = PlayerPrefs.GetInt("InvertY", 0) == 1;
        _invertYToggle.isOn = isInverted;

        previousScene = PlayerPrefs.GetString("PreviousScene", "MainMenu");

        float savedVolume = PlayerPrefs.GetFloat(BGM_Volume, 0.75f);
        BGMSlider.value = savedVolume;

        SetBGMVolume(savedVolume);

        float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        SFXSlider.value = savedSFXVolume;

        SetSFXVolume(savedSFXVolume);

        BGMSlider.onValueChanged.AddListener(SetBGMVolume);
        SFXSlider.onValueChanged.AddListener(SetSFXVolume);
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

    private void SetSFXVolume(float volume)
    {
        float dB = Mathf.Log10(volume) * 20;
        audioMixer.SetFloat("SFXVolume", dB);
    }
}
