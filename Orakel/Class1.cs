using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Orakel.Input
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class UserInputService
    {
        private static readonly UserInputService instance = new UserInputService();
        private UserInputService() { }
        public static UserInputService Instance { get { return instance; } }


    }
}
