using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

[CustomEditor(typeof(PullScrollView))]
public class PullScrollViewEditor : ScrollRectEditor
{
    PullScrollView scrollView;

    public override void OnInspectorGUI()
    {
        scrollView = (PullScrollView)target;

        base.OnInspectorGUI();

        EditorGUI.BeginChangeCheck();

        var pullDistance = EditorGUILayout.FloatField("Require Pull Distance", scrollView.RequirePullDistance);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("OnTopPull"), new GUIContent("On TopPull Event"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("OnBottomPull"), new GUIContent("On BottomPull Event"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("OnTopPulling"), new GUIContent("On TopPulling Event"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("OnBottomPulling"), new GUIContent("On BottomPulling Event"));

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(scrollView, "Change Require Pull Distance");

            scrollView.RequirePullDistance = pullDistance;
        }
    }
}
