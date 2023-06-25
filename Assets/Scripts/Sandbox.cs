using UnityEngine;
using UnityEngine.UI;

public class Sandbox : MonoBehaviour
{
    [SerializeField] private int variants;
    [SerializeField] private Button buttonChange;
    private int currentLocalization;


    private void Awake()
    {
        buttonChange.onClick.AddListener(() =>
        {
            currentLocalization += 1;
            MyLocalization.SetLocalization(currentLocalization % variants);
        });
    }
}
