using TMPro;
using UnityEngine;

public class FruitCounter : MonoBehaviour
{
	private const int MaxScore = 15;
	[SerializeField] private TextMeshPro _textMesh;
	private int _score = 0;

	private void Awake()
	{
		if (_textMesh == null)
		{
			Debug.LogError("Компонент TextMeshPro не назначен.");
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Pickupable pickupable = other.GetComponent<Pickupable>();
		if (pickupable != null)
		{
			if (_score < MaxScore)
			{
				_score++;
				RefreshScoreBoard();
			}
		}

	}
	private void OnTriggerExit(Collider other)
	{
		Pickupable pickupable = other.GetComponent<Pickupable>();
		if (pickupable != null)
		{
			_score--;
			RefreshScoreBoard();
		}
	}

	private void RefreshScoreBoard()
	{
		_textMesh.text = _score + "/" + MaxScore;
	}
}
