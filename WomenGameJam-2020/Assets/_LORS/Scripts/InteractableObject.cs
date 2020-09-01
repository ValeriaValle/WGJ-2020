using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    private string objectDescription = "";

    [SerializeField]
    private TextMeshProUGUI descriptionText = null;

    private GameObject descriptionBox;
    private RectTransform rTrans;

    public UnityEvent displayText_Objects;

    void Start()
    {
        descriptionBox = descriptionText.gameObject.transform.parent.gameObject;
        rTrans = gameObject.GetComponent<RectTransform>();
    }

    public void ShowDescription()
    {
        descriptionText.text = objectDescription;
        displayText_Objects.Invoke();
        StartCoroutine(HideDescriptionBox(4.5f));
    }

    IEnumerator HideDescriptionBox(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        descriptionBox.SetActive(false);
    }

    public void ScaleUp()
    {
        rTrans.localScale = new Vector3(1.2f, 1.2f, 0);
    }

    public void ScaleDown()
    {
        rTrans.localScale = new Vector3(1f, 1f, 0);
    }
}
