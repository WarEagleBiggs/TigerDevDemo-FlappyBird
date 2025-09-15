using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 5f;  
    
    public float tiltSmooth = 5f;        
    public float maxRotation = 45f;      
    public float minRotation = -90f;     

    public Rigidbody rb;

    public bool isGamePlaying;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
            isGamePlaying = true;
        }

        if (isGamePlaying)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX 
                             | RigidbodyConstraints.FreezePositionZ 
                             | RigidbodyConstraints.FreezeRotationX 
                             | RigidbodyConstraints.FreezeRotationY;

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
}
