using System;
using Orakel;
//using Microsoft.Xna.Framework;
//using OpenTK;
//using OpenTK.Graphics;
using Orakel.Graphics;

namespace OrakelGame
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
            game.Run();
            //Orakel.Graphics.GameWindow wnd = new Orakel.Graphics.GameWindow();
            //wnd.Run();
            //VertexBuffer<ColouredVertex> b = new VertexBuffer<ColouredVertex>(3);
            //b.AddVertex(new ColouredVertex(new OpenTK.Vector3(0, 5, 0), new Color4(255, 255, 255, 255)));
            //b.AddVertex(new ColouredVertex(new OpenTK.Vector3(2.5f, 0, 0), new Color4(255, 255, 255, 255)));
            //b.AddVertex(new ColouredVertex(new OpenTK.Vector3(-2.5f, 0, 0), new Color4(255, 255, 255, 255)));
        }
    }
}
