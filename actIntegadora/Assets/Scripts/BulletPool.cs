using UnityEngine;
using System.Collections.Generic;

public class ConjuntoLaser : MonoBehaviour
{   
    private static ConjuntoLaser _instance;

    public static ConjuntoLaser Instance{
        get{
            if(_instance == null) Debug.LogError("ConjuntoLaser Instance missing");

            return _instance;
        }
    }
    [SerializeField] private Laser _laserPrefab;
    [SerializeField] private int _sizeLasers = 10;

    private List<Laser> _lasers = new List<Laser>();

    private void Awake(){
        if(_instance != null && _instance!= this) {
            Destroy(gameObject);
            return;
        }else {
            _instance = this;
        }
        AgregarLaser(_sizeLasers);
    }

    private void AgregarLaser(int amount) {
        for(int i=0;i<amount;i++) {
            Laser laser = Instantiate(_laserPrefab);
            laser.gameObject.SetActive(false);
            _lasers.Add(laser);
            laser.transform.parent = transform;
        }
    }

    public Laser RequestLaser() {
        for(int i=0;i<_lasers.Count; i++) {
            if(!_lasers[i].gameObject.activeSelf) {
                _lasers[i].gameObject.SetActive(true);
                return _lasers[i];
            }
        }
        AgregarLaser(1);
        _lasers[_lasers.Count - 1].gameObject.SetActive(true);    
        return _lasers[_lasers.Count - 1];
    }
}
