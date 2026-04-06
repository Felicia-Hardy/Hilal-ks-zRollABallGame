using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip collectSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject audioObj = new GameObject("TempAudio");
            AudioSource audioSource = audioObj.AddComponent<AudioSource>();

            audioSource.clip = collectSound;
            audioSource.volume = 1f;
            audioSource.spatialBlend = 0f; 
            audioSource.Play();

            Destroy(audioObj, 2f);
            Destroy(gameObject);
        }
    }
}