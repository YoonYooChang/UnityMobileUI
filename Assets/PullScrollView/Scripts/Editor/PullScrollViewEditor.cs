using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(PullScrollView))]
public class PullScrollViewEditor : ScrollRectEditor
{
    PullScrollView scrollView;

    public override void OnInspectorGUI()
    {
        scrollView = (PullScrollView)target;

        base.OnInspectorGUI();

    }
}
