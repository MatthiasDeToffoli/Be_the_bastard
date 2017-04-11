using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class ChoiceEvent : UnityEvent<int>
{
    [MenuItem("Tools/MyTool/Do It in C#")]
    static void DoIt()
    {
        EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
    }
}