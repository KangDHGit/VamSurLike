using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public Player _player;
    public PoolManager _poolManager;
    private void Awake()
    {
        I = this;
        _player.Init();
    }
}
