using UnityEngine.UI;

public class MinimumScrollBar : Scrollbar
{
    public float verticalScrollbarMinimumSize = 0.1f;

    public override void Rebuild(CanvasUpdate executing)
    {
        base.Rebuild(executing);

        if (size < verticalScrollbarMinimumSize)
            size = verticalScrollbarMinimumSize;
    }
}
