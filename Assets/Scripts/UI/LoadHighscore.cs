using UnityEngine;
using UnityEngine.UI;

public class LoadHighscore : MonoBehaviour
{
    public Text highscoreText;

    private void Start()
    {
        highscoreText.text = PlayerPrefs.GetInt("highscore").ToString();
    }
}
