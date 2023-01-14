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
        //FloorToInt : 소수점 이하는 버리는 정수
        _level = Mathf.Min(Mathf.FloorToInt(GameManager.I.GameTime / 10f), _spawnData.Length -1);    //최대레벨 제한 0 ~ 1
        if (_timer > _spawnData[_level].SpawnTime)                  //레벨에 따른 스폰타임 변경
        {
            Spawn(); _timer = 0.0f;
        }
    }

    void Spawn()
    {
        //6강에서 사용했던것
        //int index = Random.Range(0, 2); //0 ~ 1
        int point = Random.Range(1, _spawnPoint.Length);            //1 ~ 17, GetComponentsInChildren은 자기도 포함

        GameObject enemy = GameManager.I._poolManager.Get(0);
        enemy.transform.position = _spawnPoint[point].position;
        enemy.GetComponent<Enemy>().Init(_spawnData[_level]);       //레벨에 따른 스폰 몬스터데이터 변경
    }
}

[System.Serializable]
public class SpawnData
{
    [SerializeField] int _spriteType;     //몬스터 종류
    [SerializeField] float _spawnTime;    //소환시간
    [SerializeField] int _maxHealth;      //체력
    [SerializeField] float _speed;        //이동속도
    public int SpriteType { get { return _spriteType; } }
    public float SpawnTime { get { return _spawnTime; } }
    public int MaxHealth { get { return _maxHealth; } }
    public float Speed { get { return _speed; } }
}
