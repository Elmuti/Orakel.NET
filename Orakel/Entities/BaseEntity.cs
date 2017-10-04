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
    public delegate string ChangedEventHandler(object sender);
    public delegate void ChildAddedEventHandler(BaseEntity child);
    public delegate void ChildRemovedEventHandler(BaseEntity child);
     
    /// <summary>
    /// Base class for all classes in the type hierarchy. You cannot directly create BaseEntities.
    /// </summary>
    public class BaseEntity : IUpdatable, IDestroyable
    {
        private float _lifetime = 0f;
        private bool _archivable = true;
        private string _name = "";
        private BaseEntity _parent;
        HashSet<BaseEntity> _children = new HashSet<BaseEntity>();
        List<object> _tags = new List<object>();

        public event ChangedEventHandler Changed;
        public event ChildAddedEventHandler ChildAdded;
        public event ChildRemovedEventHandler ChildRemoved;


        public BaseEntity[] Children
        {
            get { return _children.ToArray(); }
        }

        /// <summary>
        /// Returns the full path of this entity
        /// </summary>
        public string FullName
        {
            get
            {
                if (Parent != null)
                    return Parent.FullName + "." + Name;
                else
                    return Name;
            }
        }


        internal void AddChild<C>(C ent) where C : BaseEntity
        {
            this.ChildAdded.Invoke(ent);
            _children.Add(ent);
        }

        internal void SetParent<C>(C parent) where C : BaseEntity
        {
            _parent = parent;
            parent.AddChild(this);
            //OnParentChanged(parent);
        }


        /// <summary>
        /// The tags this entity has
        /// </summary>
        public List<object> Tags
        {
            get
            {
                return _tags;
            }
        }

        /// <summary>
        /// Returns whether not the entity has the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>True if the entity has the specified tag</returns>
        public bool HasTag(object tag)
        {
            return _tags.Contains(tag);
        }


        public bool IsUpdated { get; }
        public bool IsDestroyable { get; }

        public void Destroy()
        {
            foreach (IDestroyable ent in Children)
            {
                ChildRemoved(this);
                ent.Destroy();
            }
        }

        public void Update(Time time)
        {
            float delta = time.SinceLastUpdate.Milliseconds / 1000f;
            _lifetime += delta;
        }

        /// <summary>
        /// Determines if an object can be Cloned or saved to file.
        /// </summary>
        public bool Archivable
        {
            get { return _archivable; }
            set { _archivable = value; }
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
                //Changed(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// The hierarchical parent of the object.
        /// </summary>
        public BaseEntity Parent
        {
            get { return _parent; }
            set
            {
                if (Parent != null)
                {
                    _parent.ChildRemoved(this);
                    _parent.RemoveChild(this);
                }
                SetParent(value);
            }
        }

        internal void RemoveChild(BaseEntity child)
        {
            _children.Remove(child);
        }

        /// <summary>
        /// Removes all descendants of the object.
        /// </summary>
        public void ClearAllChildren()
        {
            // TODO: WARNING: POSSIBLE MEMORY LEAK ???
            foreach(BaseEntity child in Children)
            {
                child.Destroy();
            }
            _children.Clear();
        }

        /// <summary>
        /// Returns the first child found with the given name, or null if no such child exists.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BaseEntity FindFirstChild(string name)
        {
            var matches = Children.Where(entity => entity.Name == name);
            if (matches.Count() > 0)
                return matches.First();
            else
                return null;
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
