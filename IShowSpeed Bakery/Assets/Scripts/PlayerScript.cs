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

        var moveInput = (new Vector3(HorizontalInput, 0, VerticalInput)).normalized;
    }

    /* private void FixedUpdate()
     {
         rb.AddForce(HorizontalInput * moveSpeed, 0, VerticalInput * moveSpeed);
     }*/
}