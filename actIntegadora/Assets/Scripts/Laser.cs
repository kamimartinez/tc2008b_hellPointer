using UnityEngine;

public class Laser : MonoBehaviour
{   
    [SerializeField] private float maxLifeTime = 3f;
    private float _lifeTime = 0f;
    public Vector2 Velocity;

    void OnEnable() {
        _lifeTime = 0f; 
    }

    void Update()
    {
        transform.position += (Vector3)Velocity * Time.deltaTime;
        _lifeTime += Time.deltaTime;

        if(_lifeTime > maxLifeTime){
            Disable();
        }

        Vector3 camaraView = Camera.main.WorldToViewportPoint(transform.position);
        if (camaraView.x < 0 || camaraView.x > 1 || camaraView.y < 0 || camaraView.y > 1) {
            Disable();
        }
    }

    private void Disable() {
        gameObject.SetActive(false); 
        _lifeTime = 0f;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Meteor")) {
            Disable();
        }
    }
}
