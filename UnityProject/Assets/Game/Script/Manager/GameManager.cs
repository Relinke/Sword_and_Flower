using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Common.CMonoSingleton<GameManager>
{
    #region Show In Inspector
	
    #endregion

    #region Hide In Inspector
    #endregion

    #region Init Part
    protected void Awake()
    {
        Init();
    }

    protected void Init()
    {
        CheckInstance();
    }

    protected void CheckInstance()
    {
        if (GameManager.Instance() != this)
        {
            Destroy(gameObject);
            return;
        }
    }
    #endregion
}
