using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Script.Items;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    [SerializeField] [Foldout("Views")] public ViewHUD _viewHUD;
    
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

        _currentView = _viewHUD;
    }

    public void ChangeCurrentView(View nextView)
    {
        _currentView.HideView();   
        _currentView = nextView;
        _currentView.ShowView();

    }

}

