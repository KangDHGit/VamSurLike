using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoint;
    [SerializeField] SpawnData[] _spawnData;
    float _timer;
    int _level;

    void Start()
    {
        init();
    }

    void init()
    {
        _spawnPoint = GetComponentsInChildren<Transform>();
        if (_spawnPoint == null) Debug.LogError("spwanPoint is Null");
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        //FloorToInt : �Ҽ��� ���ϴ� ������ ����
        _level = Mathf.Min(Mathf.FloorToInt(GameManager.I.GameTime / 10f), _spawnData.Length -1);    //�ִ뷹�� ���� 0 ~ 1
        if (_timer > _spawnData[_level].SpawnTime)                  //������ ���� ����Ÿ�� ����
        {
            Spawn(); _timer = 0.0f;
        }
    }

    void Spawn()
    {
        //6������ ����ߴ���
        //int index = Random.Range(0, 2); //0 ~ 1
        int point = Random.Range(1, _spawnPoint.Length);            //1 ~ 17, GetComponentsInChildren�� �ڱ⵵ ����

        GameObject enemy = GameManager.I._poolManager.Get(0);
        enemy.transform.position = _spawnPoint[point].position;
        enemy.GetComponent<Enemy>().Init(_spawnData[_level]);       //������ ���� ���� ���͵����� ����
    }
}

[System.Serializable]
public class SpawnData
{
    [SerializeField] int _spriteType;     //���� ����
    [SerializeField] float _spawnTime;    //��ȯ�ð�
    [SerializeField] int _maxHealth;      //ü��
    [SerializeField] float _speed;        //�̵��ӵ�
    public int SpriteType { get { return _spriteType; } }
    public float SpawnTime { get { return _spawnTime; } }
    public int MaxHealth { get { return _maxHealth; } }
    public float Speed { get { return _speed; } }
}
