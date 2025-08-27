using UnityEngine;
using TMPro; 

public class LaserUI : MonoBehaviour
{
    [SerializeField] private TMP_Text laserText; 

    private void Update() {
        int activeLasers = ConjuntoLaser.Instance.ContadorLasers();
            laserText.text = "Balas activas: " + activeLasers;
    }
}
