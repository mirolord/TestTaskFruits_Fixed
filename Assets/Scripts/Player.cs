using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
	[SerializeField] private Joystick _joystick;
	[SerializeField] private float _speed = 1f;

	private Rigidbody _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();

		if (_joystick == null)
		{
			Debug.LogError("Компонент Joystick не назначен.");
		}
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		Vector3 direction = new Vector3(_joystick.Horizontal, _rigidbody.velocity.y, _joystick.Vertical);
		_rigidbody.velocity = transform.TransformDirection(direction) * _speed;
	}
}
