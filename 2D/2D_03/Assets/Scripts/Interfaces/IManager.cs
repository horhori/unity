using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 매니저 클래스에 구현되어야 하는 인터페이스
public interface IManager
{
   // 게임 매니저에 대한 읽기 전용 프로퍼티
   GameManager gameManager { get; }
}
