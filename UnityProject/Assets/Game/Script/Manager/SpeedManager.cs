using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;

public class SpeedManager : Common.CMonoSingleton<SpeedManager>
{
    #region Enum Part
    public enum SpeedState
    {
        NONE,
        ZERO,
        SLOW,
        NORMAL,
        FAST
    }
    #endregion

    #region Show In Inspector
    [Header("UI Setting")]
    [SerializeField]
    private Image m_slowSpeedImage;

    [Header("Time Setting")]
    [SerializeField]
    private float m_slowTimeScale = 0.1f;

    [SerializeField]
    private float m_norTimeScale = 1f;

    [SerializeField]
    private float m_fastTimeScale = 2f;

    [Header("Transition Setting")]
    [SerializeField]
    private float m_transTime = 0.5f;
    #endregion

    #region Hide In Inspector
    private SpeedState m_speedState = SpeedState.NONE;
    private float m_currTimeScale = 1;
    #endregion

    #region Init Part
    protected virtual void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        InitInstance();
        InitEvent();
        InitSpeed();
    }

    protected void InitInstance()
    {
        if (SpeedManager.Instance() != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            s_instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void InitEvent()
    {
        GameManager.Instance().m_GameStartEvent += OnGameStart;
        GameManager.Instance().m_GameOverEvent += OnGameOver;
    }

    private void InitSpeed()
    {
        ChangeTimeSpeed(SpeedState.ZERO);
    }

    #endregion

    #region Update Part
    private void Update()
    {
        switch (m_speedState)
        {
            case SpeedState.SLOW:
                SlowUpdate();
                break;
        }
    }

    private void SlowUpdate()
    {
        if(m_slowSpeedImage.color.a < 1){
            float deltaAlpha = (1 / m_transTime) * Time.deltaTime;
            float alpha = m_slowSpeedImage.color.a + deltaAlpha;
            CCommonFunction.SetImageAlpha(m_slowSpeedImage, alpha);

        }
    }
    #endregion

    #region Event Part
    private void OnGameStart()
    {
        ChangeTimeSpeed(SpeedState.NORMAL);
    }

    private void OnGameOver()
    {
        ChangeTimeSpeed(SpeedState.ZERO);
    }
    #endregion

    #region Function Part
    private void SetSpeedScale(float speedScale)
    {
        Actor[] actors = FindObjectsOfType<Actor>();
        for (int i = 0; i < actors.Length; ++i)
        {
            actors[i].SetSpeedScale(speedScale);
        }
    }

    public void ChangeTimeSpeed(SpeedState speedType)
    {
        if (speedType == m_speedState)
        {
            return;
        }
        m_speedState = speedType;
        switch (m_speedState)
        {
            case SpeedState.ZERO:
                m_currTimeScale = 0;
                break;
            case SpeedState.SLOW:
                m_currTimeScale = m_slowTimeScale;
                break;
            case SpeedState.NORMAL:
                m_currTimeScale = m_norTimeScale;
                break;
            case SpeedState.FAST:
                m_currTimeScale = m_fastTimeScale;
                break;
        }
        SetSpeedScale(m_currTimeScale);
    }
    #endregion
}
