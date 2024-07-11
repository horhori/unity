using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// > GameManager?
// - ���� [�̱���] ������ ����ؼ� ������ ����Ǵ� ��������
// ������ ������ �������� �����ؾ� �ϸ�, ���� ��ü�� ���Ǵ� �����͸� �����ϰų�,
// ���� ��ȯ�Ǿ �����Ǿ�� �ϴ� �����͸� �����մϴ�.

// ����, �����, ��, ����

// [�̱���]
// = �ϳ��� �ν��Ͻ��� �����ؼ� ����ϱ� ���� ������ ����
// ���α׷��� ���۵� �� �� �ѹ��� �޸𸮿� �Ҵ��ϰ�, �� �ν��Ͻ��� ���

public class GameManager : MonoBehaviour
{
    private static GameManager _GameManagerInstance = null;

    public static GameManager gameManager
    {
        get
        {
            return _GameManagerInstance ?? (_GameManagerInstance = GameObject.Find("GameManager").GetComponent<GameManager>());
        }
    }

    // �÷��̾� ĳ���� �ν��Ͻ��� ���� ������Ƽ
    public PlayerInstance playerInstance { get; set; } = null;

    private void Awake()
    {
        #region GameManager �ߺ� ����
        // ���� _GameManagerInstance�� null�� �ƴ϶��
        if(_GameManagerInstance)
        {
            // ������Ʈ�� �����մϴ�.
            Destroy(gameObject);
            return;
        }
        #endregion

        // ���� ��ȯ�Ǿ ������ ������Ʈ�� �������� �ʵ��� �����մϴ�
        DontDestroyOnLoad(gameObject);
    }
}
