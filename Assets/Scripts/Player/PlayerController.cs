using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float swimSpeed = 5f;
    public float fishSize = 1f;

    public float damageCooldown = 0.5f;
    private float _damageCooldownTimer;
    
    private Rigidbody2D _rigidbody2D;
    private Input_Actions _input;
    
    private void Start()
    {
        _input = GetComponent<Input_Actions>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = _input.Horizontal * swimSpeed;
        _rigidbody2D.linearVelocityY = _input.Vertical * swimSpeed;
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Small Fish"))
        {
            Destroy(other.gameObject);
            fishSize++;
        } else if (other.gameObject.CompareTag("Medium Fish"))
        {
            if (other.gameObject.GetComponent<MediumFish>().fishSize <= fishSize)
            {
                Destroy(other.gameObject);
                fishSize++;
            }
            else
            {
                TakeDamage();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            GameOver();
        }
    }

    private void TakeDamage()
    {
        _input.OnDisable();
        if (Time.time > _damageCooldownTimer)
        {
            _damageCooldownTimer = Time.time + damageCooldown;
        }
        _input.OnEnable();
    }
    
    public void GameOver()
    {
        print("GAME OVER!!!!!!");
        StopProgram();
    }

    public void YouWon()
    {
        print("YOU WON! :))))");
        StopProgram();
    }

	void StopProgram() {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}
