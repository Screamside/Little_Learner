
using NaughtyAttributes;
using Script.Tools;
using UnityEngine;

public class Slot : MonoBehaviour
{

    [SerializeField] [BoxGroup("References")]
    private GameObject _toolSprite;
    
    [SerializeField] private GTool _currentTool;

    public void SetTool(GTool tool)
    {
        _currentTool = tool;
    }
    
}
