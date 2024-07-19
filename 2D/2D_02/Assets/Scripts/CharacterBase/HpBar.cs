using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    // ICharacter ���� ���� ������Ƽ
    public ICharacter owner { get; private set; }

    // HP Image ������Ʈ
    private Image _HPBarImage = null;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        IEnumerator AutoUpdateHpBar()
        {
            // ���� ü�°��� ������ ���� ����
            float prevHp = owner.hp;

            while (true)
            {
                // ���� ü�°��� ���� ü�°��� ���̳� ������ ���
                yield return new WaitWhile(() => Mathf.Approximately(prevHp, owner.hp));
                /// Mathf.Approximately : ������ �ΰ��� �ε��Ҽ��� ���� ��
                /// ������ �ս� ���� ���� ������ Ȯ���ϴ� ����� coroutine�̱� ������ �����
                /// 
                // ���� ü�¿� ���� ü��
                prevHp = owner.hp;

                // ü�¹��� ä�� ������ ���(ü�¹� Ǯ�ǰ�(Fiil Amount) 1�� �Ǿ�����)
                _HPBarImage.fillAmount = 0.01f;
            }
        }

        // �θ� ������Ʈ�� EnemyBase�� �ִ��� Ȯ��
        // Component�� ��ġ�ϴ� ������Ʈ�� �θ� ������Ʈ���� ã��
        owner = gameObject.GetComponentInParent<ICharacter>();

        // ���� ������Ʈ���� HpBar�� ��ġ�ϴ� ������Ʈ�� Image ������Ʈ�� ã��
        _HPBarImage = transform.Find("HpBar").GetComponent<Image>();

        // ü�¹� ������Ʈ ����
        StartCoroutine(AutoUpdateHpBar());
        
    }
}
