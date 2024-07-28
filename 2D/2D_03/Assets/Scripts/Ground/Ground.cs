using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Ground : MonoBehaviour
{
    private CharacterManager _CharacterManager = null;

    public BoxCollider2D area {  get; private set; }

    private void Awake()
    {
        _CharacterManager = GameManager.GetManagerClass<CharacterManager>();
        area = GetComponent<BoxCollider2D>();
        area.isTrigger = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어랑 겹치면
        if(collision.CompareTag("Player"))
        {
            // 플레이어가 속한 맵 영역을 자기자신(Ground)으로 설정
            _CharacterManager.playerExistenceArea = this;
        }
    }
}