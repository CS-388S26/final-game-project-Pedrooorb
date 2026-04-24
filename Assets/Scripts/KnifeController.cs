/**
 * @file
 *  KnifeController.cs
 * @author
 *  Pedro Roman, 540001522, pedro.r@digipen.edu
 * @date
 *  24/04/2026
 * @brief
 *  Controls the knife animation and states
 * @copyright
 *  Copyright (C) 2026 DigiPen Institute of Technology.
 */
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    //movement animation
    public float moveDistance = 2f;
    public float moveSpeed = 5f;
    public float cuttingTimeFrame = 0.2f;

    //knife states
    public enum KnifeState { Idle, MovingDown, MovingUp }
    public KnifeState State { get; private set; } = KnifeState.Idle;
    public bool IsCutting { get; private set; } = false;

    public bool IsStunned { get; set; } = false;

    //movement animation 
    private Vector3 _startPos;
    private Vector3 _targetPos;
    private float _timeElapsed = 0f;

    //accelerator
    public float shakeThreshold = 2.5f;
    public float requiredShakeAmount = 1000000000000f;

    private Vector3 _lastAcceleration;
    public float _currentShakeAmount = 0f;

    /**
    * @brief Called at beginning
    */
    void Start()
    {
        _startPos = transform.position;
    }
    /**
    * @brief Called at every frame
    */
    void Update()
    {
        HandleCuttingState();

        if (IsStunned)
        {
            DetectShake();
            return;
        }

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
    /**
    * @brief Handles accelerator logic to de-stun player
    */
    private void DetectShake()
    {
        Vector3 acceleration = Input.acceleration;
        Vector3 delta = acceleration - _lastAcceleration;
        _lastAcceleration = acceleration;

        if (delta.sqrMagnitude >= shakeThreshold * shakeThreshold)
            _currentShakeAmount += delta.magnitude;

        if (_currentShakeAmount >= requiredShakeAmount)
        {
            IsStunned = false;
            _currentShakeAmount = 0f;
        }
    }
    /**
    * @brief Handles current state of the knife
    */
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
    /**
    * @brief Set up for the knife to move down
    */
    private void StartMovingDown()
    {
        _targetPos = _startPos + Vector3.down * moveDistance;
        State = KnifeState.MovingDown;
    }
    /**
    * @brief Set up for the knife to move up
    */
    private void StartMovingUp()
    {
        State = KnifeState.MovingUp;
    }
}