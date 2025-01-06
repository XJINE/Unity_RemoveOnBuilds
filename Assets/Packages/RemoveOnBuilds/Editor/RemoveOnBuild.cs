using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR

namespace RemoveOnBuilds
{
    public abstract class RemoveOnBuild : IProcessSceneWithReport, IPreprocessBuildWithReport, IPostprocessBuildWithReport
    {
        #region Field

        private bool _onProcessSceneCalled = false;

        #endregion Field

        #region Property

        public    virtual int  callbackOrder                      => 0;
        protected virtual bool RemoveInEditorApplication { get; } = false;
        protected virtual bool IgnoreDevelopmentBuild    { get; } = false;

        #endregion Property

        #region Method

        public void OnPreprocessBuild(BuildReport report)
        {
            _onProcessSceneCalled = false;
        }

        public void OnProcessScene(Scene scene, BuildReport report)
        {
            _onProcessSceneCalled = true;

            if ((!RemoveInEditorApplication && EditorApplication.isPlaying))
            {
                return;
            }

            if (BuildPipeline.isBuildingPlayer)
            {
                var developmentBuild = (report.summary.options & BuildOptions.Development) != 0;

                if (IgnoreDevelopmentBuild && developmentBuild)
                {
                    return;
                }
            }

            RemoveTargets(scene);
        }

        public void OnPostprocessBuild(BuildReport report)
        {
            if (!_onProcessSceneCalled)
            {
                UnityEngine.Debug.Log(GetType().Name + ".OnProcessScene was not called. Use 'Clean Build' if needed.");
            }
            else
            {
                UnityEngine.Debug.Log(GetType().Name + " executed in OnProcessScene.");
            }
        }

        protected abstract void RemoveTargets(Scene scene);

        #endregion Method
    }
}

#endif