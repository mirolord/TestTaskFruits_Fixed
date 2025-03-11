using UnityEngine;
public class MobileController : IController
{
	private CameraControllerPanel _cameraControllerPanel;

	public MobileController(CameraControllerPanel cameraControllerPanel)
	{
		_cameraControllerPanel = cameraControllerPanel;
	}

	public Vector2 Control()
	{
		float mouseX = 0;
		float mouseY = 0;

		if (_cameraControllerPanel.Pressed)
		{
			foreach (Touch touch in Input.touches)
			{
				if (touch.fingerId == _cameraControllerPanel.FingerId)
				{
					if (touch.phase == TouchPhase.Moved)
					{
						mouseY = touch.deltaPosition.y;
						mouseX = touch.deltaPosition.x;
					}
					break;
				}
			}
		}

		return new Vector2(mouseX, mouseY);
	}
}