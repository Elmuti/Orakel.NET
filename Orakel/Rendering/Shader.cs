using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Platform;
using OpenTK.Graphics.OpenGL;
using BulletSharp;


namespace Orakel.Graphics
{
    public sealed class Shader
    {
        private readonly int handle;

        public int Handle { get { return this.handle; } }

        public Shader(ShaderType type, string code)
        {
            // create shader object
            this.handle = GL.CreateShader(type);

            // set source and compile shader
            GL.ShaderSource(this.handle, code);
            GL.CompileShader(this.handle);
        }
    }

    public sealed class ShaderProgram
    {
        private readonly int handle;

        public ShaderProgram(params Shader[] shaders)
        {
            // create program object
            this.handle = GL.CreateProgram();

            // assign all shaders
            foreach (var shader in shaders)
                GL.AttachShader(this.handle, shader.Handle);

            // link program (effectively compiles it)
            GL.LinkProgram(this.handle);

            // detach shaders
            foreach (var shader in shaders)
                GL.DetachShader(this.handle, shader.Handle);
        }

        public void Use()
        {
            // activate this program to be used
            GL.UseProgram(this.handle);
        }
    }
}
