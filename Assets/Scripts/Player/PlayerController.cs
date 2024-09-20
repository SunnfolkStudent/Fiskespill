using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float swimSpeed = 5f;
    public float fishSize = 1f;
    
    private Rigidbody2D _rigidbody2D;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Small Fish"))
        {
            Destroy(other.gameObject);
            fishSize++;
        }
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
