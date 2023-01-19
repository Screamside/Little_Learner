using System.Collections.Generic;
using NaughtyAttributes;
using Script.Items;
using UnityEngine;

public class ViewHUD : View
{
    private List<Slot> slots = new();

    [SerializeField] [BoxGroup("References")] private GameObject _slotPrefab;
    [SerializeField] [BoxGroup("References")] private GameObject _hotbar;

    private void Awake()
    {
        
        AddSlot(Database.Instance.TOOLS.AXE);
        
        Debug.Log(Database.Instance.TOOLS.AXE.Sprite);
        
    }

    public override View HideView()
    {
        return this;
    }

    public override View ShowView()
    {
        return this;
    }

    public void AddSlot(Item item = null)
    {
        slots.Add(Instantiate(_slotPrefab, _hotbar.transform).GetComponent<Slot>().SetItem(item));
    }

    public void AddItem(Item item)
    {
        if (slots.Count < 1)
        {
            AddSlot(item);
        }
        else
        {
            foreach (var slot in slots)
            {
                if (slot.isEmpty)
                {
                    slot.SetItem(item);
                }
            }
        }
        
    }

    public void RemoveSlot()
    {
        
    }
}
