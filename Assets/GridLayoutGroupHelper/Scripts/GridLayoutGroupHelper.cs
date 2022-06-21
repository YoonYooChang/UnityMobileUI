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

        SetDynamicGridLayout();
    }

    private void SetDynamicGridLayout()
    {
        int itemCount = this.transform.childCount;

        if (fixColumn)
        {
            rowCount = Mathf.CeilToInt(itemCount / colCount);
        }
        else
        {
            colCount = Mathf.CeilToInt(itemCount / rowCount);
        }

        float spaceWidth = (gridLayoutGroup.padding.left + gridLayoutGroup.padding.right) + (gridLayoutGroup.spacing.x * (colCount - 1));
        float spaceHeight = (gridLayoutGroup.padding.top + gridLayoutGroup.padding.bottom) + (gridLayoutGroup.spacing.y * (rowCount - 1));

        Vector2 spaceSize = new Vector2(spaceWidth, spaceHeight);
        Vector2 displaySize = layoutGroupSize - spaceSize;

        Vector2 displayItemSize;
        float itemWidth, itemHeight;

        if (fixColumn)
        {
            itemWidth = displaySize.x / colCount;
            itemHeight = (itemWidth / itemSize.x) * itemSize.y;
        }
        else
        {
            itemHeight = displaySize.y / rowCount;
            itemWidth = (itemHeight / itemSize.y) * itemSize.x;
        }
        displayItemSize = new Vector2(itemWidth, itemHeight);

        gridLayoutGroup.cellSize = displayItemSize;
    }
}
