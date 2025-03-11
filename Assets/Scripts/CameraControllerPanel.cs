using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControllerPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField] private Hand _hand;
	[SerializeField] private GameObject _dropItemButton;
	public bool Pressed { get; private set; }
	public int FingerId { get; private set; }

	private void Awake()
	{
		if (_hand == null)
		{
			Debug.LogError("Компонент Hand не назначен.");
		}

		if (_dropItemButton == null)
		{
			Debug.LogError("Компонент DropItemButton не назначен.");
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (_hand.PickUpItem())
		{
			_dropItemButton.SetActive(true);
		}
		else if (eventData.pointerCurrentRaycast.gameObject == gameObject)
		{
			Pressed = true;
			FingerId = eventData.pointerId;
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (eventData.pointerId == FingerId)
		{
			Pressed = false;
		}
	}
}
