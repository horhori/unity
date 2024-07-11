using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerInstance : MonoBehaviour, ICharacter
{
    // 플레이어 캐릭터 HP 정보 프로퍼티 
    public float hp { get; private set; } = 100.0f;

    // > 플레이어가 데미지를 입을 수 있는 상태인 구별하기 위한 변수
    private SpriteRenderer _Sprite = null;

    // 폭탄 컴포넌트를 참조할 변수


    private void Awake()
    {
        // 게임이 실행될 때 플레이어 이미지를 찾음
        _Sprite = transform.Find("PlayerImage").GetComponent<SpriteRenderer>();

        // > 플레이어 객체를 참조시킴
        GameManager.gameManager.playerInstance = this;
    }
}
