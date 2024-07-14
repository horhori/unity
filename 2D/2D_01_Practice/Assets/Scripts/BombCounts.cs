using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCounts : MonoBehaviour
{
    // > bomb ǥ�� �θ� ������Ʈ transform�� ������ ����
    public Transform BombCountsParentTransform = null;

    public GameObject m_BombOri2 = null;

    private GameObject[] bombs;

    public void Start()
    {
        bombs = new GameObject[Player._BombCount];

        for (int i = 0; i < bombs.Length; i++)
        {
            GameObject newBomb = Instantiate(m_BombOri2);

            Vector3 temp = new Vector3(i * 1.2f, 0f, 0f);

            newBomb.transform.position = BombCountsParentTransform.transform.position + temp;

            bombs[i] = newBomb;
        }
    }

    // �÷��̾��� ü�¿� ���� ü�¹� ���̸� ����
    public void Update()
    {
        if (Player._BombCount < bombs.Length)
        {
            Destroy(bombs[bombs.Length - 1]);
            GameObject[] tempbombs = new GameObject[bombs.Length - 1] ;
            for (int i=0; i<bombs.Length-1; i++)
            {
                tempbombs[i] = bombs[i];
            }
            bombs = tempbombs;
        }
    }

}
