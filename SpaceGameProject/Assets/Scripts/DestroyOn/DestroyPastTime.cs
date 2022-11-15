using System.Collections;
using UnityEngine;

public class DestroyPastTime : MonoBehaviour
{
    [SerializeField] private UFloat _timeBefforDie;

    private void Awake()
    {
        Destroy(gameObject,_timeBefforDie);
    }
}
