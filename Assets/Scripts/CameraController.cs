using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
	[SerializeField] private float _maxYAngle = 80.0f;

	private IController _controller;
	private float _sensitivity;
	private float _rotationX = 0.0f;

	[Inject]
	public void Construct(IController controller, ISettings settings)
	{
		_controller = controller;
		_sensitivity = settings.GetSensitivity();
	}

	private void Update()
	{
		Vector2 input = _controller.Control();

		float mouseX = input.x * _sensitivity;
		float mouseY = input.y * _sensitivity;

		// ¬ращение персонажа в горизонтальной плоскости
		transform.parent.Rotate(Vector3.up * mouseX);

		// ¬ращение камеры в вертикальной плоскости
		_rotationX -= mouseY;
		_rotationX = Mathf.Clamp(_rotationX, -_maxYAngle, _maxYAngle);
		transform.localRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);
	}
}