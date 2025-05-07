using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooleable
{
    public void ResetToDefault();
    public void GetObjectFromPool();
    public void ReturntoPool();

    public void SetParent();

}


