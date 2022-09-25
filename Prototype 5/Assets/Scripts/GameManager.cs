using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // UI text
using UnityEngine.SceneManagement; // Restart game

public class GameManager : MonoBehaviour
{
    private float spawnInterval = 1.0f;
    private int score;

    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public GameObject endScreen;
    public GameObject titleScreen;

    public bool isGameActive;

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnInterval);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnInterval /= difficulty;

        titleScreen.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        endScreen.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
