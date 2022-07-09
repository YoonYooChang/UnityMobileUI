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

    private void ScrollChanged(Vector2 vector)
    {
        
    }

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


}
