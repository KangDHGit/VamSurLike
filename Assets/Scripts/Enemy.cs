using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Component
    SpriteRenderer _sprite;
    Rigidbody2D _rigid;
    Animator _anim;
    #endregion

    [SerializeField] float _speed;
    [SerializeField] float _health;
    [SerializeField] float _maxHealth;
    [SerializeField] RuntimeAnimatorController[] _animCon;  //�ִϸ����;ȿ� ���� ��Ʈ�ѷ����� ���� �迭
    [SerializeField] Rigidbody2D _target;

    bool isLive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Init()
    {
        if (!TryGetComponent(out _rigid))
            Debug.LogError(this.gameObject.name + "_rigid is Null");
        if (!TryGetComponent(out _sprite))
            Debug.LogError(this.gameObject.name + "_sprite is Null");
        if (!GameManager.I._player.TryGetComponent(out _target))
            Debug.LogError(this.gameObject.name + "_target is Null");
        if (!TryGetComponent(out _anim))
            Debug.LogError(this.gameObject.name + "_anim is NULL");
    }
    public void Init(SpawnData data)
    {
        _anim.runtimeAnimatorController = _animCon[data.SpriteType];
        _speed = data.Speed;
        _maxHealth = data.MaxHealth;
        _health = data.MaxHealth;
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

    private void OnEnable() //Start �Լ����� ���� ȣ��
    {
        Init();
        isLive = true;
        _health = _maxHealth;
    }
    void MoveToTarget()
    {
        Vector2 dirVec = _target.position - _rigid.position;
        Vector2 nextVec = dirVec.normalized * _speed * Time.fixedDeltaTime;
        _rigid.MovePosition(_rigid.position + nextVec);
        _rigid.velocity = Vector2.zero; //�������� �ӵ��� �浹�� ������ ���� �ʵ���

    }
    void Flip()
    {
        if (_sprite != null)
        {
            _sprite.flipX = _target.position.x < _rigid.position.x;
        }
    }
}
