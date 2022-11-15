using UnityEngine;

public class OnStateFinshedTransiton : Transition
{
    [SerializeField] private EndableState _observable;

    private bool _neadTransit;

    public override bool NeedTransit
    {
        get
        {
            if(_neadTransit)
            {
                _neadTransit = false;

                return true;
            }

            return false;
        }
    }
   

    private void OnEnable()
    {
        _observable.OnStateFinshed += Transit;
    }

    private void OnDisable()
    {
        _observable.OnStateFinshed -= Transit;
    }

    private void Transit()
    {
        _neadTransit = true;
    }
}
