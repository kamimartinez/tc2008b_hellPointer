using UnityEngine;

public class Laser : MonoBehaviour
{   
    private const float MAX_LIFE_TIME = 3f;
    private float _lifeTime = 0f;
    public Vector2 Velocity;

    void OnEnable() {
        _lifeTime = 0f; 
    }

    void Update()
    {
        transform.position += (Vector3)Velocity * Time.deltaTime;
        _lifeTime += Time.deltaTime;

        if(_lifeTime > MAX_LIFE_TIME){
            Disable();
        }
    }

    private void Disable() {
        gameObject.SetActive(false); 
        _lifeTime = 0f;
    }
}
