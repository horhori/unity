using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour, ICharacter
{
    // 캐릭터의 보는 방향에 대한 프로퍼티
    public Direction lookDirection { get; private set; }

    public Ground existenceArea { get; private set; }

    private CharacterManager _CharacterManager = null;


}
