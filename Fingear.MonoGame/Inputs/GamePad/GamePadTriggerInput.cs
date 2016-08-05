﻿using System;
using Fingear.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame.Inputs.GamePad
{
    public class GamePadTriggerInput : IntensityInputBase
    {
        public PlayerIndex PlayerIndex { get; }
        public GamePadTrigger Trigger { get; }
        public override IInputSource Source => new GamePadSource(PlayerIndex);
        public override float Maximum => 1;
        public override float Minimum => 0;
        public override float IdleValue => 0;

        public override float Value
        {
            get
            {
                GamePadState gamePadState = InputStates.Instance.GamePadStates[PlayerIndex];
                switch (Trigger)
                {
                    case GamePadTrigger.Left: return gamePadState.Triggers.Left;
                    case GamePadTrigger.Right: return gamePadState.Triggers.Right;
                    default: throw new NotSupportedException();
                }
            }
        }

        public GamePadTriggerInput(PlayerIndex playerIndex, GamePadTrigger trigger)
        {
            PlayerIndex = playerIndex;
            Trigger = trigger;
        }
    }
}