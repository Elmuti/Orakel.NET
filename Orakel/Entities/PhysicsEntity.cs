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
    public delegate void TouchedEventHandler(BaseEntity hit);

    /// <summary>
    /// Base class for all physics-based Entities
    /// </summary>
    public abstract class PhysicsEntity : BaseEntity
    {
        private Vector3 _position = Vector3.Zero;
        private Vector3 _size = new Vector3(1, 1, 1);
        private Material _material = Material.Concrete;
        private bool _anchored = false;
        private bool _ignoreRays = false;

        internal RigidBody Rigidbody;

        public event TouchedEventHandler Touched;

        public Vector3 Position    { get { return _position; } set { _position = value; } }
        public Vector3 Size        { get { return _size; } set { _size = value; } }
        public Material Material   { get { return _material; } set { _material = value; } }
        public bool Anchored       { get { return _anchored; } set { _anchored = value; } }
        public bool IgnoreRays     { get { return _ignoreRays; } set { _ignoreRays = value; } }

        public float Mass
        {
            get
            {
                float volume = _size.X * _size.Y * _size.Z;
                float density = MaterialData.Attributes[_material].Density;
                return volume * density;
            }
        }

        public Vector3 GetHalfExtents()
        {
            return new Vector3(_size.X / 2, _size.Y / 2, _size.Z / 2);
        }


        protected virtual void Init()
        {
            RigidBodyConstructionInfo info = new RigidBodyConstructionInfo(Mass, new DefaultMotionState(), new BoxShape(GetHalfExtents()));
            Rigidbody = new RigidBody(info);
        }
    }
}


