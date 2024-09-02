using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  > null �� ���޵Ǿ��� �� �߻���ų ���� Ŭ������ �����մϴ�.
public class ParamIsNullException : System.Exception
{
    private string _ParamName;

    public ParamIsNullException(string paramName)
    { _ParamName = paramName; }

    public override string Message
    { get { return "���޵� " + _ParamName + "�� ���� null �Դϴ�."; } }
}





public class ObjectPool<T> where T : IRecyclableGameObject
{
    //  > ��Ȱ�� ������ ������Ʈ�� ������ ����Ʈ�Դϴ�.
    private List<T> _ObjectPool = null;

    public ObjectPool()
    {
        _ObjectPool = new List<T>();
    }

    //  > ��Ȱ�� ������ ������Ʈ�� ã���ϴ�.
    public T GetRecyclableObject()
    {
        //  > ��Ȱ�� ������ ������Ʈ �� [isActive] �Ӽ��� false �� ������Ʈ�� ã���ϴ�.
        return _ObjectPool.Find(
            (T recyclableObj) => !recyclableObj.isActive);
    }

    //  > ��Ȱ�� ������ ������Ʈ�� ����մϴ�
    /// - ���� �� : ��Ͻ�Ų ������Ʈ�� ���Ͻ�ŵ�ϴ�.
    public T RegisterRecyclableObject(T recyclableObj)
    {
        //  > recyclableObj �� null �̶�� ���ܸ� �����ϴ�.
        if (recyclableObj == null)
            throw new ParamIsNullException("recyclableObj");

        _ObjectPool.Add(recyclableObj);
        return recyclableObj;
    }

}
