using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int enemyYPos = 4;
    public const int enemiesPerWave = 8;
    public int currentWave;
    public int nDeadEnemies;

    public bool isGameActive { get; private set; } //ENCAPSULATION
    public GameObject enemyPrefab;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI healthText;
    public Button retryButton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();
    }

    public void SpawnWave() //ABSTRACTION
    {
        currentWave += 1;
        nDeadEnemies = 0;

        //spawn new enemies
        for (int i = 0; i <= enemiesPerWave; i++)
        {
            Vector3 spawnVector = new Vector3((-8 + 2.0f * i), enemyYPos, 0.0f);
            Instantiate(enemyPrefab, spawnVector, transform.rotation);
        }

        //Update wave text
        waveText.text = "Wave: " + currentWave;
    }

    public void StartGame()
    {
        //enemyHp = 10;
        isGameActive = true;
        nDeadEnemies = 0;
        currentWave = 0;

        SpawnWave();
    }

    public void GameOver()
    {
        isGameActive = false;

        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
    }

}