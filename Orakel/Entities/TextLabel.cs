using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Platform;
using OpenTK.Graphics.OpenGL;
using BulletSharp;

namespace Orakel
{
    public class TextLabel : GuiObject
    {
        private Font _font;
        private string _text = "TextLabel";
        private Color4 _textColor = Color4.Black;
        private bool _textScaled = false;
        private int _textSize = 12;
        private Color4 _textStrokeColor = new Color4(0, 0, 0, 255);
        private bool _textWrapped = false;
        private TextXAlignment _textXAlignment = TextXAlignment.Center;
        private TextYAlignment _textYAlignment = TextYAlignment.Center;

        public Font Font                       { get { return _font; }            set { _font = value; } }
        public string Text                     { get { return _text; }            set { _text = value; } }
        public Color4 TextColor                { get { return _textColor; }       set { _textColor = value; } }
        public bool TextScaled                 { get { return _textScaled; }      set { _textScaled = value; } }
        public int TextSize                    { get { return _textSize; }        set { _textSize = value; } }
        public Color4 TextStrokeColor          { get { return _textStrokeColor; } set { _textStrokeColor = value; } }
        public bool TextWrapped                { get { return _textWrapped; }     set { _textWrapped = value; } }
        public TextXAlignment TextXAlignment   { get { return _textXAlignment; }  set { _textXAlignment = value; } }
        public TextYAlignment TextYAlignment   { get { return _textYAlignment; }  set { _textYAlignment = value; } }


        public Vector2 TextBounds
        {
            get
            {
                return Vector2.Zero;
            }
        }

        public bool TextFits
        {
            get
            {
                return true;
            }
        }

        public TextLabel(UDim2 pos, UDim2 size, string text)
        {
            Position = pos;
            Size = size;
            Text = text;
        }

        public TextLabel()
        {

        }
    }
}
