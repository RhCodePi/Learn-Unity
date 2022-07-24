using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject restartBtn;// veya UnityEngine.UI kullanipta yapilabilir
                                                   // bu durumda GameObject yerine Direkt Button olarak tanimlama yapilabilr.
    [SerializeField] private GameObject titleScreen;
    private float spawnRate = 1.0f;
    private bool isGameActive;
    private int score, highScore;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score; 
    }

    public void HighScore()
    {
        if(score > highScore) highScore = score;
        highScoreText.text = "High Score : " + highScore;
        highScoreText.gameObject.SetActive(true);
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        HighScore();
        restartBtn.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(float difficult)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= difficult;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.SetActive(false);
    }
    public bool GetIsGameActive() {return isGameActive;}
}
