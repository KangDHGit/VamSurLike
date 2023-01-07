using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePosition : MonoBehaviour
{
    Collider2D _col;
    private void Start()
    {
        init();
    }
    void init()
    {
        if (!TryGetComponent(out _col))
            Debug.Log(this.gameObject.name + "_col is NULL");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.I._player.transform.position;
        Vector3 myPos = transform.position;
        // 플레이어와 나의 거리차이(x축, y축)
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.I._player.InputVec;
        // 플래이어의 이동방향
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if(diffX > diffY)                                   //플레이어가 나랑 x축 거리가 더 멀경우
                    transform.Translate(Vector3.right * dirX * 40); //x축으로 멀어진 방향으로 이동
                else if(diffX < diffY)
                    transform.Translate(Vector3.up * dirY * 40);    //y축으로 멀어진 방향으로 이동
                break;
            case "Enemy":
                if(_col.enabled) //적이 안죽은상태이면(적의 시체는 충돌하면 안되기때문에, 꼭 isLive변수에만 매달일 필요 없다)
                {
                    //어느정도 랜덤한 범위에서 등장
                    Vector3 randomRange = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0);

                    transform.Translate(playerDir * 20 + randomRange); //플레이어랑 멀어지면 반대편에서 나타나도록!
                }
                break;
        }
    }
}
