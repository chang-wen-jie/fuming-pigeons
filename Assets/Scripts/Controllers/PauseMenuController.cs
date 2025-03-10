using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuScreen;

    private void Start()
    {
        pauseMenuScreen.SetActive(false);
    }

    public void ToggleMenu()
    {
        pauseMenuScreen.SetActive(!pauseMenuScreen.activeSelf);
    }

    public void SkipLevel()
    {
        pauseMenuScreen.SetActive(!pauseMenuScreen.activeSelf);
    }
}