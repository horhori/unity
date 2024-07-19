using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
   // ICharacter형식 구현 프로퍼티
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

            while(true)
            {
                // 이전 체력값과 현재 체력값이 차이날때까지 대기
                yield return new WaitWhile(() => Mathf.Approximately(prevHp, owner.hp));
                /// Mathf.Approximately : 유사한 두개의 부동소수점 값을 비교
                /// 
                
                // 이전 체력에 현재 체력
                prevHp = owner.hp;

                // 체력바의 채울 값으로 계산
                _HPBarImage.fillAmount = prevHp * 0.01f;
            }
             
        }


        // Component와 일치하는 컴포넌트를 부모 오브젝트에서 찾습니다.
        owner = gameObject.GetComponentInParent<ICharacter>();

        // 하위 오브젝트에서 HpBar와 일치하는 오브젝트의 Image컴포넌트를 찾습니다.
        _HPBarImage = transform.Find("HpBar").GetComponent<Image>();

        // 체력바 업데이트 시작
        StartCoroutine(AutoUpdateHpBar());
    }

}
