using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BulletSharp;
using System.Runtime.Serialization;

namespace Orakel
{
    public class Workspace : BaseEntity
    {
        internal BroadphaseInterface broadphase;
        DefaultCollisionConfiguration collisionConfiguration;
        CollisionDispatcher dispatcher;
        SequentialImpulseConstraintSolver solver;
        internal DiscreteDynamicsWorld dynamicsWorld;
        internal CollisionWorld collisionWorld;

        private float _runtime = 0f;
        private Vector3 _gravity = new Vector3(0, -9.81f, 0);


        public float DistributedGameTime { get { return _runtime; } }
        public Vector3 Gravity
        {
            get { return _gravity; }
            set {
                if (dynamicsWorld != null)
                {
                    BulletSharp.Math.Vector3 grav = value;
                    dynamicsWorld.SetGravity(ref grav);
                }
            }
        }

        protected override void AddChild<C>(C ent)
        {
            base.AddChild(ent);
            if (ent is PhysicsEntity)
            {
                dynamicsWorld.AddRigidBody((ent as PhysicsEntity).Rigidbody);
            }
        }



        public RayResult FindEntityOnRay(Ray ray, PhysicsEntity ignore = null)
        {
            RayResult result = new RayResult();

            if (collisionWorld != null)
            {
                BulletSharp.Math.Vector3 start = ray.Origin;
                BulletSharp.Math.Vector3 end = ray.Origin + ray.Direction;

                ClosestRayResultCallback callback = new ClosestRayResultCallback(ref start, ref end);
                collisionWorld.RayTest(start, end, callback);

                if (callback.HasHit && callback.CollisionObject != ignore.Rigidbody)
                {
                    result.Position = callback.HitPointWorld;
                    result.Normal = callback.HitNormalWorld;
                    //result.Hit = callback.CollisionObject;
                }
            }
            return result;
        }

        internal void Initialize()
        {
            // Build the broadphase
            broadphase = new DbvtBroadphase();

            // Set up the collision configuration and dispatcher
            collisionConfiguration = new DefaultCollisionConfiguration();
            dispatcher = new CollisionDispatcher(collisionConfiguration);

            // The actual physics solver
            solver = new SequentialImpulseConstraintSolver();

            // The world
            dynamicsWorld = new DiscreteDynamicsWorld(dispatcher, broadphase, solver, collisionConfiguration);
            BulletSharp.Math.Vector3 grav = Gravity;
            dynamicsWorld.SetGravity(ref grav);
            collisionWorld = new CollisionWorld(dispatcher, broadphase, collisionConfiguration);
        }

        public Workspace()
        {
            Name = "Workspace";
            this.Initialize();
        }
    }
}
