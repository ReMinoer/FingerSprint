﻿using System.Collections.Generic;
using System.Linq;
using Stave;

namespace Fingear.Controls.Base
{
    public abstract class ControlContainerBase<TControls> : Container<IControl, IControlParent, TControls>, IControlContainer<TControls>
        where TControls : class, IControl
    {
        public IInputSource Source { get; protected set; }
        public virtual IEnumerable<IInput> Inputs => Components.SelectMany(x => x.Inputs);

        public virtual void Update(float elapsedTime)
        {
            foreach (IInput input in Inputs)
                input.Update();

            foreach (TControls control in Components)
                control.Update(elapsedTime);
        }

        public abstract bool IsTriggered();
    }

    public abstract class ControlContainerBase<TControls, TValue> : ControlContainerBase<TControls>, IControlContainer<TControls, TValue>
        where TControls : class, IControl
    {
        public override sealed bool IsTriggered()
        {
            TValue value;
            return IsTriggered(out value);
        }

        public abstract bool IsTriggered(out TValue value);
    }
}