using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour, IManager
{
    public GameManager gameManager { get; private set; }

    // �÷��̾� ĳ���� ������Ƽ
    public PlayerInstance playerCharacter { get; set; }

    // ĳ���Ͱ� �����ϴ� �� ������ ���� ������Ƽ
    public Ground playerExistenceArea { get; set; }

    // ��ȣ �ۿ� ������ ������Ʈ

}
