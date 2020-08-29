using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Intro : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private ConversationFlow introFlow = null;

    [Header("UI Variables")]
    [SerializeField]
    private GameObject laptop = null;
    [SerializeField]
    private TextMeshProUGUI narrationText = null;

    [SerializeField]
    private int showLaptopIdx = 0;
    private int flowIdx = 0;

    public UnityEvent onIntroEnd;

    #endregion

    #region UNITY_METHODS

    void Start()
    {
        narrationText.text = introFlow.dialogFlow[flowIdx].basicText;
        flowIdx++;
    }
    #endregion

    #region  OTHER_METHODS

    public void IntroFlow()
    {
        if (flowIdx < introFlow.dialogFlow.Length)
        {
            if (flowIdx == showLaptopIdx)
            {
                laptop.SetActive(true);
            }
            narrationText.text = introFlow.dialogFlow[flowIdx].basicText;
            flowIdx++;

        }
        else
        {
            onIntroEnd.Invoke();
        }
    }
    #endregion
}
