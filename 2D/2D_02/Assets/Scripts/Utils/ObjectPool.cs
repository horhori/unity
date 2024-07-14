using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// null�� ���޵Ǿ��� �� �߻���ų ���� Ŭ���� ����
public class ParamIsNullException : System.Exception
{
    private string _ParamName;

    public ParamIsNullException(string paramName)
    {
        _ParamName = paramName;
    }

    public override string Message
    {
        get
        {
            return "���޵� " + _ParamName + "�� ���� null �Դϴ�.";
        }
    }
}

// > ������Ʈ Ǯ���� ����� �� �ִ� ������Ʈ�� ���� ������Ʈ��
// �ʼ����� �������̽�

public interface IRecyclableGameObject
{
    bool isActive { get; }
}

public class ObjectPool<T> where T : IRecyclableGameObject
{
    // ��Ȱ�� ������ ������Ʈ�� ������ ����Ʈ
    private List<T> _ObjectPool = null;

    public ObjectPool()
    {
        _ObjectPool = new List<T>();
    }

    // ��Ȱ�� ������ ������Ʈ�� ã����
    public T GetRecyclableObject()
    {
        // ��Ȱ�� ������ ������Ʈ �� [isActive] �Ӽ��� false�� ������Ʈ�� ã��
        return _ObjectPool.Find(
            (T recyclableObj) => !recyclableObj.isActive);
    }

    // ��Ȱ�� ������ ������Ʈ�� ���
    // ���ϰ� : ��Ͻ�Ų ������Ʈ

    public T RegisterRecyclableObject(T recyclableObj)
    {
        // ���� ó��
        if(recyclableObj == null)
        {
            throw new ParamIsNullException("recyclableObj");
        }

        _ObjectPool.Add(recyclableObj);
        return recyclableObj;
    }
}