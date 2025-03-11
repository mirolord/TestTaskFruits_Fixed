using UnityEngine;
public class MobileSetting: ScriptableObject, ISettings
{
	private float _sensitivity = 0.1f; // Чувствительность на мобильном устройстве
	public float GetSensitivity() => _sensitivity;
}