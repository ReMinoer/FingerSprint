﻿using System.Collections.Generic;
using System.Numerics;
using Fingear.Inputs.Base;
using Fingear.Utils;

namespace Fingear.Inputs.Converters.Activity
{
    public class CursorToJoystickInput : ForceInputBase<Vector2>, IJoystickInput
    {
        public ICursorInput CursorInput { get; set; }
        public Vector2 DeltaMin { get; }
        public Vector2 DeltaMax { get; }

        public override string DisplayName => CursorInput?.DisplayName ?? "";
        public override Vector2 Value => CursorInput?.Delta.Clamp(DeltaMin, DeltaMax).ReLerp(DeltaMin, DeltaMax, Minimum, Maximum) ?? Vector2.Zero;
        public override Vector2 IdleValue => Vector2.Zero;
        public override IInputSource Source => CursorInput?.Source;
        public Vector2 Maximum => Vector2.One;
        public Vector2 Minimum => -Vector2.One;
        public Vector2 Delta => Value - LastValue;

        protected override IEnumerable<IInput> BaseInputs
        {
            get { yield return CursorInput; }
        }

        public CursorToJoystickInput()
            : this(-Vector2.One, Vector2.One)
        {
        }

        public CursorToJoystickInput(Vector2 deltaMin, Vector2 deltaMax)
        {
            DeltaMin = deltaMin;
            DeltaMax = deltaMax;
        }

        public CursorToJoystickInput(ICursorInput cursorInput)
            : this(cursorInput , - Vector2.One, Vector2.One)
        {
        }

        public CursorToJoystickInput(ICursorInput cursorInput, Vector2 deltaMin, Vector2 deltaMax)
            : this(deltaMin, deltaMax)
        {
            CursorInput = cursorInput;
            DeltaMin = deltaMin;
            DeltaMax = deltaMax;
        }

        public override void Update()
        {
            CursorInput?.Update();
            base.Update();
        }
    }
}