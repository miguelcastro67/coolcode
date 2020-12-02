using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CoolCode
{
    public abstract class ObjectBase
    {
        protected bool _IsDirty = false;

        public bool IsDirty
        {
            get => _IsDirty;
            set => _IsDirty = value;
        }
        
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            _IsDirty = true;
        }

        protected void WalkObjectGraph(Func<ObjectBase, bool> snippetForObject,
                               Action<IList> snippetForCollection)
        {
            List<object> visited = new List<object>();
            Action<ObjectBase> walk = null;

            walk = (o) =>
            {
                if (o != null && !visited.Contains(o))
                {
                    visited.Add(o);
                    
                    bool exitWalk = snippetForObject.Invoke(o);

                    if (!exitWalk)
                    {
                        List<PropertyItem> properties = o.GetProperties();
                        foreach (PropertyItem property in properties)
                        {
                            if (property.Name != "IsDirty")
                            {
                                if (property.Kind == PropertyKind.Complex)
                                {
                                    ObjectBase obj = (ObjectBase)(property.Value);
                                    walk(obj);
                                }
                                else
                                {
                                    IList coll = property.Value as IList;
                                    if (coll != null)
                                    {
                                        snippetForCollection.Invoke(coll);

                                        foreach (object item in coll)
                                        {
                                            if (item is ObjectBase)
                                                walk((ObjectBase)item);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            walk(this);
        }

        public void CleanAll()
        {
            WalkObjectGraph(
            o =>
            {
                o._IsDirty = false;
                return false; // do NOT short-circuit
            }, coll => { });
        }

        public List<ObjectBase> GetDirtyObjects()
        {
            List<ObjectBase> dirtyObjects = new List<ObjectBase>();

            WalkObjectGraph(
            o =>
            {
                if (o._IsDirty)
                {
                    dirtyObjects.Add( o);
                }

                return false; // do NOT short-circuit
            }, coll => { });

            return dirtyObjects;
        }

        public virtual bool IsAnythingDirty()
        {
            bool isDirty = false;

            WalkObjectGraph(
            o =>
            {
                if (o._IsDirty)
                {
                    isDirty = true;
                    return true; // short circuit
                }
                else
                    return false;
            }, coll => { });

            return isDirty;
        }
    }
}
