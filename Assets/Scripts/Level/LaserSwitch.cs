using System;
using UnityEngine;

namespace Level
{
    public class LaserSwitch : Switch
    {
        public Color switchColour;
        private SpriteRenderer _sprite;

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _sprite.color = switchColour;
        }

        private void LateUpdate()
        {
            TurnOff();
        }

        public override void TurnOn()
        {
            IsActivated = true;
            _sprite.color = Color.yellow;
        }

        public override void TurnOff()
        {
            IsActivated = false;
            _sprite.color = switchColour;
        }
    }
}