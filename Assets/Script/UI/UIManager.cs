using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    private View _initialView;
    private View _currentView;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void ChangeCurrentView(View nextView)
    {
        
        _currentView = nextView;

    }

}

public struct Views
{
    
    
    
}
