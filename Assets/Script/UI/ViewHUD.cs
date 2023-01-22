using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Script.Items;
using Unity.VisualScripting;
using UnityEngine;

public class ViewHUD : View
{
    [SerializeField]private Slot[] slots = new Slot[0];

    [SerializeField] [BoxGroup("References")] private GameObject _slotPrefab;
    [SerializeField] [BoxGroup("References")] private GameObject _hotbar;
    [SerializeField] [BoxGroup("References")] private Sprite _slotSprite;
    [SerializeField] [BoxGroup("References")] private Sprite _selectedSlotSprite;

    private void Awake()
    {

        Database.Instance.EVENTS.OnInventorySizeChanged.AddListener(UpdateInventorySize);
        Database.Instance.EVENTS.OnInventoryItemChanged.AddListener(UpdateInventoryItems);
        Database.Instance.EVENTS.OnPlayerChangeSelectedSlot.AddListener(UpdateSelectedSlot);

    }

    private void UpdateInventorySize(Item[] inventory)
    {
        if (inventory.Length < slots.Length)
        {
            //Decreased
            Destroy(slots[^1].gameObject);
            Array.Resize(ref slots, inventory.Length);
        }else if (inventory.Length > slots.Length)
        {
            //Increased
            Array.Resize(ref slots, inventory.Length);
            slots[^1] = Instantiate(_slotPrefab, _hotbar.transform).GetComponent<Slot>();
        }
    }

    private void UpdateInventoryItems(Item[] inventory, int slot)
    {
        slots[slot].SetItem(inventory[slot]);
    }

    private void UpdateSelectedSlot(Item[] inventoryList, int slotNumber)
    {
        foreach (Slot slot in slots)
        {
            slot.SetSprite(_slotSprite);
        }

        slots[slotNumber].SetSprite(_selectedSlotSprite);

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
