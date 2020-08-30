using UnityEngine;
using System.Collections;
using UnityTools.ScriptableVariables;
using TMPro;

public class MainClass : MonoBehaviour
{
    #region VARIABLES

    [Header("Global Variables")]
    [SerializeField]
    private GenericInt day = null;
    [SerializeField]
    private GenericBool[] haveTalked = null;

    [Space]
    [Header("UI Variables")]
    [SerializeField]
    private GameObject narrationBox = null;
    [SerializeField]
    private TextMeshProUGUI narrationText = null;
    [SerializeField]
    private GameObject[] closeUps = null;

    #endregion

    #region UNITY_METHODS
    void Start()
    {
        if (day.var == 0)
        {
            narrationText.text = "Who would you like to talk to?";
            day.var++;
            StartCoroutine(HideDescriptionBox(2.5f));
        }
        else
        {
            narrationText.text = "Day 2. Who would you like to talk to?";
            day.var++;
            StartCoroutine(HideDescriptionBox(2.5f));
        }
    }

    #endregion

    #region OTHER_METHODS

    public void StudentClick(int option)
    {
        if (haveTalked[option].var)
        {
            narrationBox.SetActive(true);
            narrationText.text = "You've already had a 1-on-1 video chat with this student.";
            StartCoroutine(HideDescriptionBox(4f));
        }
        else
        {
            closeUps[option].SetActive(true);
        }
    }

    IEnumerator HideDescriptionBox(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        narrationBox.SetActive(false);
    }

    #endregion
}
