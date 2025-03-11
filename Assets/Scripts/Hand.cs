using UnityEngine;

public class Hand : MonoBehaviour
{
	[SerializeField] private Transform _player;
	[SerializeField] private float _pickUpDistance = 1f;
	[SerializeField] private float _dropForwardForce = 10f;
	[SerializeField] private float _dropUpdForce = 20f;

	private Pickupable _itemInHand = null;

	private bool HasItem => _itemInHand != null;

	private void Awake()
	{
		if (_player == null)
		{
			Debug.LogError("Компонент player не назначен.");
		}
	}

	public bool PickUpItem()
	{
		if (HasItem)
		{
			return false;
		}

		Camera mainCamera = Camera.main;
		if (mainCamera == null)
		{
			Debug.LogError("Основная камера не найдена.");
		}

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, _pickUpDistance))
		{
			if (hit.transform.gameObject.TryGetComponent<Pickupable>(out Pickupable pickupableItem))
			{
				_itemInHand = pickupableItem;
				_itemInHand.Pickup(transform);
				return true;
			}
		}

		return false;
	}

	public void DropHandItem()
	{
		if (!HasItem)
		{
			throw new System.Exception("Нет предмета в руке для броска.");
		}
		_itemInHand.Drop(_player.forward * _dropForwardForce + Vector3.up * _dropUpdForce);
		_itemInHand = null;
	}
}
