using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text roundText;

    public SceneFader sceneFader;

    public string levelToLoad = "MainMenu";

    private void OnEnable()
    {
        roundText.text = PlayerStats.Rounds.ToString();
    }
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        sceneFader.FadeTo(levelToLoad);
    }
}
