using TMPro;
using UnityEngine;

public class TextLocalization : MonoBehaviour
{
    [SerializeField] private string id;


    private void OnEnable()
    {
        SetText();
    }

    public void SetText()
    {
        GetComponent<TextMeshProUGUI>().text = MyLocalization.GetText(id);
    }
}
