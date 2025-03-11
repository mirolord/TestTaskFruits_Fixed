using UnityEngine;
public class DesctopController : IController
{
	public Vector2 Control()
	{
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");
		return new Vector2(mouseX, mouseY);
	}
}