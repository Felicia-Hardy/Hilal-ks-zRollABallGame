using UnityEngine;

public class Collectible : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject manager = GameObject.Find("GameManager");
            manager.GetComponent<ScoreManager>().AddScore(1);

            Destroy(gameObject);
        }
    }
}