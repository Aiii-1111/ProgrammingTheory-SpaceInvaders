using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float spd = 7.0f;
    private float yLimit = 6.24f;
    [SerializeField] private float direction;

    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move object up/down the screen
        transform.Translate(Vector3.up * spd * Time.deltaTime * direction);

        //Destroy the object when it leaves the screen view
        if ((transform.position.y > yLimit && direction > 0)||(transform.position.y < -yLimit && direction < 0))
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

