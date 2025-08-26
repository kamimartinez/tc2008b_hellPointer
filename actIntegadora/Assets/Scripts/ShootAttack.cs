using UnityEngine;

public static class Ataque
{
    public static void SimpleShot (Vector2 position, Vector2 velocity) {
        Laser laser = ConjuntoLaser.Instance.RequestLaser();
        laser.transform.position = position;
        laser.Velocity = velocity;
    }

    public static void TypeOne(Vector2 position, Vector2 direction, TypeOneShot settings) {
        float betweenLasers = 360f / settings.cantLasers;

        for(int i =0; i< settings.cantLasers; i++) {

            float angleLaser = betweenLasers * i;

            Vector2 directionLaser = (Quaternion.Euler(0f, 0f, angleLaser) * direction);
            
            SimpleShot(position, directionLaser * settings.LaserSpeed);
        }
    }
}
