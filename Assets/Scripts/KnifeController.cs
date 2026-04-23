using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveSpeed = 5f;
    public float cuttingTimeFrame = 0.2f;

    public enum KnifeState { Idle, MovingDown, MovingUp }
    public KnifeState State { get; private set; } = KnifeState.Idle;
    public bool IsCutting { get; private set; } = false;

    public bool IsStunned { get; set; } = false;

    private Vector3 _startPos;
    private Vector3 _targetPos;
    private float _timeElapsed = 0f;

    void Start()
    {
        _startPos = transform.position;
    }

    void Update()
    {
        HandleCuttingState();

        if (Input.touchCount > 0 && !IsStunned)
        {
            if (State == KnifeState.Idle)
                StartMovingDown();
        }

        if (State == KnifeState.MovingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, moveSpeed * Time.deltaTime);
            if (transform.position == _targetPos)
                StartMovingUp();
        }
        else if (State == KnifeState.MovingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPos, moveSpeed * Time.deltaTime);
            if (transform.position == _startPos)
                State = KnifeState.Idle;
        }
    }

    private void HandleCuttingState()
    {
        if (Input.touchCount > 0 && !IsCutting && !IsStunned)
        {
            _timeElapsed = 0f;
            IsCutting = true;
        }
        else
        {
            _timeElapsed += Time.fixedDeltaTime;
            if (_timeElapsed >= cuttingTimeFrame && IsCutting)
            {
                IsCutting = false;
                _timeElapsed = 0f;
            }
        }
    }

    private void StartMovingDown()
    {
        _targetPos = _startPos + Vector3.down * moveDistance;
        State = KnifeState.MovingDown;
    }

    private void StartMovingUp()
    {
        State = KnifeState.MovingUp;
    }
}