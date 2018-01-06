///
// Test for game
///
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class Test : CMonoSingleton<Test>
{
    #region Show In Inspector
    #endregion

    #region Hide In Inspector
    [HideInInspector]
    public float time = 0;
    #endregion

    #region Init Part
    private void Awake()
    {
        Init();
    }
    private void Init()
    {

    }
    #endregion

    #region Update Part
    private void Update()
    {
        time += Time.deltaTime;

    }

    private void FixedUpdate()
    {

    }
    #endregion
}
