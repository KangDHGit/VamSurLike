using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Component
    SpriteRenderer _sprite;
    Rigidbody2D _rigid;
    #endregion

    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _target;

    bool isLive = true;


    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    void init()
    {
        if (!TryGetComponent(out _rigid))
            Debug.LogError(this.gameObject.name + "_rigid is Null");
        if (!TryGetComponent(out _sprite))
            Debug.LogError(this.gameObject.name + "_sprite is Null");
        if (!GameManager.I._player.TryGetComponent(out _target))
            Debug.LogError(this.gameObject.name + "_target is Null");
    }

    private void FixedUpdate()
    {
        if (!isLive) return;

        if (_target != null)
        {
            MoveToTarget();
        }
    }
    private void LateUpdate()
    {
        if (!isLive) return;

        if (_target != null)
            Flip();
    }
    void MoveToTarget()
    {
        Vector2 dirVec = _target.position - _rigid.position;
        Vector2 nextVec = dirVec.normalized * _speed * Time.fixedDeltaTime;
        _rigid.MovePosition(_rigid.position + nextVec);
        _rigid.velocity = Vector2.zero; //물리적인 속도가 충돌에 영향을 주지 않도록

    }
    void Flip()
    {
        if (_sprite != null)
        {
            _sprite.flipX = _target.position.x < _rigid.position.x;
        }
    }
}
