using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    public GameObject ball;
    public float spawnTime;
    float m_spawnTime;

    int m_score = 0;
    bool m_isGameover;

    UIManager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score: " + m_score);
    }

    void Update()
    {
        m_spawnTime -= Time.deltaTime;

        if (m_isGameover)
        {
            m_spawnTime = 0;
            return; 
        }

        if (m_spawnTime <= 0)
        {
            SpawnBall();
            m_spawnTime = spawnTime;
        }
    }

    public void SpawnBall()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-7, 7), 6);

        if (ball)
        {
            Instantiate(ball, spawnPos, Quaternion.identity);
        }
    }


    public void Replay()
    {
        
        Time.timeScale = 1f;

        m_score = 0;
        m_isGameover = false;
        m_spawnTime = 0;

        GameObject[] currentBalls = GameObject.FindGameObjectsWithTag("ball");
        foreach (GameObject obj in currentBalls)
        {
            Destroy(obj);
        }

        m_ui.SetScoreText("Score: " + m_score);
        m_ui.ShowGameoverPanel(false);
    }
    public void SetScore(int value)
    {
        m_score = value;
    }
    public int GetScore()
    {
        return m_score;
    }
    public void IncrementScore()
    {
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
    }
    public bool IsGameover()
    {
        return m_isGameover;
    }
    public void SetGameoverState(bool state)
    {
        m_isGameover = state;
    }
    public void GameOver()
    {
        
        SetGameoverState(true); 

        
        if (m_ui != null)
        {
            m_ui.ShowGameoverPanel(true);
        }

        
        Time.timeScale = 0f;

        Debug.Log("Game Over! Score: " + m_score);
        Debug.Log("CHECK: GameOver() da chay");

    }
}