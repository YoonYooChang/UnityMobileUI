using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(RectMask2D))]
public class ImageView : MonoBehaviour
{
    public Texture2D Texture;
    public Color BackgroundColor = Color.black;
    public ScaleType ScaleType = ScaleType.centerCrop;
    public string Download;

    [Header("Background")]
    private Image backgroundImage;
    private VerticalLayoutGroup layoutGroup;

    [Header("Child")]
    public GameObject ImageObject;
    private AspectRatioFitter aspectRatio;
    private RawImage rawImage;

    private void Awake() => ShowImageView();

    public void ShowImageView()
    {
        CreateImageView();
        SetImageView();
    }

    #region Create Image View
    private void CheckImageView()
    {
        if (ImageObject != null)
        {
            DestroyImmediate(ImageObject);
        }
        if (backgroundImage != null)
        {
            DestroyImmediate(backgroundImage);
        }
        if (layoutGroup != null)
        {
            DestroyImmediate(layoutGroup);
        }
    }

    private void CreateImageView()
    {
        CheckImageView();

        backgroundImage = gameObject.AddComponent<Image>();
        layoutGroup = gameObject.AddComponent<VerticalLayoutGroup>();

        ImageObject = new GameObject("Image");
        ImageObject.transform.parent = transform;
        aspectRatio = ImageObject.AddComponent<AspectRatioFitter>();
        rawImage = ImageObject.AddComponent<RawImage>();
    }
    #endregion

    private void SetImageView()
    {
        if (Texture != null)
        {
            SetTexture();
        }
        backgroundImage.color = BackgroundColor;

        if (!string.IsNullOrEmpty(Download))
        {
            StartCoroutine(GetTexture(Download, texture => SetTexture(texture)));
        }
    }

    private void SetTexture(Texture2D texture = null)
    {
        if (texture != null)
        {
            Texture = texture;
        }

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
