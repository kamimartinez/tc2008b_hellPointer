using UnityEngine;

public class ShootTest : MonoBehaviour
{
    [SerializeField] private float laserFireRate = 0.1f;
    [SerializeField] private TypeOneShot[] laserPatterns;

    private float laserFireTimer = 0f;
    private int patternIndex = 0;
    private int secondsPassed = 0;

    private void OnEnable(){
        TimeManager.OnSecondChanged += UpdatePattern;
        Debug.Log("ShootTest suscrito");
    }

    private void OnDisable() {
        TimeManager.OnSecondChanged -= UpdatePattern;
    }

    private void Update() {
        laserFireTimer -= Time.deltaTime;

        if (laserFireTimer <= 0f && laserPatterns.Length > 0) {
            TypeOneShot currentPattern = laserPatterns[patternIndex];
            Ataque.TypeOne(transform.position, transform.up, currentPattern);
            laserFireTimer = laserFireRate;
        }
    }

    private void UpdatePattern() {
        secondsPassed++;
        Debug.Log("Han pasado " + secondsPassed + " segundos"); 

        if (secondsPassed % 10 == 0) { 
            patternIndex++;

            if (patternIndex >= laserPatterns.Length) {
                patternIndex = 0; 
            }
            Debug.Log("Cambiando al patrón: " + patternIndex);
        }
    }
}
