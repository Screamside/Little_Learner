using NaughtyAttributes;
using UnityEngine;

namespace Script.Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Items", order = 0)]
    public class Item : ScriptableObject
    {
        
        [ShowAssetPreview] public Sprite Sprite;
        public string Name;
        public string Description;

    }
}