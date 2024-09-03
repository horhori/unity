using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonster : IHp
{
    // > 몬스터 생사 여부
    bool isDie { get; }

    // > 공격 메서드
    void Attack();

    // > 데미지 메서드
    void Damage(float damage);
}
