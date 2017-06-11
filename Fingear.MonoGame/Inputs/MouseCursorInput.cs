﻿using System.Numerics;
using Fingear.Inputs;

namespace Fingear.MonoGame.Inputs
{
    public class MouseCursorInput : CursorInputBase
    {
        public override string DisplayName => "Mouse";
        public override IInputSource Source => InputSystem.Instance.Mouse;
        public override Vector2 Value => InputSystem.Instance.InputStates.MouseState.Position.AsSystemVector();
        public override Vector2 Maximum => new Vector2(float.PositiveInfinity, float.PositiveInfinity);
        public override Vector2 Minimum => Vector2.Zero;

        internal MouseCursorInput()
        {
        }
    }
}