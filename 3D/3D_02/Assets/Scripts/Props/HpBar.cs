using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Transform _HUDTransform = null;

    [SerializeField] private Image _HpBarImage = null;

    [SerializeField] private Text _HpCountText = null;

    private IHp _Owner = null;

    private Camera _Camera = null;

    private void Start()
    {
        IEnumerator AutoDisable()
        {
            yield return new WaitUntil(() => !_HUDTransform.parent.gameObject.activeSelf);
            gameObject.SetActive(false);
        }

        // 현재 체력에 최대 체력을 대입
        _Owner = _HUDTransform.GetComponentInParent<IHp>();
        _Owner.hp = _Owner.maxHp;

        _Camera = GameObject.Find("FollowCamera").GetComponent<FollowCamera>().camera;

        StartCoroutine(AutoUpdateCurrentHp());
        StartCoroutine(AutoDisable());
    }

    private void Update()
    {
        void FollowHUDPosition()
        {
            transform.position = _HUDTransform.position;
        }

        void LookAtCamera()
        {
            Quaternion newRotation = Quaternion.LookRotation(
                gameObject.GetDirectionVector(_Camera.gameObject) * -1.0f);
            newRotation.y = newRotation.z = 0.0f;

            transform.rotation = newRotation;
        }

        FollowHUDPosition();
        LookAtCamera();
    }

    private IEnumerator AutoUpdateCurrentHp()
    {
        yield return new WaitUntil(() => _HpBarImage);

        // 이전 체력값 저장할 변수
        float prevCurrentHp = _Owner.hp;

        while (true)
        {
            yield return new WaitUntil(() => prevCurrentHp != _Owner.hp);
            prevCurrentHp = _Owner.hp;
            _HpBarImage.fillAmount = (_Owner.hp / _Owner.maxHp);
            _HpCountText.text = ((int)_Owner.hp).ToString();

        }
    }

    public void SetHUDTransform(Transform hudTransform)
    {
        _HUDTransform = hudTransform;
    }
}
