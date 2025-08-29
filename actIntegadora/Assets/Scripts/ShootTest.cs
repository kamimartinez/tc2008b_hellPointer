using UnityEngine;
using System.Collections;

public class ShootTest : MonoBehaviour
{
    [SerializeField] private float laserFireRate = 0.1f;

    private float laserFireTimer = 0f;
    private int patternIndex = 0;
    private int secondsPassed = 0;
    private float amplitude = 5f;
    private float moveSpeed = 1f;
    private Vector2 startPos;

    private void OnEnable(){
        TimeManager.OnSecondChanged += UpdatePattern;
    }

    private void OnDisable() {
        TimeManager.OnSecondChanged -= UpdatePattern;
    }

    private void Update() {
        laserFireTimer -= Time.deltaTime;

        if (laserFireTimer <= 0f) {
            switch (patternIndex) {
                case 0: 
                    Ataque.TypeCircle(transform.position, transform.up, 10, 70f);
                    break;
                case 1: 
                    Ataque.TypeSpiral(transform.position, transform.up, 5, 70f, 12f, Time.time);
                    break;
                case 2:
                    Ataque.TypeStraight(transform.position, transform.up, 1, 70f);
                    break;
            }

            laserFireTimer = laserFireRate;
        }
    }

    private void UpdatePattern() {
        secondsPassed++;
        Debug.Log("Han pasado " + secondsPassed + " segundos"); 

        if (secondsPassed % 10 == 0) { 
            patternIndex++;

            if (patternIndex > 2) {
                patternIndex = 0; 
            }
            Debug.Log("Cambiando al patrón: " + patternIndex);
        }
    }
}
