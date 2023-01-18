using System;
using System.Collections;
using System.Collections.Generic;
using Script.Database;
using UnityEngine;

public class Database : MonoBehaviour
{

    public static Database Instance;

    public Tools TOOLS;

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
}
