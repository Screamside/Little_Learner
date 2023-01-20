using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Script.Items;
using Unity.VisualScripting;
using UnityEngine;

public class ViewHUD : View
{
    private Slot[] slots = new Slot[0];

    [SerializeField] [BoxGroup("References")] private GameObject _slotPrefab;
    [SerializeField] [BoxGroup("References")] private GameObject _hotbar;

    private void Awake()
    {

        Database.Instance.EVENTS.OnInventorySizeChanged.AddListener(UpdateInventorySize);
        Database.Instance.EVENTS.OnInventoryItemChanged.AddListener(UpdateInventoryItems);

    }

    private void UpdateInventorySize(Item[] inventory)
    {
        if (inventory.Length < slots.Length)
        {
            //Decreased
            Destroy(slots[^1].gameObject);
            Array.Resize(ref slots, inventory.Length-1);
            
        }
        else
        {
            //Increased
            Array.Resize(ref slots, inventory.Length);
            slots[^1] = Instantiate(_slotPrefab, _hotbar.transform).GetComponent<Slot>();
        }
    }

    private void UpdateInventoryItems(Item[] inventory, int slot)
    {
        Debug.Log(inventory[slot]);
        Debug.Log(slots[slot]);
        
        slots[slot].SetItem(inventory[slot]);
    }

    public override View HideView()
    {
        return this;
    }

    public override View ShowView()
    {
        return this;
    }

}
