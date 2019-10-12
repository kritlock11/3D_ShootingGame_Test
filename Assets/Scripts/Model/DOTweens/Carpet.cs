using System;
using UnityEngine;

namespace Geekbrains
{
    public class Carpet : BasePickUpItem
    {
        public event Action OnCarpenEnter;

        public override void Action()
        {
            isDestroy = false;
            OnCarpenEnter?.Invoke();
        }
    }
}
