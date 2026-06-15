using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;

    private float spawnRate = 1.0f;
    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate = 1.0f;           
        StartCoroutine(SpawnTarget());
        UpdateScore(0);   
    }

    IEnumerator SpawnTarget()
    { 
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int indesx = Random.Range(0, targets.Count);
            Instantiate(targets[indesx]);
        }

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
