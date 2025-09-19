using UnityEngine;

public class PlayerController : Spaceship
{
    [SerializeField] private float spd;
    [SerializeField] private float xRange;

    private float input;

    private Rigidbody playerRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            MovePlayer();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBullet();
            }
        }

    }

    void MovePlayer()
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
}
