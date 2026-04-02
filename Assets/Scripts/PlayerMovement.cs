using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

	public float moveSpeed = 5f;
	public float jumpForce = 12f;

	private Rigidbody2D rb;
	private float moveInput;
	private GameManager gameManager;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		gameManager = FindObjectOfType<GameManager>();
	}

	void Update()
	{
#if UNITY_STANDALONE || UNITY_EDITOR
		moveInput = Input.GetAxisRaw("Horizontal");
#endif


		if (transform.position.y < Camera.main.transform.position.y - 6f)
		{
			gameManager.GameOver();
			enabled = false;
		}
	}

	void FixedUpdate()
	{
		rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
	}

	public void SetMoveInput(float direction)
	{
		moveInput = direction;
	}

	void OnCollisionEnter2D(UnityEngine.Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
		{
			rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
		}
	}
}