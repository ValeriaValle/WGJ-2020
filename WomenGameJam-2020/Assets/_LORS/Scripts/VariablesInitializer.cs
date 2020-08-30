using UnityEngine;
using UnityTools.ScriptableVariables;

public class VariablesInitializer : MonoBehaviour
{
    #region VARIABLES
    [SerializeField]
    private GenericInt day = null;
    [SerializeField]
    private GenericBool[] passStudents = null, talkedStudents = null;

    #endregion

    #region UNITY_METHODS
    void Start()
    {
        for (int i = 0; i < passStudents.Length; i++)
        {
            passStudents[i].var = false;
            talkedStudents[i].var = false;
        }
        day.var = 0;
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion

    #region OTHER_METHODS

    #endregion
}
