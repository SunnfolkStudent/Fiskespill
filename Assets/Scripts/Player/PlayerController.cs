using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float swimSpeed = 5f;
    public float fishSize = 1f;
    
    private Rigidbody2D _rigidBody2D;
    
    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("SmallFish"))
        {
            Destroy(other.gameObject);
            fishSize++;
        }
    }
    
}
