using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// > x 위치에 따라 랜더 순서를 자동으로 결정하는 컴포넌트
[RequireComponent(typeof(SpriteRenderer))]
public class AutoRenderSequence : MonoBehaviour
{
    // SpriteRenderer Component에 저장할 변수
    private SpriteRenderer _SpriteRenderer = null;

    // 랜더순서의 기본 값
    [Range(-20, 20)]
    public int m_RenderInitialSequence = 0;

    // 이미지 랜더 순서를 결정할 때 사용할 중심 좌표
    [SerializeField] private Transform _Pivot = null;

    // 오브젝트가 속한 영역 변수
    private Ground _ExistenceArea = null;

    private void Awake()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();

        // 부모 오브젝트에서 Ground 컴포넌트 찾습니다.
        _ExistenceArea =  GetComponentInParent<Ground>();
        if (_ExistenceArea)
        {
            // 할거 적기
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
            // 이전 좌표에 현재 좌표를 저장
            prevPositionY = transform.position.y;

            // 랜더 순서를 연산 대입
            _SpriteRenderer.sortingOrder = GetCalculateSortingOrder();

            // 이전 좌표와 현재 좌표가 드라다면
            yield return new WaitWhile(
                () => Mathf.Approximately(prevPositionY, transform.position.y));
        }
    }
}
