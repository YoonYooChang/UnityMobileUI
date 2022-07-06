using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PullScrollView : ScrollRect, IDropHandler
{
    #region Event
    public UnityEvent OnTopPull;
    public UnityEvent OnBottomPull;
    public UnityEvent<float> OnTopPulling;
    public UnityEvent<float> OnBottomPulling;

    private float previousPosition;

    public float RequirePullDistance = 150f;
    #endregion

    public void OnDrop(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}
