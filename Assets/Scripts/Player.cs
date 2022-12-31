using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    #region Components
    Rigidbody2D _rigid;
    SpriteRenderer _sprite;
    Animator _anim;
    #endregion

    [SerializeField] Vector2 _inputVec;
    [SerializeField] float _moveSpeed; public float MoveSpeed { get { return _moveSpeed; } }

    public void Init()
    {
        if (!TryGetComponent(out _rigid))
            Debug.LogError("Player _rigid is Null");
        if (!TryGetComponent(out _sprite))
            Debug.LogError("Player _sprite is Null");
        if (!TryGetComponent(out _anim))
            Debug.LogError("Player _anim is Null");
        _moveSpeed = 5.0f;
    }

    void Start()
    {
        Init();
    }
    void Update()
    {
        //Input();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        _anim.SetFloat("Speed", _inputVec.magnitude);
        flip();
    }

    void Input()
    {
        float x = UnityEngine.Input.GetAxisRaw("Horizontal");
        float y = UnityEngine.Input.GetAxisRaw("Vertical");
        _inputVec = new Vector2(x, y).normalized;
    }                 //구 입력 시스템

    void OnMove(InputValue value)   //신 입력 시스템
    {
        _inputVec = value.Get<Vector2>();
    }
    void Move()
    {
        _rigid.MovePosition(_rigid.position + (_inputVec * _moveSpeed *Time.fixedDeltaTime));
    }


    void flip()
    {
        if (_sprite != null) {
            if (_inputVec.x != 0)
                _sprite.flipX = _inputVec.x < 0;
        }
        else
            Debug.LogError("Player _sprite is Null");
    }
}
