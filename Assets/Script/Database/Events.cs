
using System;
using Script.Events;
using Script.Items;
using UnityEngine;

public class Events
{
    
    public readonly GEvent<Item[], int> OnPlayerChangeSelectedSlot = new();
    public readonly GEvent<Item[]> OnInventorySizeChanged = new();
    public readonly GEvent<Item[], int> OnInventoryItemChanged = new();

}

