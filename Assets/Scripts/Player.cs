using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float _speed = 3f;
	[SerializeField] private Joystick _joystick;

	private Rigidbody _rb;
	private float _dirH, _dirV;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();

		if (_joystick == null)
		{
			Debug.LogError("Компонент Joystick не назначен.");
		}
	}

	void Update()
	{
		_dirH = _joystick.Horizontal;
		_dirV = _joystick.Vertical;
	}

	private void FixedUpdate()
	{
		Vector3 yVelocity = new Vector3(0, _rb.velocity.y, 0);
		_rb.velocity = transform.forward * _dirV + transform.right * _dirH + yVelocity;
	}
}
