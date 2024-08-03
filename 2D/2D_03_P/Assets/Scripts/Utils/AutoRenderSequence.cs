using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// > x ��ġ�� ���� ���� ������ �ڵ����� �����ϴ� ������Ʈ
[RequireComponent(typeof(SpriteRenderer))]
public class AutoRenderSequence : MonoBehaviour
{
    // SpriteRenderer Component�� ������ ����
    private SpriteRenderer _SpriteRenderer = null;

    // ���������� �⺻ ��
    [Range(-20, 20)]
    public int m_RenderInitialSequence = 0;

    // �̹��� ���� ������ ������ �� ����� �߽� ��ǥ
    [SerializeField] private Transform _Pivot = null;

    // ������Ʈ�� ���� ���� ����
    private Ground _ExistenceArea = null;

    private void Awake()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();

        // �θ� ������Ʈ���� Ground ������Ʈ ã���ϴ�.
        _ExistenceArea =  GetComponentInParent<Ground>();
        if (_ExistenceArea)
        {
            // �Ұ� ����
        }
    }

    private IEnumerator StartChangeRenderSequence()
    {
        int GetCalculateSortingOrder()
        {
            return (int)(_Pivot.transform.position.y * -100.0f) + m_RenderInitialSequence;
        }

        float prevPositionY = 0.0f;

        while (true)
        {
            // ���� ��ǥ�� ���� ��ǥ�� ����
            prevPositionY = transform.position.y;

            // ���� ������ ���� ����
            _SpriteRenderer.sortingOrder = GetCalculateSortingOrder();

            // ���� ��ǥ�� ���� ��ǥ�� ���ٸ�
            yield return new WaitWhile(
                () => Mathf.Approximately(prevPositionY, transform.position.y));
        }
    }
}
