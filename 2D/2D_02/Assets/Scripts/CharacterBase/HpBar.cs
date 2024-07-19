using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    // ICharacter 형식 구현 프로퍼티
    public ICharacter owner { get; private set; }

    // HP Image 컴포넌트
    private Image _HPBarImage = null;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        IEnumerator AutoUpdateHpBar()
        {
            // 이전 체력값을 가지고 있을 변수
            float prevHp = owner.hp;

            while (true)
            {
                // 이전 체력값과 현재 체력값이 차이날 때까지 대기
                yield return new WaitWhile(() => Mathf.Approximately(prevHp, owner.hp));
                /// Mathf.Approximately : 유사한 두개의 부동소수점 값을 비교
                /// 프레임 손실 없이 제일 빠르게 확인하는 방법이 coroutine이기 때문에 사용함
                /// 
                // 이전 체력에 현재 체력
                prevHp = owner.hp;

                // 체력바의 채울 값으로 계산(체력바 풀피가(Fiil Amount) 1로 되어있음)
                _HPBarImage.fillAmount = 0.01f;
            }
        }

        // 부모 오브젝트에 EnemyBase가 있는지 확인
        // Component와 일치하는 컴포넌트를 부모 오브젝트에서 찾음
        owner = gameObject.GetComponentInParent<ICharacter>();

        // 하위 오브젝트에서 HpBar와 일치하는 오브젝트의 Image 컴포넌트를 찾음
        _HPBarImage = transform.Find("HpBar").GetComponent<Image>();

        // 체력바 업데이트 시작
        StartCoroutine(AutoUpdateHpBar());
        
    }
}
