using UnityEngine;

public abstract class UsableObject : MonoBehaviour
{
    protected int _count;

    public void SetCount(int num)
    {
        if(num > 0)
        {
            _count = num;
        }
    }

    abstract protected void OnTriggerEnter(Collider other);
}
