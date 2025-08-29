using UnityEngine;
using System.Collections;

public static class Ataque
{
    public static void SimpleShot (Vector2 position, Vector2 velocity) {
        Laser laser = ConjuntoLaser.Instance.RequestLaser();
        laser.transform.position = position;
        laser.Velocity = velocity;
    }

    public static void TypeCircle(Vector2 position, Vector2 direction, int cantLasers, float speed) {
        float betweenLasers = 360f / cantLasers;

        for(int i =0; i< cantLasers; i++) {

            float angleLaser = betweenLasers * i;

            Vector2 directionLaser = (Quaternion.Euler(0f, 0f, angleLaser) * direction);
            
            SimpleShot(position, directionLaser * speed );
        }
    }

    public static void TypeSpiral(Vector2 position, Vector2 direction, int cantLasers, float speed, float rotation, float time) {
        for (int i = 0; i < cantLasers; i++) {

            float angle = i * rotation + time * 50f; 
            
            Vector2 dir = (Quaternion.Euler(0, 0, angle) * direction).normalized;
            SimpleShot(position, dir * speed);
        }
    }
}
