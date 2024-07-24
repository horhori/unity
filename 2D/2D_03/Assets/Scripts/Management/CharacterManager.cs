using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour, IManager
{
    public GameManager gameManager { get; private set; }

    // 플레이어 캐릭터 프로퍼티
    public PlayerInstance playerCharacter { get; set; }

    // 캐릭터가 존재하는 맵 영역에 대한 프로퍼티
    public Ground playerExistenceArea { get; set; }

    // 상호 작용 가능한 오브젝트

}
