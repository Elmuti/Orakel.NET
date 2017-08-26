using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BulletSharp;


namespace Orakel
{
    public delegate void ChangedEventHandler(object sender, EventArgs e);
    public delegate void ChildAddedEventHandler(object sender, EventArgs e);
    public delegate void ChildRemovedEventHandler(object sender, EventArgs e);

    /// <summary>
    /// Base class for all classes in the type hierarchy. You cannot directly create BaseEntities.
    /// </summary>
    public class BaseEntity : Updatable, Destroyable
    {
        public event ChangedEventHandler Changed;
        public event ChildAddedEventHandler ChildAdded;
        public event ChildRemovedEventHandler ChildRemoved;

        bool Updatable.IsUpdated { get; }
        bool Destroyable.IsDestroyable { get; }

        void Updatable.Update(Time time)
        {

        }

        void Destroyable.Destroy()
        {

        }

        private List<BaseEntity> _children = new List<BaseEntity>();
        private bool _archivable = true;
        private string _name = "";
        private BaseEntity _parent;


        /// <summary>
        /// Determines if an object can be Cloned or saved to file.
        /// </summary>
        public bool Archivable
        {
            get { return _archivable; }
        }

        /// <summary>
        /// A non-unique identifier for the object.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Changed(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// The hierarchical parent of the object.
        /// </summary>
        public BaseEntity Parent
        {
            get { return _parent; }
        }

        /// <summary>
        /// Removes all descendants of the object.
        /// </summary>
        public void ClearAllChildren()
        {
            // WARNING: MEMORY LEAK ???
            // TODO: REMOVE ACTUAL INSTANCES INSTEAD OF CLEARING LIST
            _children.Clear();
        }

        /// <summary>
        /// Returns the first child found with the given name, or null if no such child exists.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BaseEntity FindFirstChild(string name)
        {
            var matches = _children.Where(entity => entity.Name == name);
            if (matches.Count() > 0)
                return matches.First();
            else
                return null;
        }
    }
}
