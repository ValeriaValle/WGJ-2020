using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityTools.ScriptableVariables;
using TMPro;

public class Ending_Scoring : MonoBehaviour
{
    #region VARIABLES
    [Header("Global Variables")]
    [SerializeField]
    private GenericBool[] passStudents = null;
    [SerializeField]
    private GenericInt masterIdx = null;

    [Header("Checklist UI Variables")]
    [SerializeField]
    private Image[] imgsCheckbox = null;
    [SerializeField]
    private Sprite[] checkboxes = null;

    [Header("GameOver UI Variables")]
    [SerializeField]
    private TextMeshProUGUI textScoreDefeat = null;

    public UnityEvent onVictory, onDefeat;

    [SerializeField]
    private int[] idxCheckboxes = null;
    private int score;
    #endregion

    #region UNITY_METHODS

    #endregion

    #region OTHER_METHODS

    public void Checklist(int i)
    {
        if (idxCheckboxes[i] == 1)
        {
            imgsCheckbox[i].sprite = checkboxes[0];
            idxCheckboxes[i] = 0;
            if (i == 1)
            {
                passStudents[i].var = false;
            }
            masterIdx.var = 1;
        }
        else
        {
            ClearCheckboxes();
            imgsCheckbox[i].sprite = checkboxes[1];
            idxCheckboxes[i] = 1;
            if (i == 1)
            {
                passStudents[i].var = true;
            }
            masterIdx.var = 2;

        }
    }

    private void ClearCheckboxes()
    {
        for (int i = 0; i < imgsCheckbox.Length; i++)
        {
            imgsCheckbox[i].sprite = checkboxes[0];
            idxCheckboxes[i] = 0;
        }
        passStudents[1].var = false;
    }

    public void GameOver()
    {
        for (int i = 0; i < passStudents.Length; i++)
        {
            if (passStudents[i].var)
            {
                score++;
            }
        }

        if (score == 3)
        {
            onVictory.Invoke();
        }
        else
        {
            textScoreDefeat.text = score + ("/3");
            onDefeat.Invoke();
        }
    }
    #endregion
}
