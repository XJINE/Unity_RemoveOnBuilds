using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR

namespace RemoveOnBuilds
{
    // NOTE:
    // Consider using the default 'EditorOnly' tag.
    // CAUTION:
    // Need abstract.
    public abstract class RemoveTaggedObjectsOnBuild : RemoveOnBuild
    {
        #region Property

        protected virtual string Tag { get; } = string.Empty;

        #endregion Property

        protected override void RemoveTargets(Scene scene)
        {
            if (string.IsNullOrEmpty(Tag))
            {
                return;
            }

            var rootObjects = scene.GetRootGameObjects();
            var removeObjects = new List<GameObject>();

            foreach (var rootObject in rootObjects)
            {
                foreach (var childTransform in rootObject.GetComponentsInChildren<Transform>(true))
                {
                    if (childTransform.gameObject.CompareTag(Tag))
                    {
                        removeObjects.Add(childTransform.gameObject);
                    }
                }
            }

            foreach (var removeObject in removeObjects)
            {
                Object.DestroyImmediate(removeObject);
            }
        }
    }
}

#endif