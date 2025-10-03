using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 10;

    float HorizontalInput;
    float VerticalInput;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        // Liikesuunta suhteessa pelaajan forwardiin
        Vector3 move = transform.right * HorizontalInput + transform.forward * VerticalInput;

        // Asetetaan velocity (s�ilytet��n y-akselin arvo esim. gravitaatiolle)
        rb.linearVelocity = new Vector3(move.x * moveSpeed, rb.linearVelocity.y, move.z * moveSpeed);
    }
}