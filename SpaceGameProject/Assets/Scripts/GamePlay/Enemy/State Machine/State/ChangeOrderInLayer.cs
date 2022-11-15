using UnityEngine;

public class ChangeOrderInLayer : SinglDo
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private int _targetOrder;

    private void OnEnable()
    {
        _renderer.sortingOrder = _targetOrder;

        EndDo();
    }
}
