using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리팹들을 보관할 변수
    [SerializeField] GameObject[] prefabs;
    // 풀 담당을 하는 리스트
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];   //배열만 초기화 한것(리스트는 초기화 안됨)
        for (int i = 0; i < pools.Length; i++)          //배열안의 리스트 초기화
            pools[i] = new List<GameObject>();
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        //인덱스 번호 = 몬스터 종류
        //선택한 풀의 놀고 있는(비활성화) 게임 오브젝트 접근
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf) //비활성화 = 놀고있을경우
            {   //발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }

        //못찾았으면
        if(!select) //select == null과 같은말
        {   //인덱스 번호에 맞는 몬스터를 새롭게 생성하고 select 변수에 할당
            select = Instantiate(prefabs[index], transform);
            //pool에 등록
            pools[index].Add(select);
        }
        return select;
    }
}
