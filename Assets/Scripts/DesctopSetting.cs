using UnityEngine;
public class DesctopSetting : ScriptableObject, ISettings
{
	private float _sensitivity = 1.0f; // Чувствительность мыши
	public float GetSensitivity() => _sensitivity;
}