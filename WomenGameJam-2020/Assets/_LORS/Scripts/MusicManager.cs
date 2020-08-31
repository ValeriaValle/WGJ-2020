using UnityEngine;
using System.Collections;
using UnityTools.ScriptableVariables;

public class MusicManager : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private GenericInt musicIdx;
    private int currentIdx = 0;

    [SerializeField]
    private AudioClip[] clips;
    private AudioSource music;
    [SerializeField]
    private float duration;

    #endregion

    #region UNITY_METHODS
    void Start()
    {
        music = GameObject.FindWithTag("Audio/Music").GetComponent<AudioSource>();
    }

    #endregion

    #region OTHER_METHODS

    public void ChangeClip()
    {
        if (currentIdx != musicIdx.var)
        {
            StartCoroutine(FadeAudioSource.StartFade(music, duration, 0f));
            music.Stop();
            music.clip = clips[musicIdx.var];
            music.Play();
            currentIdx = musicIdx.var;
        }
    }
    #endregion
}
