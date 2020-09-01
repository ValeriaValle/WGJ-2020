using UnityEngine;
using System.Collections;
using UnityTools.ScriptableVariables;
using TMPro;

public class DisplayType : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private GenericInt tbTypeIdx = null;
    [SerializeField]
    private TextMeshProUGUI[] displayTexts = null;
    [SerializeField]
    private float typeSpeed = 0.005f;

    private int totalCharacters;
    private int counter;

    private bool displayed = false;

    #endregion

    #region UNITY_METHODS

    void Start()
    {
        tbTypeIdx.var = 0;
    }
    #endregion

    #region OTHER_METHODS

    public void ShowText()
    {
        displayed = false;
        StartCoroutine(TextAnimation());
    }

    private IEnumerator TextAnimation()
    {
        totalCharacters = displayTexts[tbTypeIdx.var].text.Length;
        counter = 0;

        while (!displayed)
        {
            int visibleCount = counter % (totalCharacters + 1);
            displayTexts[tbTypeIdx.var].maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalCharacters)
            {
                displayed = true;
            }
            counter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
    #endregion
}
