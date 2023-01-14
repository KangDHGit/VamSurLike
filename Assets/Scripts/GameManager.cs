using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public Player _player;
    public PoolManager _poolManager;

    [SerializeField] float _gameTime; public float GameTime { get { return _gameTime; } }
    [SerializeField] float _maxGameTime = 2 * 10f;
    
    private void Awake()
    {
        I = this;
        _player.Init();
    }

    private void Update()
    {
        _gameTime += Time.deltaTime;
        if (_gameTime > _maxGameTime)
            _gameTime = _maxGameTime;
    }
}
