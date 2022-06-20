using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class GridLayoutGroupHelper : MonoBehaviour
{
    private RectTransform rectTransform;
    private GridLayoutGroup gridLayoutGroup;
    private Vector2 layoutGroupSize;

    [Header("Parameters")]
    [SerializeField] private Vector2 itemSize;
    [SerializeField] private bool fixColumn;
    [SerializeField] private int colCount;
    [SerializeField] private int rowCount;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    private void OnEnable() => StartCoroutine(CalculateGridLayoutGroup());

    IEnumerator CalculateGridLayoutGroup()
    {
        yield return new WaitForEndOfFrame();

        layoutGroupSize = new Vector2(rectTransform.rect.width, rectTransform.rect.height);

        // Calculate
    }
}
