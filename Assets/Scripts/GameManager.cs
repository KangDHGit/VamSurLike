using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public Player _player;
    private void Awake()
    {
        I = this;
        _player.Init();
    }
}
