using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour, ICharacter
{
    // ĳ������ ���� ���⿡ ���� ������Ƽ
    public Direction lookDirection { get; private set; }

    public Ground existenceArea { get; private set; }

    private CharacterManager _CharacterManager = null;


}
