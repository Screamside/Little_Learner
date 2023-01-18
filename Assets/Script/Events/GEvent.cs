using System;

namespace Script.Events
{
    public class GEvent
    {
        
        private event Action Action = delegate {  };

        public void AddListener(Action action)
        {
            Action += action;
        }

        public void RemoveListener(Action action)
        {
            Action -= action;
        }

        public void Invoke()
        {
            Action?.Invoke();
        }
        
        
    }

    public class GEvent<T>
    {
        private event Action<T> Action = delegate {  };
        
        public void AddListener(Action<T> action)
        {
            Action += action;
        }

        public void RemoveListener(Action<T> action)
        {
            Action -= action;
        }

        public void Invoke(T obj)
        {
            Action?.Invoke(obj);
        }

    }
}