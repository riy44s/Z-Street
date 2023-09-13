using UnityEngine;
using Cinemachine;
using System.Collections.Generic;

public static class ThirdPerson
{
    private static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
    public static CinemachineVirtualCamera ActiveCamera = null;

    public static bool isActiveCamera(CinemachineVirtualCamera camera)
    {
        return camera == ActiveCamera;
    }

    public static void SwitchCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
        ActiveCamera = camera;

        foreach (CinemachineVirtualCamera c in cameras)
        {
            if (c != camera && c.Priority != 0)
            {
                c.Priority = 0;
            }
        }
    }

    public static void Register(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
     
    }

    public static void Unregister(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
       
    }
}

public class ThirdPersonLook : MonoBehaviour
{
    public CinemachineVirtualCamera[] cameras;
    private int currentCameraIndex = 0;

    private void Start()
    {
        foreach (CinemachineVirtualCamera camera in cameras)
        {
            ThirdPerson.Register(camera);
        }

        // Activate the initial camera
        ThirdPerson.SwitchCamera(cameras[currentCameraIndex]);
    }

    private void OnDestroy()
    {
        foreach (CinemachineVirtualCamera camera in cameras)
        {
            ThirdPerson.Unregister(camera);
        }
    }

    private void Update()
    {
        // Example input for switching cameras (you can customize this based on your input system)
        if (Input.GetKeyDown(KeyCode.V))
        {
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
            ThirdPerson.SwitchCamera(cameras[currentCameraIndex]);
        }

    }
}
