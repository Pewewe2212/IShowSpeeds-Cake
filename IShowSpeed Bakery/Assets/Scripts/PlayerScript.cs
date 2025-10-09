using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Minipeli movemet 
    //FindObjectOfType<PlayerScript>().CanMove = false;  ||Kun minipeli alkaa
    //FindObjectOfType<PlayerScript>().CanMove = true;   ||Kun minipeli loppuu

    public float moveSpeed = 10;

    float HorizontalInput;
    float VerticalInput;

    [HideInInspector] public bool CanMove = true;

    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanMove)
        {
            // Pelaaja ei liiku, mutta gravity toimii
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
            return;
        }

        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        // Liikkuminen
        Vector3 move = transform.right * HorizontalInput + transform.forward * VerticalInput;

        // Asetetaan velocity 
        rb.linearVelocity = new Vector3(move.x * moveSpeed, rb.linearVelocity.y, move.z * moveSpeed);
    }
}