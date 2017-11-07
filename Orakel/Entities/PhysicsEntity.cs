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
    public abstract class PhysicsEntity : BaseEntity
    {
        string _id;

        protected Vector3 _position = Vector3.Zero;
        protected Vector3 _size = new Vector3(1, 1, 1);
        protected Material _material = Material.Concrete;
        protected bool _anchored = false;
        protected bool _ignoreRays = false;
        protected ScriptSignal touched = new ScriptSignal();

        internal OrakelRigidBody Rigidbody;

        public string Id             { get { return _id; } }
        public Vector3 Position      { get { return _position; }    set { _position = value; } }
        public Vector3 Size          { get { return _size; }        set { _size = value; } }
        public bool Anchored         { get { return _anchored; }    set { _anchored = value; } }
        public bool IgnoreRays       { get { return _ignoreRays; }  set { _ignoreRays = value; } }
        public ScriptSignal Touched  { get { return touched; } }


        public Material Material
        {
            get {
                return _material;
            }
            set {
                _material = value;
                Rigidbody.SetMassProps(Mass, Vector3.Zero);
            }
        }

        public float Mass
        {
            get {
                float volume = _size.X * _size.Y * _size.Z;
                float density = MaterialData.Attributes[_material].Density;
                return volume * density;
            }
        }

        public Vector3 GetHalfExtents()
        {
            return new Vector3(_size.X / 2, _size.Y / 2, _size.Z / 2);
        }


        protected virtual void Initialize()
        {
            RigidBodyConstructionInfo info = new RigidBodyConstructionInfo(Mass, new DefaultMotionState(), new BoxShape(GetHalfExtents()));
            this._id = Guid.NewGuid().ToString();
            Rigidbody = new OrakelRigidBody(info, Id);
        }
    }
}


