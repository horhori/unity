using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireMissile : MonoBehaviour
{
    // ���� ���� ��ų �̻��� ������Ʈ ����
    [SerializeField] private MissileInstance _MissileObjectOri = null;

    // ������Ʈ Ǯ���� ���� ��ü�� ������ ����
    private ObjectPool<MissileInstance> _MissilePool = null;

    // �̻��� �߻縦 �˻��ϴ� ����
    private bool _MissileLaunchable = false;

    // �̻��� �߻� ������
    private float _MissileLaunchDelay = 0.07f;

    // �̻��� �߻� ��ġ�� ������ �� ����� ������
    private enum MissileLaunchLoc { Left, Right };
    private MissileLaunchLoc _MissileLoc = MissileLaunchLoc.Left;

    // �̻��� �߻� ��ġ
    public Transform m_MissileLeftLoc, m_MissileRightLoc;


    private void Awake()
    {
        Initialize();
    }

    // �ʱ�ȭ
    private void Initialize()
    {
        // ������Ʈ Ǯ �ʱ�ȭ
        _MissilePool = new ObjectPool<MissileInstance>();

        // �߻� �ڷ�ƾ 
        StartCoroutine(MissileShotDelay());
    }

    // �̻��� �߻� �ڷ�ƾ
    private IEnumerator MissileShotDelay()
    {
        // �ڷ�ƾ?
        // �������� ������ ���� �� �ִ� �Լ�
        //  ���ÿ� ó���Ҷ� �ð� ������ �ΰ� ��� �۾����� ���ؼ�
        // ó���� �� �ֵ��� �����ִ� �Լ� ����
        // �ڷ�ƾ�� �����Ű�� ���� StartCoroutine�� ���ؼ� ����Ѵ�.

        // yield return WaitUntil(Func<bool> predicate)
        /// - predicate�� True�� �ɶ����� ���
        // yield return WaitWhile(Func<bool> predicate)
        /// - predicate�� False�� �ɶ����� ���
        // yield return WaitForSeconds(float time)
        /// - time�� ������ ���� ��� (�ð� �ӵ��� ������ ����)
        // yield return WaitForSecondsRealtime(floa time)
        /// - timedl ������ ���� ��� (�ð� �ӵ��� ������ �ȹ���)
        // yield return WaitForFixedUpdate
        /// - FixedUpdate() ȣ�� �ı��� ���
        // yield return WaitForEndOfFrame
        /// - Update(), FixedUpdate(), ȭ�� �������� ���� �ı��� ���
        // yield return null or 0
        /// - Update()�� ���� ���
        // yield break
        /// �������� �ڷ�ƾ�� ����
        /// 
        while (true)
        {
            // > _MissileLaucchable�� false�� �ɶ����� ���
            yield return new WaitWhile(() => _MissileLaunchable);

            // _MissileLanchDelay��ŭ ���
            yield return new WaitForSeconds(_MissileLaunchDelay);

            // _MissileLaunchable�� true �����ؼ� �̻����� �߻�ɼ� �ֵ���
            _MissileLaunchable = true;
        }
    }

    private void Update()
    {
        InputKey();
    }

    private void InputKey()
    {
        // �����̽��� ���Ȱ�, �̻��ϵ� �߻� ���� ����
        if(Input.GetKey(KeyCode.Space) && _MissileLaunchable)
        {
            // ������ ������ ������Ʈ�� ã�� ��
            // ���� ã�� ���ߴٸ� ���ο� �̻��� ������Ʈ�� ���� �� ������Ʈ Ǯ ���

            MissileInstance missile =
                _MissilePool.GetRecyclableObject() ??
                _MissilePool.RegisterRecyclableObject(Instantiate(_MissileObjectOri));

            // �̻����� Ȱ��ȭ
            missile.gameObject.SetActive(true);

            //  �̻��� ��ġ ����
            missile.transform.position = (_MissileLoc == MissileLaunchLoc.Left) ?
                m_MissileLeftLoc.position : m_MissileRightLoc.position;

            // �߻� ��ġ ����
            _MissileLoc = (_MissileLoc == MissileLaunchLoc.Left) ?
                MissileLaunchLoc.Right : MissileLaunchLoc.Left;

            _MissileLaunchable = false;
        }
    }
}
