using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> listOfTargets;
    public float spawnRate = 1f;
    public TextMeshProUGUI scoreText;
    private int score;

    public TextMeshProUGUI gameOverText;
    public bool isGameActive = false;

    public Button restart;

    public GameObject titleScreen;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, listOfTargets.Count);
            Instantiate(listOfTargets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOverMenu()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(float difficulty)
    {
        titleScreen.SetActive(false);
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
    }
}
