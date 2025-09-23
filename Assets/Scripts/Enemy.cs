using UnityEngine;

public class Enemy : Spaceship
{
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        InvokeRepeating("LaunchBullet", Random.Range(0,5), Random.Range(0,5));
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
        }
    }
    public override void LaunchBullet()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y - 2.0f, 0);
        Instantiate(bulletPrefab, spawnPos, transform.rotation);
    }
}
