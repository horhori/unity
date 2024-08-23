using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour, IManager
{
    public GameManager gameManager
    {
        get
        {
            return GameManager.gameManager;
        }
    }

    // 조이스틱 방향벡터
    public Vector3 inputVector { get; set; }

    // 캐릭터 인스턴스 프로퍼티
    public PlayerInstance player { get; set; }

    // 공격력 프로퍼티
    public float playerAtk { get; private set; } = 100.0f;

    // 공격 상태 제어 함수
    public float SetAtk(float atk)
    {
        return playerAtk = atk;
    }
}
