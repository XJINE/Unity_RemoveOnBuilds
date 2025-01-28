using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR

namespace RemoveOnBuilds
{
    // CAUTION:
    // Marked as abstract to prevent this class from being called during the build process.
    public abstract class RemoveComponentsOnBuild<T> : RemoveOnBuild where T : Component
    {
        protected virtual bool RemoveEmptyParentObject { get; } = true;

        protected override void RemoveTargets(Scene scene)
        {
            var rootObjects      = scene.GetRootGameObjects();
            var removeComponents = new List<Component>();
            var removeObjects    = new List<GameObject>();
        
            foreach (var rootObject in rootObjects)
            {
                foreach (var childTransform in rootObject.GetComponentsInChildren<Transform>(true))
                {
                    var gameObject = childTransform.gameObject;
                    var components = childTransform.GetComponents<Component>();

                    if(components.Length == 0)
                    {
                        continue;
                    }

                    var founds = components.Where(component => component.GetType() == typeof(T)).ToArray();

                    // CAUTION:
                    // '+1' to account for the Transform component.
                    if(RemoveEmptyParentObject && components.Length == founds.Length + 1 && founds.Length != 0)
                    {
                        removeObjects.Add(gameObject);
                    }
                    else
                    {
                        removeComponents.AddRange(founds);
                    }

                    // DEBUG:
                    // Debug.Log(gameObject.name + " : " + founds.Count() + " / " + components.Length);
                }
            }

            foreach (var removeComponent in removeComponents)
            {
                Object.DestroyImmediate(removeComponent);
            }

            foreach (var removeObject in removeObjects)
            {
                Object.DestroyImmediate(removeObject);
            }
        }
    }
}

#endif