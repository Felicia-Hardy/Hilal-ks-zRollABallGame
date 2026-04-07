using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip collectSound;
    public ParticleSystem shineEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //  SCORE EKLE
            GameObject.Find("GameManager")
                .GetComponent<ScoreManager>()
                .AddScore(1);

            //  PARLAMA
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