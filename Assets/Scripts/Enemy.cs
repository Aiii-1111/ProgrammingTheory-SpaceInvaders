using UnityEngine;

public class Enemy : Spaceship //INHERITANCE
{
    private int hp;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        InvokeRepeating("LaunchBullet", Random.Range(0, 5), Random.Range(0, 5));
        hp = baseHp * gameManager.currentWave;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameActive)
        {
            CancelInvoke();
        }
    }

    void OnTriggerEnter()
    {
        hp -= 10;

        if (hp <= 0)
        {
            Destroy(gameObject);
            gameManager.nDeadEnemies += 1;
        }

        if (gameManager.nDeadEnemies > GameManager.enemiesPerWave)
        {
            gameManager.nDeadEnemies = 0;
            gameManager.SpawnWave();
        }
    }
    public override void LaunchBullet() //POLYMORPHISM
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y - 2.0f, 0);
        Instantiate(bulletPrefab, spawnPos, transform.rotation);
    }
}
