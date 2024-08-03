using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractionable
{
    // 상호 작용 가능한 오브젝트의 이름
    string interactionName { get; }

    // 상호작용 시 호출할 메서드
    void Interaction();
}
