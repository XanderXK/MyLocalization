using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocalizationItem
{
    [field: SerializeField] public string Id { get; set; }
    [field: SerializeField] public List<string> TextVariants { get; set; }


    public LocalizationItem(int variants)
    {
        TextVariants = new List<string>();
        for (int i = 0; i < variants; i++)
        {
            TextVariants.Add("");
        }
    }
}
