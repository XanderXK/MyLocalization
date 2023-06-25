using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MyLocalization : ScriptableObject
{
    public static int CurrenLocalization { get; set; }
    private static MyLocalization textCollection;

    [SerializeField] private int variants;
    [SerializeField] private List<LocalizationItem> items;

    public int Variants => variants;
    public List<LocalizationItem> Items => items;


    public static string GetText(string id)
    {
        textCollection ??= Resources.Load<MyLocalization>("MyLocalization");

        var currentItem = textCollection.items.Find(item => item.Id == id);
        if (currentItem != null)
        {
            return currentItem.TextVariants[CurrenLocalization];
        }

        return id;
    }
}
