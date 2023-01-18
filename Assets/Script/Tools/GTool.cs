using NaughtyAttributes;
using UnityEngine;

namespace Script.Tools
{
    [CreateAssetMenu(fileName = "New Tool", menuName = "Tools")]
    public class GTool : ScriptableObject
    {
        [ShowAssetPreview] public Sprite toolSprite;

        public string Name;

    }
}