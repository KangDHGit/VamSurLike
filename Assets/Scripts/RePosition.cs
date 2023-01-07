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
        // �÷��̾�� ���� �Ÿ�����(x��, y��)
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.I._player.InputVec;
        // �÷��̾��� �̵�����
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if(diffX > diffY)                                   //�÷��̾ ���� x�� �Ÿ��� �� �ְ��
                    transform.Translate(Vector3.right * dirX * 40); //x������ �־��� �������� �̵�
                else if(diffX < diffY)
                    transform.Translate(Vector3.up * dirY * 40);    //y������ �־��� �������� �̵�
                break;
            case "Enemy":
                if(_col.enabled) //���� �����������̸�(���� ��ü�� �浹�ϸ� �ȵǱ⶧����, �� isLive�������� �Ŵ��� �ʿ� ����)
                {
                    //������� ������ �������� ����
                    Vector3 randomRange = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0);

                    transform.Translate(playerDir * 20 + randomRange); //�÷��̾�� �־����� �ݴ����� ��Ÿ������!
                }
                break;
        }
    }
}
