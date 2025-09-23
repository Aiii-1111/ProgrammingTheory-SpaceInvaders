using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int enemyYPos = 4;
    private int enemiesPerWave = 8;
    private int currentWave;
    public int enemyHp;
    public int nDeadEnemies;

    public bool isGameActive;
    public GameObject enemyPrefab;

    public TextMeshProUGUI gameOverText;
    public Button retryButton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnWave()
    {
        nDeadEnemies = 0;

        for (int i = 0; i <= enemiesPerWave; i++)
        {
            Vector3 spawnVector = new Vector3((-8 + 2.0f * i), enemyYPos, 0.0f);
            Instantiate(enemyPrefab, spawnVector, transform.rotation);
        }
    }

    public void StartGame()
    {
        enemyHp = 10;
        isGameActive = true;
        nDeadEnemies = 0;
        currentWave = 1;

        SpawnWave();
    }

    public void GameOver()
    {
        isGameActive = false;

        gameOverText.gameObject.SetActive(true);
    }
    

}