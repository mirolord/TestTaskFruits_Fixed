using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Pickupable : MonoBehaviour
{
	private Rigidbody _rigidbody;
	private Collider _collider;

	public void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_collider = GetComponent<Collider>();
	}

	public void Pickup(Transform parent)
	{
		_rigidbody.isKinematic = true;
		_collider.enabled = false;
		transform.position = parent.position;
		transform.SetParent(parent);
	}

	public void Drop(Vector3 direction)
	{
		_rigidbody.isKinematic = false;
		_collider.enabled = true;
		transform.SetParent(null);
		_rigidbody.AddForce(direction);
	}
}