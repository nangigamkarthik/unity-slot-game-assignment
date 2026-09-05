#if UNITY_EDITOR
using UnityEditor;

namespace SlotGame.Editor
{
    public static class BuildScript
    {
        [MenuItem("SlotGame/Build WebGL")]
        public static void BuildWebGL()
        {
            string[] scenes = new string[] { "Assets/Core/Scenes/SlotGameScene.unity" };
            string buildPath = "Build/WebGL";

            BuildPlayerOptions options = new BuildPlayerOptions
            {
                scenes = scenes,
                locationPathName = buildPath,
                target = BuildTarget.WebGL,
                options = BuildOptions.None
            };

            BuildPipeline.BuildPlayer(options);
        }
    }
}
#endif
