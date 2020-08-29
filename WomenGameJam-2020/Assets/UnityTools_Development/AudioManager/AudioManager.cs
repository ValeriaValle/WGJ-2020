using UnityEngine;
using UnityEngine.UI;
using UnityTools.ScriptableVariables;

public class AudioManager : MonoBehaviour
{
    [Header("Volume Values")]
    public GenericFloat musicVolume;
    public GenericFloat sfxVolume;

    [Header("Volume Sliders")]
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider sfxSlider;


    private AudioSource aSourceMusic;
    private AudioSource aSourceSFX;

    private void Start()
    {
        aSourceMusic = GameObject.FindWithTag("Audio/Music").GetComponent<AudioSource>();
        aSourceMusic.volume = musicVolume.var;
        musicSlider.value = musicVolume.var;

        aSourceSFX = GameObject.FindWithTag("Audio/SFX").GetComponent<AudioSource>();
        aSourceSFX.volume = sfxVolume.var;
        sfxSlider.value = sfxVolume.var;
    }

    public void AdjustMusicVolume()
    {
        musicVolume.var = musicSlider.value;
        aSourceMusic.volume = musicVolume.var;
    }

    public void AdjustSFXVolume()
    {
        sfxVolume.var = sfxSlider.value;
        aSourceSFX.volume = sfxVolume.var;
    }
}
