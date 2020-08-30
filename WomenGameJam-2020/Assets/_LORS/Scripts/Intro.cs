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
    private TextMeshProUGUI narrationText = null, dialogText = null;
    [SerializeField]
    private GameObject narrationBox = null, dialogBox = null;
    [SerializeField]
    private TextMeshProUGUI textCharacterName = null;

    private int masterIdx = 0;
    private int flowIdx = 0;

    public UnityEvent onEndFirstPart, onIntroEnd;
    public UnityEvent onKeyboardSound;

    #endregion

    #region UNITY_METHODS

    void Start()
    {
        onKeyboardSound.Invoke();
        flow = master.flows[masterIdx].dialogFlow[flowIdx];
        narrationText.text = flow.basicText;
        flowIdx++;
    }
    #endregion

    #region  OTHER_METHODS

    public void IntroFlow()
    {
        if (flowIdx < master.flows[masterIdx].dialogFlow.Length)
        {
            flow = master.flows[masterIdx].dialogFlow[flowIdx];

            if (flow.isNarration)
            {
                narrationBox.SetActive(true);
                dialogBox.SetActive(false);
                narrationText.text = flow.basicText;
                flowIdx++;
            }

            else if (flow.isDialog)
            {
                narrationBox.SetActive(false);
                dialogBox.SetActive(true);
                dialogText.text = flow.basicText;
                textCharacterName.text = flow.characterName;
                flowIdx++;
            }
        }

        else
        {
            if (masterIdx == 0)
            {
                onEndFirstPart.Invoke();
            }
            else
            {
                onIntroEnd.Invoke();
            }
        }
    }

    public void FadeLaptop()
    {
        laptop.SetActive(true);
        flowIdx = 0;
        masterIdx++;
        IntroFlow();
    }
    #endregion
}
