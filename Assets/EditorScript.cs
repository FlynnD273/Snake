using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditor.SceneManagement;

class EditorScrips : EditorWindow
{

    [MenuItem("Play/PlayMe _%h")]
    public static void RunMainScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/TitleScene.unity");
        EditorApplication.isPlaying = true;
    }
}