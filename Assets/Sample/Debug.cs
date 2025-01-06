using UnityEngine;

public class Debug : MonoBehaviour
{
    private void OnGUI()
    {
        var halfSize = new Vector2(Screen.width / 2, Screen.height / 2); 
        GUI.Label(new Rect(halfSize,halfSize), "Debug");
        GUI.Label(new Rect(0, 0, 100, 100), "Debug");
        // GUILayout.Label("Debug2");
    }
}