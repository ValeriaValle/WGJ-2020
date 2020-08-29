using UnityEngine;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    private string objectDescription;

    [SerializeField]
    private TextMeshProUGUI descriptionText;

    public void ShowDescription()
    {
        descriptionText.text = objectDescription;
    }
}
