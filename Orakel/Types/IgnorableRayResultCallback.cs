using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using BulletSharp;

namespace Orakel
{
    internal class IgnorableRayResultCallback : RayResultCallback
    {
        public bool Hit = false;
        public BulletSharp.Math.Vector3 HitNormalWorld;
        public BulletSharp.Math.Vector3 HitPointWorld;
        public BulletSharp.Math.Vector3 RayFromWorld;
        public BulletSharp.Math.Vector3 RayToWorld;

        private List<object> ignoreList;

        public override float AddSingleResult(LocalRayResult rayResult, bool normalInWorldSpace)
        {
            Debug.Assert(rayResult.HitFraction <= this.ClosestHitFraction, "invalid ray hit fraction");
            this.ClosestHitFraction = rayResult.HitFraction;
            this.CollisionObject = rayResult.CollisionObject;
            if (normalInWorldSpace)
            {
                HitNormalWorld = rayResult.HitNormalLocal;
            }
            else
            {
                BulletSharp.Math.Matrix om;
                this.CollisionObject.GetWorldTransform(out om);
                //this.HitNormalWorld = om.Basis * rayResult.HitNormalLocal;
            }
            
            return 0f;
        }

        public IgnorableRayResultCallback(ref Vector3 rayFromWorld, ref Vector3 rayToWorld, List<object> ignore)
        {
            this.RayFromWorld = rayFromWorld;
            this.RayToWorld = rayToWorld;
            this.ignoreList = ignore;
            foreach (object obj in ignore)
            {
                if (obj is PhysicsEntity)
                {
                    PhysicsEntity ent = obj as PhysicsEntity;
                }
            }
        }
    }
}
