using UnityEngine;

public class MediumFish : MonoBehaviour
{
    public float swimSpeed = -1f;
    public float fishSize;
    
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
    
    private bool DetectedWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.1f, whatIsWall);
    }
}
