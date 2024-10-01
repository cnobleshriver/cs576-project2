using UnityEngine;

public class Scene2CameraSwitcher : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Scene2Controller scene2Controller;

    private Camera activeCamera;

    void Start()
    {
        activeCamera = camera1;
        camera1.enabled = true;
        camera2.enabled = false;
        scene2Controller.activeCamera = activeCamera; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        if (activeCamera == camera1)
        {
            camera1.enabled = false;
            camera2.enabled = true;
            activeCamera = camera2;
        }
        else
        {
            camera1.enabled = true;
            camera2.enabled = false;
            activeCamera = camera1;
        }

        scene2Controller.activeCamera = activeCamera;
    }
}
