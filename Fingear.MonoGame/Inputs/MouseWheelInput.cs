﻿using Fingear.Inputs;

namespace Fingear.MonoGame.Inputs
{
    public class MouseWheelInput : ScaleInputBase
    {
        public override string DisplayName => "Mouse Wheel";
        public override IInputSource Source => new MouseSource();
        public override float Value => MonoGameInputSytem.Instance.InputStates.MouseState.ScrollWheelValue;
        public override float Maximum => int.MaxValue;
        public override float Minimum => int.MinValue;
    }
}