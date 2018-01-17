using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;

public class GameManager : CGameManager
{
    #region Enum Part
    protected enum GameState
    {
        START,
        PREPARE_RUNNING,
        RUNNING,
        END
    }
    #endregion

    #region Show In Inspector
    [Header("UI Setting")]
    [SerializeField]
    protected Image m_gameStartImage;

    [SerializeField]
    protected Image m_gameOverImage;

    [SerializeField]
    [Range(0, 1)]
    protected float m_initStartImageAlpha = 1;

    [SerializeField]
    protected float m_imageTransitionTime = 1;
    #endregion

    #region Hide In Inspector
    protected GameState m_gameState = GameState.START;
    #endregion

    #region Init Part
    protected override void Init()
    {
        base.Init();
        InitImage();
    }

    protected void InitImage()
    {
        CCommonFunction.SetImageAlpha(m_gameStartImage, m_initStartImageAlpha);
        CCommonFunction.SetImageAlpha(m_gameOverImage, 0);
    }
    #endregion

    #region Update Part
    protected void Update()
    {
        switch (m_gameState)
        {
            case GameState.START:
                StartUpdate();
                break;
            case GameState.PREPARE_RUNNING:
                PrepareRunningUpdate();
                break;
            case GameState.END:
                EndUpdate();
                break;
            case GameState.RUNNING:
                RunningUpdate();
                break;
        }
    }

    protected void StartUpdate()
    {
        if (Time.frameCount >= 5)
        {
            if (Input.anyKeyDown)
            {
                PrepareStartGame();
            }
        }
    }

    protected void PrepareRunningUpdate()
    {
        float alphaDelta = Time.deltaTime / m_imageTransitionTime;
        if (m_gameStartImage.color.a > 0)
        {
            CCommonFunction.SetImageAlpha(m_gameStartImage, m_gameStartImage.color.a - alphaDelta);
        }
        else if (m_gameOverImage.color.a > 0)
        {
            CCommonFunction.SetImageAlpha(m_gameOverImage, m_gameOverImage.color.a - alphaDelta);
        }
        else
        {
            CCommonFunction.SetImageAlpha(m_gameStartImage, 0);
            CCommonFunction.SetImageAlpha(m_gameOverImage, 0);
            StartGame();
        }
    }

    protected void EndUpdate()
    {
        float alphaDelta = Time.deltaTime / m_imageTransitionTime;
        if (m_gameOverImage.color.a < 1)
        {
            CCommonFunction.SetImageAlpha(m_gameOverImage, m_gameOverImage.color.a + alphaDelta);
        }
        else
        {
            CCommonFunction.SetImageAlpha(m_gameOverImage, 1);
            StartGame();
        }
    }

    protected void RunningUpdate()
    {

    }
    #endregion

    #region Function Part
    protected void SwitchState(GameState gameState)
    {
        if (gameState == m_gameState)
        {
            return;
        }
        m_gameState = gameState;
    }

    public void PrepareStartGame()
    {
        SwitchState(GameState.PREPARE_RUNNING);
    }

    public override void StartGame()
    {
        base.StartGame();
        SwitchState(GameState.RUNNING);
    }

    public override void EndGame()
    {
        base.EndGame();
        SwitchState(GameState.END);
    }
    #endregion
}
