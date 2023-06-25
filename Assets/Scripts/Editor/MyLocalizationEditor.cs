using UnityEditor;
using UnityEngine;

public class MyLocalizationEditor : EditorWindow
{
    private const int ItemListWidth = 350;
    private const int CurrentItemWidth = 500;

    private MyLocalization myLocalization;
    private LocalizationItem currentItem;
    private Vector2 scrollPosition;


    [MenuItem("MyLocalization/Show")]
    public static void ShowTextCollectionEditor()
    {
        GetWindow<MyLocalizationEditor>("MyLocalization");
    }

    private void OnEnable()
    {
        myLocalization = Resources.Load<MyLocalization>("MyLocalization");
        if (myLocalization.Items.Count > 0)
        {
            currentItem = myLocalization.Items[0];
        }
    }

    private void OnGUI()
    {
        EditorGUI.BeginChangeCheck();

        GUILayout.BeginHorizontal();
        DrawControllButtons();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical(GUILayout.Width(ItemListWidth));
        scrollPosition = GUILayout.BeginScrollView(scrollPosition);
        foreach (var item in myLocalization.Items)
        {
            DrawItemButton(item);
        }

        GUILayout.EndScrollView();
        GUILayout.EndVertical();

        GUILayout.BeginVertical(GUILayout.Width(CurrentItemWidth));
        DrawCurrentItem();
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();

        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(myLocalization);
        }
    }

    private void DrawControllButtons()
    {
        if (GUILayout.Button("Add"))
        {
            GUI.FocusControl(null);
            var textCollectionItem = new LocalizationItem(myLocalization.Variants);
            myLocalization.Items.Add(textCollectionItem);
            currentItem = textCollectionItem;
        }

        if (GUILayout.Button("Remove"))
        {
            if (currentItem == null)
            {
                return;
            }

            GUI.FocusControl(null);
            var currentItemIndex = myLocalization.Items.IndexOf(currentItem);
            myLocalization.Items.Remove(currentItem);
            if (currentItemIndex > 0)
            {
                currentItem = myLocalization.Items[currentItemIndex - 1];
            }
        }
    }

    private void DrawItemButton(LocalizationItem textCollectionItem)
    {
        var buttonName = textCollectionItem.Id;
        if (textCollectionItem == currentItem)
        {
            buttonName = $"> {buttonName} <";
        }

        if (GUILayout.Button(buttonName))
        {
            GUI.FocusControl(null);
            currentItem = textCollectionItem;
        }
    }

    private void DrawCurrentItem()
    {
        if (currentItem == null)
        {
            return;
        }

        currentItem.Id = EditorGUILayout.TextField("Id:", currentItem.Id);

        for (int i = 0; i < myLocalization.Variants; i++)
        {
            if (currentItem.TextVariants.Count < myLocalization.Variants)
            {
                currentItem.TextVariants.Add("");
            }

            currentItem.TextVariants[i] = GUILayout.TextArea(currentItem.TextVariants[i]);
        }
    }
}
