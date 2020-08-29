using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Intro : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private ConversationMaster master = null;
    private TextElement flow;

    [Header("UI Variables")]
    [SerializeField]
    private GameObject laptop = null;
    [SerializeField]
    private TextMeshProUGUI boxText = null;
    [SerializeField]
    private GameObject characterNameBox = null;
    [SerializeField]
    private TextMeshProUGUI textCharacterName = null;

    private int masterIdx = 0;
    private int flowIdx = 0;

    public UnityEvent onIntroEnd;
    public UnityEvent onKeyboardSound;
    public UnityEvent onComputerDataSound_1;

    #endregion

    #region UNITY_METHODS

    void Start()
    {
        onKeyboardSound.Invoke();
        flow = master.flows[masterIdx].dialogFlow[flowIdx];
        boxText.text = flow.basicText;
        flowIdx++;
    }
    #endregion

    #region  OTHER_METHODS

    public void IntroFlow()
    {
        if (flowIdx < master.flows[masterIdx].dialogFlow.Length)
        {
            flow = master.flows[masterIdx].dialogFlow[flowIdx];

            characterNameBox.SetActive(false);
            boxText.text = flow.basicText;
            flowIdx++;

            if (flow.isDialog)
            {
                characterNameBox.SetActive(true);
                textCharacterName.text = flow.characterName;
            }
        }

        else
        {
            if (masterIdx == 0)
            {
                onComputerDataSound_1.Invoke();
                laptop.SetActive(true); //TODO: Intro Animation

                flowIdx = 0;
                masterIdx++;
                IntroFlow();
            }
            else
            {
                onIntroEnd.Invoke();
            }
        }
    }
    #endregion
}
