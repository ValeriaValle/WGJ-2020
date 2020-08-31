using UnityEngine;
using UnityEngine.Events;
using UnityTools.ScriptableVariables;

public class MusicManager : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private GenericInt musicIdx = null;
    [SerializeField]
    private GenericBool musicFading = null;
    private int currentIdx = 0;

    [SerializeField]
    private AudioClip[] clips = null;
    private AudioSource music;

    public UnityEvent fadeMusic;

    #endregion

    #region UNITY_METHODS
    void Start()
    {
        music = GameObject.FindWithTag("Audio/Music").GetComponent<AudioSource>();
        musicFading.var = false;
    }

    #endregion

    #region OTHER_METHODS

    public void FadeMusic()
    {
        if (currentIdx != musicIdx.var && !musicFading.var)
        {
            fadeMusic.Invoke();
            musicFading.var = true;
        }
    }

    public void ChangeClip()
    {
        music.Stop();
        music.clip = clips[musicIdx.var];
        music.Play();
        currentIdx = musicIdx.var;
    }
    #endregion
}
