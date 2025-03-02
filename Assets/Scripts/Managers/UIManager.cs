using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;

    private void Start()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}
