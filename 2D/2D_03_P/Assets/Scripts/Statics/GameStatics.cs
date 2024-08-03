using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStatics
{
    // bounds내에서 랜덤한 위치
    public static Vector2 GetRandomPositionInBounds(Bounds bounds)
    {
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y));
    }
}
