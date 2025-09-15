using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool isGamePlaying;
    public Vector3 direction = Vector3.left;
    public float speed = 5f;

    public Player player;

    void Update()
    {
        isGamePlaying = player.isGamePlaying;
        
        if (isGamePlaying)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
