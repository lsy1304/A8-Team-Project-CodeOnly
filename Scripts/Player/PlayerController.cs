using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float Speed = 15f;
    public float MaxDistance = 30f;
    public LayerMask WallLayer;

    private BoxCollider _boxCollider;
    private float _direction;
    private float _moveX;
    private float _moveZ;
    private float _moveTime;
    private float _moveDistance;
    private Vector3 _startPoint;
    private Vector3 _endPoint;
    private bool _isMoving = false;
    private bool _isDie = false;

    private Animator _animator;
    private readonly int DieHash = Animator.StringToHash("Die");

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        ApplyMovement();
    }


    private void ApplyMovement()
    {
        if (_isMoving && !_isDie)
        {
            
            _moveTime += Time.deltaTime;

            _moveX = Mathf.Lerp(_startPoint.x, _endPoint.x, (_moveTime * Speed) / _moveDistance);
            _moveZ = Mathf.Lerp(_startPoint.z, _endPoint.z, (_moveTime * Speed) / _moveDistance);

            transform.position = new Vector3(_moveX, transform.position.y, _moveZ);
            if (transform.position == _endPoint)
            {
                _moveTime = 0f;
                _isMoving = false;
                GameManager.Instance.CallOnTurnEndEvent();
            }
        }
    }
    

    public void OnHorizontalMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && !_isMoving && !_isDie && CalculateDistance(context, transform.right))
        {
            SoundManager.Instance.PlaySE("Move");
            _endPoint = _startPoint + new Vector3( _moveDistance * _direction, 0f, 0f);
            _isMoving = true;
        }

    }

    public void OnverticalMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && !_isMoving && !_isDie && CalculateDistance(context, transform.forward))
        {
            SoundManager.Instance.PlaySE("Move");
            _endPoint = _startPoint + new Vector3(0f, 0f, _moveDistance * _direction);
            _isMoving = true;
        }
    }

    bool CalculateDistance(InputAction.CallbackContext context, Vector3 direction)
    {
        _startPoint = transform.position;
        _direction = context.ReadValue<float>() > 0f ? 1 : -1;
        Ray ray = new Ray(_startPoint + direction * 0.48f * _direction, direction * _direction);
        if (Physics.Raycast(ray, 1f, WallLayer) || !Physics.Raycast(ray, out RaycastHit hit, MaxDistance, WallLayer)) return false;
        _moveDistance = MathF.Floor(hit.distance);
        return true;
    }

    public void Die()
    {
        _boxCollider.enabled = false;
        _animator.SetTrigger(DieHash);
        _isMoving = false;
        _isDie = true;
        _moveTime = 0f;
    }

    public void Respawn()
    {
        LevelManager.Instance.levels[0].Respawn(gameObject);
        LevelManager.Instance.CallOnLevelRestartEvent();
        _isDie = false;
        GameManager.Instance.CallOnTurnEndEvent();
    }

    public void ColliderOn()
    {
        _boxCollider.enabled = true;
    }
}
