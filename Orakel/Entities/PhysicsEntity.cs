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
    /// <summary>
    /// Base class for all physics-based Entities
    /// </summary>
    public class PhysicsEntity : BaseEntity
    {
        Vector3 _position = Vector3.Zero;
        Vector3 _size = new Vector3(1, 1, 1);

        internal RigidBody Rigidbody;

        public Vector3 Position { get { return _position; } set { _position = value; } }
        public Vector3 Size { get { return _size; } set { _size = value; } }
        public Material Material = Material.Concrete;
        public bool Anchored = false;
        public bool IgnoreRays = false;

        /// <summary>
        /// Gets the total mass of the entity
        /// </summary>
        public float Mass
        {
            get
            {
                float volume = _size.X * _size.Y * _size.Z;
                float density = MaterialData.MaterialAttributes[this.Material].Density;
                return volume * density;
            }
        }

        public Vector3 GetHalfExtents()
        {
            return new Vector3(_size.X / 2, _size.Y / 2, _size.Z / 2);
        }


        void Init()
        {
            RigidBodyConstructionInfo info = new RigidBodyConstructionInfo(Mass, new DefaultMotionState(), new BoxShape(GetHalfExtents()));
            Rigidbody = new RigidBody(info);
        }


        public PhysicsEntity(Vector3 position)
        {
            _position = position;
            Init();
        }

        public PhysicsEntity(Vector3 position, Vector3 size)
        {
            _position = position;
            _size = size;
            Init();
        }

        public PhysicsEntity(Vector3 position, Vector3 size, Material mat)
        {
            _position = position;
            _size = size;
            Material = mat;
            Init();
        }
    }
}
