using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : MonoBehaviour, IRecyclableGameObject
{
    public ProjectileMovement projectile { get; private set; }

    private PlayerInstance _PlayerInstance = null;

    public bool isActive { get; set; }

    // 플레이어와의 거리 검사 후 오브젝트 자동 비활성화 코루틴
    private IEnumerator AutoDeactivate()
    {
        // _PlayerInstance가 null이 아닐 때까지 대기
        yield return new WaitUntil(() => _PlayerInstance);

        // 플레이어와의 거리가 50만큼 벌어질 때까지 대기
        yield return new WaitUntil(() => (
        Vector3.Distance(_PlayerInstance.transform.position, transform.position) >= 50.0f));

        // 오브젝트 비활성
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        projectile = projectile ?? GetComponent<ProjectileMovement>();
        _PlayerInstance = _PlayerInstance ?? GameManager.GetManagerClass<CharacterManager>().player;

        projectile.Initialize(_PlayerInstance.playerMovement.lookDirection);
    }

    private void OnDisable()
    {
        isActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Monster" ||
            LayerMask.LayerToName(other.gameObject.layer) == "Ground")
        {
            gameObject.SetActive(false);
        }
    }
}
