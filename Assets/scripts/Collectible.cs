using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip collectSound;
    public ParticleSystem shineEffect;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // PARLAMA
            if (shineEffect != null)
            {
                Instantiate(shineEffect, transform.position, Quaternion.identity);
            }

            // SES
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
            }

            Destroy(gameObject);
        }
    }
}