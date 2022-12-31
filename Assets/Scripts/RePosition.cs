using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePosition : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.I._player.transform.position;
        Vector3 myPos = transform.position;
        // 플레이어와 나의 거리차이
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.I._player.InputVec;
        // 플래이어 방향
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

                break;
        }
    }
}
