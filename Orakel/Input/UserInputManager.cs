using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Orakel.Input
{
    public class PlayerMouse
    {
        private List<MouseButtons> _buttonsDown = new List<MouseButtons>();

        public int X = 0;
        public int Y = 0;
        public int ScrollWheel = 0;

        public MouseButtons[] GetButtonsDown()
        {
            return _buttonsDown.ToArray();
        }

        public bool IsButtonDown(MouseButtons button)
        {
            return _buttonsDown.Contains(button);
        }

        public Vector2 GetPosition()
        {
            return new Vector2(X, Y);
        }

        public PlayerMouse(MouseState state)
        {
            X = state.X;
            Y = state.Y;
            ScrollWheel = state.ScrollWheelValue;
            if (state.LeftButton == ButtonState.Pressed) { _buttonsDown.Add(MouseButtons.LeftButton); }
            if (state.MiddleButton == ButtonState.Pressed) { _buttonsDown.Add(MouseButtons.MiddleButton); }
            if (state.RightButton == ButtonState.Pressed) { _buttonsDown.Add(MouseButtons.RightButton); }
            if (state.XButton1 == ButtonState.Pressed) { _buttonsDown.Add(MouseButtons.XButton1); }
            if (state.XButton2 == ButtonState.Pressed) { _buttonsDown.Add(MouseButtons.XButton2); }
        }
    }



    /// <summary>
    /// 
    /// </summary>
    public class UserInputManager : Updatable
    {
        private KeyboardState _kbstate = Keyboard.GetState();
        private MouseState _mousestate = Mouse.GetState();

        bool Updatable.IsUpdated { get; }

        void Updatable.Update(Time time)
        {
            _kbstate = Keyboard.GetState();
            _mousestate = Mouse.GetState();
        }

        public KeyboardState GetKeyboardState()
        {
            return _kbstate;
        }

        public PlayerMouse GetMouse()
        {
            return new PlayerMouse(_mousestate);
        }

        public bool IsKeyDown(Orakel.Input.Keys key)
        {
            return _kbstate.IsKeyDown((Microsoft.Xna.Framework.Input.Keys)key);
        }

        public bool IsKeyUp(Orakel.Input.Keys key)
        {
            return _kbstate.IsKeyUp((Microsoft.Xna.Framework.Input.Keys)key);
        }

        public Orakel.Input.Keys[] GetKeysDown()
        {
            List<Orakel.Input.Keys> orakelkeys = new List<Orakel.Input.Keys>();
            foreach (Microsoft.Xna.Framework.Input.Keys k in _kbstate.GetPressedKeys())
            {
                orakelkeys.Add((Orakel.Input.Keys)k);
            }

            return orakelkeys.ToArray();
        }
    }
}
