using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Orakel.Input
{
    /// <summary>
    /// An Object that represents the current state of the player's mouse.
    /// </summary>
    public class PlayerMouse
    {
        private List<MouseButtons> _buttonsDown = new List<MouseButtons>();

        /// <summary>
        /// Screen position of the mouse cursor on the X-axis.
        /// </summary>
        public int X = 0;

        /// <summary>
        /// Screen position of the mouse cursor on the Y-axis.
        /// </summary>
        public int Y = 0;

        /// <summary>
        /// 
        /// </summary>
        public int ScrollWheel = 0;

        /// <summary>
        /// Returns a list of mouse buttons being pressed
        /// </summary>
        /// <returns></returns>
        public MouseButtons[] GetButtonsDown()
        {
            return _buttonsDown.ToArray();
        }

        /// <summary>
        /// Returns if a mouse button is being pressed
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public bool IsButtonDown(MouseButtons button)
        {
            return _buttonsDown.Contains(button);
        }

        /// <summary>
        /// Gets the two-dimensional coordinates of the mouse cursor
        /// </summary>
        /// <returns></returns>
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
    public class UserInputManager : IUpdatable
    {
        private KeyboardState _kbstate = Keyboard.GetState();
        private MouseState _mousestate = Mouse.GetState();

        public bool IsUpdated { get; }

        public void Update(Time time)
        {
            _kbstate = Keyboard.GetState();
            _mousestate = Mouse.GetState();
        }

        public KeyboardState GetKeyboardState()
        {
            return _kbstate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PlayerMouse GetMouse()
        {
            return new PlayerMouse(_mousestate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyDown(Orakel.Input.Keys key)
        {
            return _kbstate.IsKeyDown((Microsoft.Xna.Framework.Input.Keys)key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyUp(Orakel.Input.Keys key)
        {
            return _kbstate.IsKeyUp((Microsoft.Xna.Framework.Input.Keys)key);
        }

        /// <summary>
        /// Get the list of keys currently being pressed
        /// </summary>
        /// <returns></returns>
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
