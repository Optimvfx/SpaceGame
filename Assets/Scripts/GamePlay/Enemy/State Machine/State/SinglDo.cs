using UnityEngine;

public class SinglDo : EndableState
{
    private bool _doSeccess = false;

    private void Update()
    {
        if (_doSeccess)
            EndState();
    }

    protected void EndDo()
    {
        _doSeccess = true;
    }    
}
