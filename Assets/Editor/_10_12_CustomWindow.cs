using UnityEngine;
using UnityEditor;
public class _10_12_CustomWindow : EditorWindow
{
    string strFileName;
    [MenuItem("Custom/Tool")]
    static void CreateWindow()
    {
        _10_12_CustomWindow window = (_10_12_CustomWindow)EditorWindow.GetWindow(typeof(_10_12_CustomWindow));
        window.Show();
    }
    //OnGUI ÇÔ¼öÆ¯Â¡
    private void OnGUI()
    {
        GUILayout.Label("Fill out filename and press save button");
        GUILayoutOption[] op_SaveButton = new GUILayoutOption[2];
        op_SaveButton[0] = GUILayout.Width(40);
        op_SaveButton[1] = GUILayout.Height(20);
        if (GUILayout.Button("Save", op_SaveButton))
        {
            strFileName = EditorUtility.SaveFilePanel("Save File", Application.dataPath, "None", "txt");
            if(strFileName.Equals(""))
            {
                return;
            }
            Debug.Log("Button Click");
        }
        GUILayoutOption[] op_ColorFiled = new GUILayoutOption[2];
        op_ColorFiled[0] = GUILayout.Width(40);
        op_ColorFiled[1] = GUILayout.Height(20);
        Color clolorField = EditorGUILayout.ColorField(new Color(1, 1, 1), op_ColorFiled);
    }
}
