using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	public Transform player;
	public TextMeshProUGUI scoreText;

	float startHeight;
	float maxHeight;
	int highScore;

	bool isGameOver = false;

	void Start()
	{
		startHeight = player.position.y;
		maxHeight = startHeight;

		// 저장된 최고 점수 불러오기
		highScore = PlayerPrefs.GetInt("HighScore", 0);
	}

	void Update()
	{
		if (isGameOver) { return; }

		if (player.position.y > maxHeight)
		{
			maxHeight = player.position.y;
		}

		int currentScore = Mathf.FloorToInt(maxHeight - startHeight);

		// 최고 점수 갱신
		if (currentScore > highScore)
		{
			highScore = currentScore;
			PlayerPrefs.SetInt("HighScore", highScore);
		}

		scoreText.text =
			"Score: " + currentScore +
			"\nHigh Score: " + highScore;
	}

	public int GetCurrentScore()
	{
		return Mathf.FloorToInt(maxHeight - startHeight);
	}

	public void StopScore()
	{
		isGameOver = true;
	}

}