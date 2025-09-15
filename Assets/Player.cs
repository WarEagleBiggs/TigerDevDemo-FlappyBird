using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 5f;        
    public float tiltSmooth = 5f;        
    public float maxRotation = 45f;      
    public float minRotation = -90f;     

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        float angle;
        if (rb.linearVelocity.y > 0)
        {
            angle = maxRotation; 
        }
        else
        {
            angle = minRotation;  
        }

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(0, 0, angle),
            tiltSmooth * Time.deltaTime
        );
    }
}
