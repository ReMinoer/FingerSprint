﻿using System;
using System.Collections.Generic;
using Fingear.Inputs.Base;
using Fingear.Utils;

namespace Fingear.Converters.Value
{
    public class ScaleToSwitchInput : PositionInputBase<bool>, ISwitchInput
    {
        public IScaleInput ScaleInput { get; set; }
        public Predicate<float> ValueSelector { get; set; }

        public override IInputSource Source => ScaleInput?.Source;
        public override bool Value => ScaleInput != null && ValueSelector(ScaleInput.Value);

        protected override IEnumerable<IInput> BaseInputs
        {
            get { yield return ScaleInput; }
        }

        public override string DisplayName
        {
            get
            {
                if (ScaleInput == null)
                    return "";

                string name = ValueSelector.Method.GetDelegateName();
                if (string.IsNullOrEmpty(name))
                    return $"{ScaleInput.DisplayName}";

                return $"{ScaleInput.DisplayName} {name}";
            }
        }

        public ScaleToSwitchInput()
        {
        }

        public ScaleToSwitchInput(IScaleInput scaleInput, Predicate<float> valueSelector)
        {
            ScaleInput = scaleInput;
            ValueSelector = valueSelector;
        }
        
        public override void Update()
        {
            ScaleInput.Update();
            base.Update();
        }
    }
}