using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Mask))]
public class ImageView : MonoBehaviour
{
    public Texture2D Texture;
    public Color BackgroundColor = Color.black;
    public ScaleType ScaleType = ScaleType.centerCrop;
    public string Download;

    [Header("Background")]
    private Image backgroundImage;

    [Header("Child")]
    public GameObject ImageObject;
    private AspectRatioFitter aspectRatio;
    private RawImage rawImage;

}
