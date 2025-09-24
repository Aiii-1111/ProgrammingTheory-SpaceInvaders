using UnityEngine;

public class PlayerController : Spaceship //INHERITANCE
{
    private float spd = 14.0f;
    private float xRange = 8.35f;
    private float input;

    private Rigidbody playerRb;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        gameManager.healthText.text = "Hp: " + baseHp;
    } 

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            MovePlayer();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBullet();
            }
        }

    }

    void MovePlayer() //ABSTRACTION
    {
        //take player input and move 
        input = Input.GetAxis("Horizontal");
        playerRb.MovePosition(transform.position + (Vector3.right * spd * Time.deltaTime * input));

        //keep player in bounds
        if (transform.position.x > xRange)
        {
            playerRb.MovePosition(new Vector3(xRange, transform.position.y, 0));
        }
        else if (transform.position.x < -xRange)
        {
            playerRb.MovePosition(new Vector3(-xRange, transform.position.y, 0));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Update hp & check game over
        baseHp -= 10;
        if (baseHp <= 0)
        {
            gameManager.GameOver();
            Debug.Log("Game Over");
        }

        //Update UI
        gameManager.healthText.text = "Hp: " + baseHp;
    }
}
