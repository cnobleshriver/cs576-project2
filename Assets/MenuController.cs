using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button buttonScene1;
    public Button buttonScene2;

    void Start()
    {
        buttonScene1.onClick.AddListener(() => LoadScene("Scene1"));
        buttonScene2.onClick.AddListener(() => LoadScene("Scene2"));
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
