using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ExitGame : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("Exit button pressed.");

        #if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Stop play mode in the Editor
        #else
        Application.Quit(); // Quit the application
        #endif
    }
} 