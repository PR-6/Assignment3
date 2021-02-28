using UnityEngine;

public class Car : MonoBehaviour {

	public Rigidbody2D rb;

	public float minSpeed = 8f;
	public float maxSpeed = 12f;

	private float bornTime;
	private float currentTime;

	float speed = 1f;
	float carSpeed;
	
	void awake()
    {
		carSpeed = PlayerPrefs.GetInt("CarSpeed", 0);
    }

	void Start ()
	{
		speed = Random.Range(minSpeed, maxSpeed) + carSpeed;
	}

	void FixedUpdate () {
		Vector2 forward = new Vector2(transform.right.x, transform.right.y);
		rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
	}

}
