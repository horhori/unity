using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : MonoBehaviour, IRecyclableGameObject
{
    public ProjectileMovement projectile { get; private set; }

    private PlayerInstance _PlayerInstance = null;

    public bool isActive { get; set; }

    // �÷��̾���� �Ÿ� �˻� �� ������Ʈ �ڵ� ��Ȱ��ȭ �ڷ�ƾ
    private IEnumerator AutoDeactivate()
    {
        // _PlayerInstance�� null�� �ƴ� ������ ���
        yield return new WaitUntil(() => _PlayerInstance);

        // �÷��̾���� �Ÿ��� 50��ŭ ������ ������ ���
        yield return new WaitUntil(() => (
        Vector3.Distance(_PlayerInstance.transform.position, transform.position) >= 50.0f));

        // ������Ʈ ��Ȱ��
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
