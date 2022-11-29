using UnityEngine;
using UnityEngine.Events;

public class DoWithChance : MonoBehaviour
{
	private readonly float _maxChance = 100;

	[SerializeField] private UnityEvent _do;

	[Range(0f, 100f)] [SerializeField] private float chance;

	public void TryDo()
	{
		var randomValue = Random.Range(0, _maxChance);

		if (randomValue < chance)
			_do?.Invoke();
	}
}