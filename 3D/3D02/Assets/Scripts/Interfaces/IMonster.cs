using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonster : IHp
{
    // > ���� ���� ����
    bool isDie { get; }

    // > ���� �޼���
    void Attack();

    // > ������ �޼���
    void Damage(float damage);
}
