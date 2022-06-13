using UnityEngine;

namespace jell22y.ImageView
{
    public static class Extensions
    {
        public static float CalculateRatio(this RectTransform transform) => transform.rect.width / transform.rect.height;

        public static float CalculateRatio(this Texture2D texture) => (float)texture.width / (float)texture.height;
    }
}

