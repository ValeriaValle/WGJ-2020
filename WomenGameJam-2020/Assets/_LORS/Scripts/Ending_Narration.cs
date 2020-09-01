using UnityEngine;
using UnityEngine.Events;
using UnityTools.ScriptableVariables;
using TMPro;

public class Ending_Narration : MonoBehaviour
{
    #region VARIABLES
    [SerializeField]
    private ConversationMaster master = null;
    private TextElement flow;

    [Header("UI Variables")]
    [SerializeField]
    private TextMeshProUGUI boxText = null;
    [SerializeField]
    private GameObject narrationBox = null, studentList = null;
    private GameObject fadePanel;

    [Space]
    [SerializeField]
    private GenericInt masterIdx = null;

    private int flowIdx = 0;

    public UnityEvent onMusicChange, onGameOver;
    public UnityEvent displayText;

    #endregion

    #region UNITY_METHODS
    void Start()
    {
        masterIdx.var = 0;
        flow = master.flows[masterIdx.var].dialogFlow[flowIdx];
        boxText.text = flow.basicText;
        displayText.Invoke();
        flowIdx++;
    }

    #endregion

    #region OTHER_METHODS

    public void EndingFlow()
    {
        if (flowIdx < master.flows[masterIdx.var].dialogFlow.Length)
        {
            flow = master.flows[masterIdx.var].dialogFlow[flowIdx];

            boxText.text = flow.basicText;
            displayText.Invoke();
            flowIdx++;
        }
        else
        {
            if (masterIdx.var == 0)
            {
                narrationBox.SetActive(false);
                studentList.SetActive(true);
                masterIdx.var = 1;
            }
            else
            {
                onGameOver.Invoke();
            }
        }
    }

    public void ContinueEnding()
    {
        onMusicChange.Invoke();
        narrationBox.SetActive(true);
        flowIdx = 0;
        EndingFlow();
    }

    #endregion
}
