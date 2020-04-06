using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class AutoSaveOnPlayExtension
{
    // Static constructor that gets called when unity fires up.
    static AutoSaveOnPlayExtension()
    {
        EditorApplication.playmodeStateChanged += AutoSaveWhenPlaymodeStarts;
    }

    private static void AutoSaveWhenPlaymodeStarts()
    {
        // If we're about to run the scene...
        if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
        {
            AutoSave();
        }
    }

    private static void AutoSave()
    {
        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
        AssetDatabase.SaveAssets();
        Debug.Log("Autosave carried out @: " + System.DateTime.Now);
    }
}