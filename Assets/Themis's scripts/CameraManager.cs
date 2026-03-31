using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public AnimatronicAI[] animatronics;

    public void OpenCamera(string cameraName)
    {
        foreach (AnimatronicAI npc in animatronics)
        {
            npc.CheckCamera(cameraName);
        }
    }
}