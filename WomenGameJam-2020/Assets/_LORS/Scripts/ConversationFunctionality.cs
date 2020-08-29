﻿using UnityEngine;
using UnityTools.ScriptableVariables;
using TMPro;

public class ConversationFunctionality : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private ConversationMaster master = null;
    private TextElement flow = null;

    [Space]
    [SerializeField]
    private GameObject interactablePanel = null;
    [SerializeField]
    private GameObject fadePanel = null;

    [Space]
    [Header("UI Boxes")]
    [SerializeField]
    private GameObject dialogBox = null;
    [SerializeField]
    private GameObject narrationBox = null, choiceBox = null;
    [SerializeField]
    private GameObject[] optionBoxes = null;

    [Space]
    [Header("UI TextFields")]
    [SerializeField]
    private TextMeshProUGUI textDialog = null;
    [SerializeField]
    private TextMeshProUGUI textCharName = null, textNarration = null, textChoice = null;
    [SerializeField]
    private TextMeshProUGUI[] textOptions = null;

    [Space]
    [Header("Global Variables")]
    [SerializeField]
    private GenericInt talkedToCharacter = null;
    [SerializeField]
    private GenericBool characterPass = null;

    private int flowIdx = 0;
    private int masterIdx = 0;
    private bool closingDone = false;

    #endregion

    #region MAIN_CONVERSATION 

    public void Conversation()
    {
        DisableBoxes();

        if (flowIdx < master.flows[masterIdx].dialogFlow.Length)
        {
            flow = master.flows[masterIdx].dialogFlow[flowIdx];

            if (flow.isNarration)
            {
                interactablePanel.SetActive(true);
                narrationBox.SetActive(true);
                textNarration.text = flow.basicText;
                flowIdx++;
            }
            else if (flow.isDialog)
            {
                interactablePanel.SetActive(true);
                dialogBox.SetActive(true);
                textCharName.text = flow.characterName;
                textDialog.text = flow.basicText;
                flowIdx++;
            }
            else if (flow.isChoice)
            {
                interactablePanel.SetActive(false);
                choiceBox.SetActive(true);
                textChoice.text = flow.basicText;
                for (int i = 0; i < flow.choice.Length; i++)
                {
                    optionBoxes[i].SetActive(true);
                    textOptions[i].text = flow.choice[i].choiceText;
                }
            }
        }
        else
        {
            EndConversation();
        }


    }

    private void DisableBoxes()
    {
        choiceBox.SetActive(false);
        narrationBox.SetActive(false);
        dialogBox.SetActive(false);

        foreach (GameObject box in optionBoxes)
        {
            box.SetActive(false);
        }
    }
    #endregion

    public void ChoiceSelected(int selection)
    {
        flowIdx = 0;
        masterIdx = flow.choice[selection].choicePath;

        if (flow.choice[selection].choicePath == 5)
        {
            characterPass.var = true;
        }

        Conversation();
    }

    private void EndConversation()
    {
        flowIdx = 0;
        if (!closingDone)
        {
            if (characterPass.var)
            {
                masterIdx = 7;
            }
            else
            {
                masterIdx = 8;
            }
            closingDone = true;
            Conversation();
        }
        else
        {
            fadePanel.SetActive(true);
        }
    }
}
