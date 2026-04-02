using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	public GameObject gameOverPanel;
	public TextMeshProUGUI finalScoreText;
	public TextMeshProUGUI highScoreText;
	ScoreManager scoreManager;

	int finalScore;
	int highScore;

	void Awake()
	{
		scoreManager = GetComponent<ScoreManager>();
	}

	public void GameOver()
	{

		finalScore = scoreManager.GetCurrentScore();
		highScore = PlayerPrefs.GetInt("HighScore", 0);

		scoreManager.StopScore();

		finalScoreText.text = "Score: " + finalScore;
		highScoreText.text = "High Score: " + highScore;

		gameOverPanel.SetActive(true);
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(0);
	}

	public void QuitGame()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}
