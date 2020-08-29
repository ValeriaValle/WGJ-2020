using UnityEngine;
using UnityTools.ScriptableVariables;

public class AudioManager : MonoBehaviour
{
    [Header("Volume Values")]
    public GenericFloat musicVolume = null;
    public GenericFloat sfxVolume = null;

    private AudioSource aSourceMusic;
    private AudioSource aSourceSFX;

    private void Start()
    {
        aSourceMusic = GameObject.FindWithTag("Audio/Music").GetComponent<AudioSource>();
        aSourceMusic.volume = musicVolume.var;

        aSourceSFX = GameObject.FindWithTag("Audio/SFX").GetComponent<AudioSource>();
        aSourceSFX.volume = sfxVolume.var;
    }

    public void SetMusicVolume()
    {
        aSourceMusic.volume = musicVolume.var;
    }

    public void SetSFXVolume()
    {
        aSourceSFX.volume = sfxVolume.var;
    }
}
