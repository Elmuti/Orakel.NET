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
    public struct ColouredVertex
    {
        public const int Size = (3 + 4) * 4; // size of struct in bytes

        private readonly OpenTK.Vector3 position;
        private readonly Color4 color;

        public ColouredVertex(OpenTK.Vector3 position, Color4 color)
        {
            this.position = position;
            this.color = color;
        }
    }

    public sealed class VertexBuffer<TVertex> : IDisposable where TVertex : struct // vertices must be structs so we can copy them to GPU memory easily
    {
        private readonly int vertexSize;
        private TVertex[] vertices = new TVertex[4];

        private int count;

        private readonly int handle;

        private bool disposed;

        private void dispose()
        {
            if (this.disposed)
                return;

            if (GraphicsContext.CurrentContext == null || GraphicsContext.CurrentContext.IsDisposed)
                return;

            //remove un-used vertex buffers from memory
            GL.DeleteBuffer(this.handle);

            this.disposed = true;
        }

        public void Dispose()
        {
            this.dispose();
            GC.SuppressFinalize(this);
        }

        public VertexBuffer(int vertexSize)
        {
            this.vertexSize = vertexSize;

            // generate the actual Vertex Buffer Object
            this.handle = GL.GenBuffer();
        }

        public void AddVertex(TVertex v)
        {
            // resize array if too small
            if (this.count == this.vertices.Length)
                Array.Resize(ref this.vertices, this.count * 2);
            // add vertex
            this.vertices[count] = v;
            this.count++;
        }

        public void Bind()
        {
            // make this the active array buffer
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.handle);
        }

        public void BufferData()
        {
            // copy contained vertices to GPU memory
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(this.vertexSize * this.count),
                this.vertices, BufferUsageHint.StreamDraw);
        }

        public void Draw()
        {
            // draw buffered vertices as triangles
            GL.DrawArrays(PrimitiveType.Triangles, 0, this.count);
        }
    }
}
