using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float spd;
    [SerializeField] private float yLimit;

    // Update is called once per frame
    void Update()
    {
        //Move object up the screen
        transform.Translate(Vector3.up * spd * Time.deltaTime);

        //Destroy the object when it leaves the screen view
        if (transform.position.y > yLimit)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        
        /*//Destroy the object when it hits an enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }*/
    }
}
