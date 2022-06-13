using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ImageView))]
public class ImageViewEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ImageView imageView = (ImageView)target;

        imageView.ScaleType = (ScaleType) EditorGUILayout.EnumPopup("ScaleType", imageView.ScaleType);
        imageView.BackgroundColor = EditorGUILayout.ColorField("Background Color", imageView.BackgroundColor);
        imageView.Texture = (Texture2D) EditorGUILayout.ObjectField("Texture", imageView.Texture, typeof(Texture2D), true);
        imageView.Download = EditorGUILayout.TextField("Download Link", imageView.Download);

        if (GUILayout.Button("Preview"))
        {
            imageView.ShowImageView();
            Selection.activeGameObject = imageView.ImageObject;
        }
    }
}
