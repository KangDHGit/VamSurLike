using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwaner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoint;
    float timer;
    [SerializeField] float spawnTime;

    void Start()
    {
        init();
    }

    void init()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        if (spawnPoint == null) Debug.LogError("spwanPoint is Null");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            Spawn(); timer = 0.0f;
        }
    }

    void Spawn()
    {
        int index = Random.Range(0, 2); //0 ~ 1
        int point = Random.Range(1, 18); //1 ~ 17, GetComponentsInChildren은 자기도 포함

        GameObject enemy = GameManager.I._poolManager.Get(index);
        enemy.transform.position = spawnPoint[point].position;
    }
}
