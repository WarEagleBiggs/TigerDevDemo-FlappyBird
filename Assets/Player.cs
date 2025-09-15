using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public float jumpForce = 5f;  
    
    public float tiltSmooth = 5f;        
    public float maxRotation = 45f;      
    public float minRotation = -90f;     

    public Rigidbody rb;

    public bool isGamePlaying;

    public int Score;
    public TextMeshProUGUI ScoreTxt;

    public GameObject ObstacleObj;
    public Transform SpawnPos;

    public GameObject StartTxt;

    private void Start()
    {
        StartCoroutine(SpawnObs());
    }

    void Update()
    {
        ScoreTxt.SetText(Score.ToString());
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
            isGamePlaying = true;
            StartTxt.SetActive(false);
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


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Game");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Score")
        {
            Score++;
        }
    }



    public IEnumerator SpawnObs()
    {
        while (true)  
        {
            if (isGamePlaying) 
            {
                GameObject obj = Instantiate(ObstacleObj);
                Vector3 pos = SpawnPos.position;
                pos.y = Random.Range(-2.5f, 4.5f);
                obj.transform.position = pos;
            }

            yield return new WaitForSeconds(1);
        }
    }

}
