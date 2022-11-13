using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LooseScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int menuScene;
    [SerializeField] private int gamePlayScene;

    public void MenuButton() => SceneManager.LoadScene(menuScene);

    public void RestartButton() => SceneManager.LoadScene(gamePlayScene);

    private void Start() => scoreText.text = "Score " + GamePlayScreen.Score;

}
