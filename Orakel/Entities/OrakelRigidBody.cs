using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulletSharp;

namespace Orakel
{
    public class OrakelRigidBody : RigidBody
    {
        string _id;

        public string Guid { get { return _id; } }

        public OrakelRigidBody(RigidBodyConstructionInfo constructionInfo, string id)
        :base(constructionInfo) {
            _id = id;
        }
    }

}
