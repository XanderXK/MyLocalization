using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MyLocalization : ScriptableObject
{
    public static int CurrenLocalization { get; private set; }
    private static MyLocalization myLocalization;

    [field: SerializeField] public int Variants { get; private set; }
    [field: SerializeField] public List<LocalizationItem> Items { get; private set; }


    public static void SetLocalization(int localization)
    {
        myLocalization ??= Resources.Load<MyLocalization>("MyLocalization");
        CurrenLocalization = Mathf.Clamp(localization, 0, myLocalization.Variants - 1);

        var textLocalizations = FindObjectsOfType<TextLocalization>();
        foreach (var item in textLocalizations)
        {
            item.SetText();
        }
    }

    public static string GetText(string id)
    {
        myLocalization ??= Resources.Load<MyLocalization>("MyLocalization");

        var currentItem = myLocalization.Items.Find(item => item.Id == id);
        if (currentItem != null)
        {
            return currentItem.TextVariants[CurrenLocalization];
        }

        return id;
    }
}
