using UnityEngine;
using UnityEngine.UI;
using UnityTools.ScriptableVariables;

public class Settings : MonoBehaviour
{
    #region VARIABLES

    [Header("Volume Values")]
    public GenericFloat musicVolume = null;
    public GenericFloat sfxVolume = null;

    [Header("Volume Sliders")]
    [SerializeField]
    private Slider musicSlider = null;
    [SerializeField]
    private Slider sfxSlider = null;
    #endregion

    #region UNITY_METHODS

    void Start()
    {
        musicSlider.value = musicVolume.var;
        sfxSlider.value = sfxVolume.var;
    }
    #endregion

    #region OTHER_METHODS

    public void AdjustMusicVolume()
    {
        musicVolume.var = musicSlider.value;
    }

    public void AdjustSfxVolume()
    {
        sfxVolume.var = sfxSlider.value;
    }
    #endregion
}
