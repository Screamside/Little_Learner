using Script.Events;
using UnityEngine;

namespace Script.Input
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;

        public readonly GEvent<Vector2> OnClientMove = new();
        public readonly GEvent<bool> OnClientSprint = new();
        public readonly GEvent OnClientMouseLeftClick = new();

        private Inputs _inputs;
        
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

            _inputs = new Inputs();

            _inputs.Player.Move.started += context => OnClientMove.Invoke(context.ReadValue<Vector2>()); 
            _inputs.Player.Move.performed += context => OnClientMove.Invoke(context.ReadValue<Vector2>());
            _inputs.Player.Move.canceled += context => OnClientMove.Invoke(Vector2.zero);
            
            _inputs.Player.Sprint.started += context => OnClientSprint.Invoke(true);
            _inputs.Player.Sprint.canceled += context => OnClientSprint.Invoke(false);
            _inputs.Player.Attack.started += context => OnClientMouseLeftClick.Invoke();

        }

        private void OnEnable()
        {
            _inputs.Enable();
        }

        private void OnDisable()
        {
            _inputs.Disable();
        }
    }
}