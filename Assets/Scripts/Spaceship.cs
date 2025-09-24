using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public int baseHp;

    public GameObject bulletPrefab;

    public virtual void LaunchBullet()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 2.0f, 0);
        Instantiate(bulletPrefab, spawnPos, transform.rotation);
    }

}
