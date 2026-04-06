using UnityEngine;

public class Fence : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player çite çarptý");
        }
    }
}