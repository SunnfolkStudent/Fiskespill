using UnityEngine;

public class SmallFish : MonoBehaviour
{
    public float swimSpeed = -0.5f;
    
    [Header("HitBoxCheck")]
    public LayerMask whatIsWall;
    public Transform wallCheck;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (DetectedWall())
        {
            swimSpeed *= -1f;
            transform.localScale = new Vector2(transform.localScale.x * -1f, 1f);
        }
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = swimSpeed;
    }

    private bool DetectedWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.1f, whatIsWall);
    }
}
