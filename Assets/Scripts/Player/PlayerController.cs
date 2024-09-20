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

    //TakeDamage should, hypothetically speaking, lock player's controls and sink the player towards the big fish for a few seconds
    //After a few seconds, it will unlock the controls and the player can control again
    //Sadly, at the writing moment, I got burnt out due to a certain unforeseen circumstance...
    private void TakeDamage()
    {
        _input.OnDisable();
        //NOT FINISHED
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
