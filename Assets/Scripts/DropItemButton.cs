using UnityEngine;

public class DropItemButton : MonoBehaviour
{
	[SerializeField] private Hand _hand;

	private void Awake()
	{
		if (_hand == null)
		{
			Debug.LogError("Компонент Hand не назначен.");
		}
	}

	public void Drop()
	{
		_hand.DropHandItem();
		gameObject.SetActive(false);
	}
}
