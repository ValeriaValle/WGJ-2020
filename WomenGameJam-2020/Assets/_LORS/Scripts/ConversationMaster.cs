using UnityEngine;

[CreateAssetMenu(fileName = "Master_", menuName = "Visual Novel/Conversation Master", order = 0)]
class ConversationMaster : ScriptableObject
{
    public ConversationFlow[] flows = null;
}
