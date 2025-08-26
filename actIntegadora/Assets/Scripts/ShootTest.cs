using UnityEngine;

public class ShootTest : MonoBehaviour
{
    [SerializeField] private float laserFireRate = 0.1f;
    [SerializeField] private TypeOneShot laserShotSettings;

    private float laserFireTimer = 0f;

    private void Update() {
        laserFireTimer -= Time.deltaTime;

        if (laserFireTimer <= 0f) {
            Ataque.TypeOne(transform.position, transform.up, laserShotSettings);
            laserFireTimer = laserFireRate;
        }
    }
}
