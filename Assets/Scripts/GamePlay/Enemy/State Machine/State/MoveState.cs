using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BossEnemy))]
public class MoveState : State
{
    private const uint _sellectNextMoveTryMaximalCount = 100;

    private const uint _hitBufferLength = 16;

    private readonly Color _gizmosColor = Color.cyan;
    private readonly UFloat _gizmosRadius = 1;

    [Header("Layer Mask")]
    [SerializeField] private LayerMask _layerMask;

    [Header("General")]
    [SerializeField] private UFloat _speed;

    [Header("Move Distanse")]
    [SerializeField] private UFloat _maximalMoveDistnace;
    [SerializeField] private UFloat _minimalMoveDistance;
    [SerializeField] private MoveRect _moveRect;

    [Header("Contact")]
    [SerializeField] private UFloat _minimalDistanceToTarget;

    private Vector2 _nextMoveTarget;

    private Rigidbody2D _rigidbody;

    private ContactFilter2D _contactFilter;

    private Coroutine _moveRandomlyCorutine;

    private void OnValidate()
    {
        _maximalMoveDistnace = Mathf.Max(_maximalMoveDistnace, _minimalMoveDistance);
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _contactFilter.useTriggers = false;
        _contactFilter.SetLayerMask(_layerMask);
        _contactFilter.useLayerMask = true;
    }

    private void OnEnable()
    {
        _moveRandomlyCorutine = StartCoroutine(MoveRandomly());
    }

    private void OnDisable()
    {
        if (_moveRandomlyCorutine != null)
            StopCoroutine(_moveRandomlyCorutine);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmosColor;

        Gizmos.DrawSphere(_nextMoveTarget, _gizmosRadius);
    }

    private IEnumerator MoveRandomly()
    {
        _nextMoveTarget = (Vector2)transform.position;

        while (true)
        {
            if (Vector2.Distance(_nextMoveTarget, transform.position) <= _minimalDistanceToTarget)
                _nextMoveTarget = GetNextMoveTarget();

            transform.position += (Vector3)(_nextMoveTarget - (Vector2)transform.position).normalized * _speed * Time.deltaTime;

            yield return null;
        }
    }

    private Vector2 GetNextMoveTarget()
    {
        for (int i = 0; i < _sellectNextMoveTryMaximalCount; i++)
        {
            var randomVelocity = Random.insideUnitCircle * _maximalMoveDistnace;

            var hitBuffer = _rigidbody.GetProjectionContacts(randomVelocity, _hitBufferLength, _contactFilter);

            if (hitBuffer.Count() == 0)
            {
                var nextMoveTarget = (Vector2)transform.position + randomVelocity;

                return GetBoundedPositon(nextMoveTarget);
            }

            var minimalProjectionDistance = hitBuffer.Max(projection => projection.distance);

            if (minimalProjectionDistance > _minimalMoveDistance)
            {
                var nextMoveTarget = (Vector2)transform.position + (randomVelocity.normalized * minimalProjectionDistance);

                return GetBoundedPositon(nextMoveTarget);
            }
        }

        return Vector2.zero;
    }

    private Vector2 GetBoundedPositon(Vector2 position)
    {
        return new Vector2(Mathf.Clamp(position.x, _moveRect.BottomRight.x, _moveRect.TopLeft.x), Mathf.Clamp(position.y, _moveRect.BottomRight.y, _moveRect.TopLeft.y));
    }

    [System.Serializable]
    public class MoveRect
    {
        [SerializeField] private Vector2 _topLeft;
        [SerializeField] private Vector2 _bottomRight;

        public Vector2 TopLeft => _topLeft;
        public Vector2 BottomRight => _bottomRight;
    }
}