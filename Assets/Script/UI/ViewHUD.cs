using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class ViewHUD : View
{
    private List<Slot> slots;

    [SerializeField] [BoxGroup("References")] private GameObject _slotPrefab;
    
    public override View HideView()
    {
        return this;
    }

    public override View ShowView()
    {
        return this;
    }

    public void AddSlot()
    {
        
    }

    public void RemoveSlot()
    {
        
    }
}
