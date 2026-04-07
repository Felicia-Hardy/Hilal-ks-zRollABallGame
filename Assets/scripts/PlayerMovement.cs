using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float sprintMultiplier = 2f;
    public float jumpForce = 5f;

    public AudioSource moveSound;
    public float minSpeed = 0.1f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 🛑 Oyun durduysa sesi kapat
        if (Time.timeScale == 0f)
        {
            if (moveSound.isPlaying)
                moveSound.Stop();
            return;
        }

        // 🟢 Zıplama
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // 🔊 Hareket sesi
        float currentSpeed = rb.linearVelocity.magnitude;

        if (currentSpeed > minSpeed)
        {
            if (!moveSound.isPlaying)
                moveSound.Play();
        }
        else
        {
            if (moveSound.isPlaying)
                moveSound.Stop();
        }
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        float currentSpeed = speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= sprintMultiplier;
        }

        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        rb.AddForce(movement * currentSpeed);
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}