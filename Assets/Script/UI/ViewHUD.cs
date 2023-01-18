using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Script.Tools;
using UnityEngine;

public class ViewHUD : View
{
    private List<Slot> slots = new();

    [SerializeField] [BoxGroup("References")] private GameObject _slotPrefab;
    [SerializeField] [BoxGroup("References")] private GameObject _hotbar;

    private void Awake()
    {
        
        AddSlot(Database.Instance.TOOLS.AXE);
        
        Debug.Log(Database.Instance.TOOLS.AXE.toolSprite);
        
    }

    public override View HideView()
    {
        return this;
    }

    public override View ShowView()
    {
        return this;
    }

    public void AddSlot(GTool tool)
    {
        slots.Add(Instantiate(_slotPrefab, _hotbar.transform).GetComponent<Slot>().SetTool(tool));
    }

    public void RemoveSlot()
    {
        
    }
}
