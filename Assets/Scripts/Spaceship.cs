using UnityEngine;

public class Spaceship : MonoBehaviour
{
    //[SerializeField] private float hp = 50;

    public GameObject bulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public virtual void LaunchBullet()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 2.0f, 0);
        Instantiate(bulletPrefab, spawnPos, transform.rotation);
    }

}
