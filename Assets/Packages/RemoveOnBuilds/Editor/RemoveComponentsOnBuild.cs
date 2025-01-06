using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR

namespace RemoveOnBuilds
{
    // CAUTION:
    // Need abstract.
    public abstract class RemoveComponentsOnBuild<T> : RemoveOnBuild where T : Component
    {
        protected virtual bool RemoveParentObject { get; } = false;

        protected override void RemoveTargets(Scene scene)
        {
            var rootObjects      = scene.GetRootGameObjects();
            var removeComponents = new List<T>();
            var removeObjects    = new List<GameObject>();
        
            foreach (var rootObject in rootObjects)
            {
                foreach (var childTransform in rootObject.GetComponentsInChildren<Transform>(true))
                {
                    var childGameObject = childTransform.gameObject;
                    var childComponent  = childTransform.GetComponent<T>();
        
                    if (childComponent == null)
                    {
                        continue;
                    }
        
                    if (RemoveParentObject)
                    {
                        removeObjects.Add(childGameObject);
                    }
                    else
                    {
                        removeComponents.Add(childComponent);
                    }
                }
            }
        
            foreach (var removeObject in removeObjects)
            {
                Object.DestroyImmediate(removeObject);
            }
        
            foreach (var removeComponent in removeComponents)
            {
                Object.DestroyImmediate(removeComponent);
            }
        }
    }
}

#endif