using UnityEngine;

[CreateAssetMenu(fileName = "Flow", menuName = "Visual Novel/Conversation Flow", order = 1)]
class ConversationFlow : ScriptableObject
{
    public TextElement[] dialogFlow;
}

[System.Serializable]
public class TextElement
{
    public bool isDialog;
    public bool isNarration;
    public bool isChoice;

    public string characterName;
    [TextArea(5, 10)]
    public string basicText;
    public ChoiceOptions[] choice;
}

[System.Serializable]
public class ChoiceOptions
{
    public string choiceText;
    public int choicePath;
}