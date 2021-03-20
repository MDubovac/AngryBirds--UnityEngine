using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _cloudParticle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the bird hits
        Bird bird = collision.collider.GetComponent<Bird>();
        if(bird != null)
        {
            Instantiate(_cloudParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        // If another enemy hits
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if(enemy != null)
        {
            return;
        }

        // Contact on top
        if(collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_cloudParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
    }
}
