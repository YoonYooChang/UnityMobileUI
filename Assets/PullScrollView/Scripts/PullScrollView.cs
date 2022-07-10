using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PullScrollView : ScrollRect
{
    #region Event
    public UnityEvent OnTopPull;
    public UnityEvent OnBottomPull;
    public UnityEvent<float> OnTopPulling;
    public UnityEvent<float> OnBottomPulling;
    #endregion

    private bool dragging;
    private bool pullUp;
    private bool pullDown;

    private float previousPosition;
    public float RequirePullDistance = 150f;

    protected override void Start() => this.onValueChanged.AddListener(ScrollChanged);

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        dragging = true;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        dragging = false;
    }

    private void ScrollChanged(Vector2 vector)
    {
        float distance = CalculatePullDistance();


    }

    private float CalculatePullDistance()
    {
        float y = content.anchoredPosition.y;
        float z = 0f;

        if (verticalNormalizedPosition != 1f && verticalNormalizedPosition != 0f)
        {
            if (verticalNormalizedPosition < 0f)
            {
                z = y - previousPosition;
            }
            else
            {
                previousPosition = y;
            }
        }
        else
        {
            z = y;
        }

        if (verticalNormalizedPosition >= 1)
        {
            return y;
        }   
        else if (verticalNormalizedPosition <= 0)
        {
            return z;
        }
        else
        {
            return 0;
        }
    }
}
