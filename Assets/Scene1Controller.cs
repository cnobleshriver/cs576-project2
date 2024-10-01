using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1Controller : MonoBehaviour
{
    public Camera activeCamera; 

    void Update()
    {
        if (activeCamera == null) return;

        // Return to main menu when ball is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = activeCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
    }
}
