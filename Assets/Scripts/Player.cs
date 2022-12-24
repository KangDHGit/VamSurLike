using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    Rigidbody2D _rigid;
    #endregion

    [SerializeField] Vector2 _inputVec;
    [SerializeField] float _moveSpeed; public float MoveSpeed { get { return _moveSpeed; } }

    private void Awake()
    {
        
    }

    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Input();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Init()
    {
        if(!TryGetComponent(out _rigid))
            Debug.LogError("Player _rigid is Null");
        _moveSpeed = 5.0f;
    }

    void Input()
    {
        float x = UnityEngine.Input.GetAxisRaw("Horizontal");
        float y = UnityEngine.Input.GetAxisRaw("Vertical");
        _inputVec = new Vector2(x, y).normalized;
    }

    void Move()
    {
        //_rigid.velocity = _inputVec * _moveSpeed;
        _rigid.MovePosition(_rigid.position + (_inputVec * _moveSpeed *Time.fixedDeltaTime));
    }
}
