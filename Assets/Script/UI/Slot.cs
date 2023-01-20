
using NaughtyAttributes;
using Script.Items;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    [SerializeField] [BoxGroup("References")] private Image _toolSprite;
    [SerializeField] [BoxGroup("References")] private Image _slotSprite;
    [SerializeField] private Item _currentItem;

    public bool isEmpty
    {
        get => _currentItem.Equals(null);
    }
    
    public Slot SetItem(Item tool)
    {
        _currentItem = tool;

        if (tool is not null)
        {
            _toolSprite.sprite = _currentItem.Sprite;
        }
        
        return this;
    }

    public Slot SetSprite(Sprite newSprite)
    {

        _slotSprite.sprite = newSprite;

        return this;

    }

}
