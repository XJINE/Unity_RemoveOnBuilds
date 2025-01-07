using UnityEngine;

public class Debug : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 100), "Debug");
    }
}