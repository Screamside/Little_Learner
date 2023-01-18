
using NaughtyAttributes;
using Script.Tools;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    [SerializeField] [BoxGroup("References")] private Image _toolSprite;
    
    [SerializeField] private GTool _currentTool;

    public Slot SetTool(GTool tool)
    {
        _currentTool = tool;

        _toolSprite.sprite = _currentTool.toolSprite;
        
        return this;
    }
    
}
