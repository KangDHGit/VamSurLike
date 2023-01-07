using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // �����յ��� ������ ����
    [SerializeField] GameObject[] prefabs;
    // Ǯ ����� �ϴ� ����Ʈ
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];   //�迭�� �ʱ�ȭ �Ѱ�(����Ʈ�� �ʱ�ȭ �ȵ�)
        for (int i = 0; i < pools.Length; i++)          //�迭���� ����Ʈ �ʱ�ȭ
            pools[i] = new List<GameObject>();
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        //�ε��� ��ȣ = ���� ����
        //������ Ǯ�� ��� �ִ�(��Ȱ��ȭ) ���� ������Ʈ ����
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf) //��Ȱ��ȭ = ����������
            {   //�߰��ϸ� select ������ �Ҵ�
                select = item;
                select.SetActive(true);
                break;
            }
        }

        //��ã������
        if(!select) //select == null�� ������
        {   //�ε��� ��ȣ�� �´� ���͸� ���Ӱ� �����ϰ� select ������ �Ҵ�
            select = Instantiate(prefabs[index], transform);
            //pool�� ���
            pools[index].Add(select);
        }
        return select;
    }
}
