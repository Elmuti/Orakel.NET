using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Platform;
using OpenTK.Graphics.OpenGL;

namespace Orakel.Graphics
{
    public class Renderer
    {
        //Drawlist
        private List<IDrawable> RenderList = new List<IDrawable>();



        public void SortByZIndex()
        {
            RenderList = RenderList.OrderBy(o => o.ZIndex).ToList();
        }

        public void Init()
        {

        }


        public void Draw(Time time)
        {
        }

        public Renderer()
        {

        }
    }
}
