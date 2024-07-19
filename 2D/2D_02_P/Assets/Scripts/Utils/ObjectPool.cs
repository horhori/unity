using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// null�� ���޵Ǿ��� �� �߻���ų ���� Ŭ���� ����
public class ParamIsNullException : System.Exception
{
    private string _ParamName;

    public ParamIsNullException(string paramName)
    { _ParamName = paramName; }

    public override string Message
    {
        get { return "���޵� " + _ParamName + "�� ���� null �Դϴ�."; }
    }
}

//  > ������Ʈ Ǯ���� ����� �� �ִ� ������Ʈ�� ���� ������Ʈ��
// �ʼ����� �������̽�

public interface IRecyclableGameObject
{ bool isActive { get; } }

public class ObjectPool<T> where T : IRecyclableGameObject
{
    // ��Ȱ�� ������ ������Ʈ�� ������ ����Ʈ
    private List<T> _ObjectPool = null;

    public ObjectPool()
    {
        _ObjectPool = new List<T>();
    }

    // > ��Ȱ�� ������ ������Ʈ�� ã���ݴϴ�.
    public T GetRecyclableObject()
    {
        // ��Ȱ�� ������ ������Ʈ�� [isActive] �Ӽ��� false�� ������Ʈ�� ã���ϴ�.
        return _ObjectPool.Find(
            (T recyciableObj) => !recyciableObj.isActive);
    }

    // ��Ȱ�� ������ ������Ʈ�� ���
    // ���ϰ�: ��Ͻ�Ų ������Ʈ

    public T RegisterRecyclableObject(T recyciableObj)
    {
        // ����
        if (recyciableObj == null)
            throw new ParamIsNullException("recyclableObj");

        _ObjectPool.Add(recyciableObj);
        return recyciableObj;
    }
}