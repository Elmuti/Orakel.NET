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
    /// <summary>
    /// Base class for all classes in the type hierarchy. You cannot directly create BaseEntities.
    /// </summary>
    public abstract class BaseEntity : IUpdatable, IDestroyable
    {
        HashSet<BaseEntity> _children = new HashSet<BaseEntity>();
        List<object> _tags = new List<object>();

        protected float _lifetime = 0f;
        protected bool _archivable = true;
        protected string _name = "";
        protected BaseEntity _parent;

        public ScriptSignal ChildAdded         = new ScriptSignal();
        public ScriptSignal ChildRemoved       = new ScriptSignal();
        public ScriptSignal ParentChanged      = new ScriptSignal();
        public ScriptSignal DescendantAdded    = new ScriptSignal();
        public ScriptSignal DescendantRemoved  = new ScriptSignal();
        public ScriptSignal AncestryChanged    = new ScriptSignal();

        public BaseEntity[] Children
        {
            get { return _children.ToArray(); }
        }
        
        /// <summary>
        /// Returns the full hierarchical path of this entity
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


        protected virtual void AddChild<C>(C ent) where C : BaseEntity
        {
            ChildAdded.Fire(ent);
            _children.Add(ent);
        }

        protected virtual void SetParent<C>(C parent) where C : BaseEntity
        {
            _parent = parent;
            parent.AddChild(this);
            ParentChanged.Fire(parent);
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
                ChildRemoved.Fire(Parent);
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
        public bool Archivable { get; set; }

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
                    _parent.ChildRemoved.Fire(this);
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


        internal static BaseEntity FindFirstAncestorRecursive(BaseEntity parent, string name)
        {
            if (parent.Name == name)
            {
                return parent;
            }
            else
            {
                if (parent.Parent != null)
                    return FindFirstAncestorRecursive(parent.Parent, name);
                else
                    return null;
            }
        }

        /// <summary>
        /// Returns the first ancestor found with the given name, or null if no such ancestor exists.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BaseEntity FindFirstAncestor(string name)
        {
            if (Parent != null)
                return FindFirstAncestorRecursive(this, name);

            return null;
        }


        public override string ToString()
        {
            return FullName;
        }
    }
}
