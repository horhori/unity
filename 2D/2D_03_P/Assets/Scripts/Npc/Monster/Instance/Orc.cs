using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : TrackingMonsterBase
{
    public SimpleMonsterAnimInstance anim { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        anim = GetComponentInChildren<SimpleMonsterAnimInstance>();
    }

    private void Update()
    {
        anim.UpdateAnimationData(movement.dirVector.x, (movement.dirVector != Vector2.zero));
    }
}
