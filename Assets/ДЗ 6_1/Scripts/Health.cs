using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates.Events
{
    public class Health
    {
        public event Action<int> Changed;
        public Health(int max)
        {
            Current = Max = max;
        }

        public int Max { get;}
        public int Current { get; private set; }

        public void Reduce(int value)
        {
            if (value < 0)
                value = 0;

            Current -= value;

            Current = Mathf.Clamp(Current, 0, Max);

            Changed?.Invoke(Current);
        }
    }
}
