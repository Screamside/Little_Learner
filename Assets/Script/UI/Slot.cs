
using NaughtyAttributes;
using Script.Items;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    [SerializeField] [BoxGroup("References")] private Image _toolSprite;
    
    [SerializeField] private Item _currentItem;

    public bool isEmpty
    {
        get => _currentItem.Equals(null);
    }
    
    public Slot SetItem(Item tool)
    {
        _currentItem = tool;

        _toolSprite.sprite = _currentItem.Sprite;
        
        return this;
    }

    public Slot CleanSlot()
    {
        _currentItem = null;

        _toolSprite.sprite = null;

        return this;
    }
    
}
