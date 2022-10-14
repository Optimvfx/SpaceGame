using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class DierPastTime : MonoBehaviour
{
    [SerializeField] private UFloat _timeBefforDie;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();

        StartCoroutine(DiePastTime());
    }

    private IEnumerator DiePastTime()
    {
        yield return new WaitForSeconds(_timeBefforDie);

        _health.Die();
    }
}
