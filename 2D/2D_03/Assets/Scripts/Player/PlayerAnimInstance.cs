using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimInstance : MonoBehaviour, IAnimInstance
{
    // 제어하는 애니메이터에 대한 프로퍼티
    public Animator animator { get; private set; }

    // 최상위 부모 오브젝트에 추가된 PlayerInstance 컴포넌트에 참조 변수
    private PlayerInstance _PlayerInstance = null;

    // 플레이어의 보는 방향을 문자열로 가져올 변수
    private string _AnimDirection = "";

    // 플레이어의 액션 상태 문자열 변수
    private string _PlayerAction = "";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _PlayerInstance = GetComponentInParent<PlayerInstance>();
    }

    private void Update()
    {
        UpdateAnimData();
        AnimationControl();
    }

    // 애니메이션 재생에 필요한 데이터를 받아옴
    private void UpdateAnimData()
    {
        _AnimDirection = _PlayerInstance.lookDirection.ToString();
        _PlayerAction = _PlayerInstance.playerAction.ToString();
    }

    private void AnimationControl()
    {
        animator.Play(_PlayerAction + _AnimDirection);
    }
}
