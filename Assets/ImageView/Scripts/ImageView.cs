using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
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

    private void Awake() => ShowImageView();

    public void ShowImageView()
    {
        CreateImageObject();
        SetImageView();
    }

    private void CreateImageObject()
    {
        backgroundImage = GetComponent<Image>();

        if (ImageObject != null)
        {
            DestroyImmediate(ImageObject);
        }

        ImageObject = new GameObject("Image");
        ImageObject.transform.parent = transform;
        aspectRatio = ImageObject.AddComponent<AspectRatioFitter>();
        rawImage = ImageObject.AddComponent<RawImage>();
    }

    private void SetImageView()
    {
        if (Texture != null)
        {
            SetTexture();
        }
        backgroundImage.color = BackgroundColor;

        if (!string.IsNullOrEmpty(Download))
        {
            StartCoroutine(GetTexture(Download, texture =>
            {
                Texture = texture;
                SetTexture();
            }));
        }
    }

    private void SetTexture()
    {
        rawImage.texture = Texture;
        rawImage.color = Color.white;
    }

    private IEnumerator GetTexture(string path, Action<Texture2D> action)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(path);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            action?.Invoke(texture);
        }
    }
}
