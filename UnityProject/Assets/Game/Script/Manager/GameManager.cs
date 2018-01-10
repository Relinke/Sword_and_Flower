using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    protected float m_imageDisappearTime = 1;
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
        SetImageAlpha(m_gameStartImage, m_initStartImageAlpha);
        SetImageAlpha(m_gameOverImage, 0);
    }
    #endregion

    #region Update Part
    protected void Update()
    {
        switch (m_gameState)
        {
            case GameState.START:
                break;
            case GameState.PREPARE_RUNNING:
                break;
            case GameState.END:
                break;
            case GameState.RUNNING:
                break;
        }
    }

    protected void PrepareRunning()
    {
        float alphaDelta = Time.deltaTime / m_imageDisappearTime;
        if (m_gameStartImage.color.a > 0)
        {
            SetImageAlpha(m_gameStartImage, m_gameStartImage.color.a - alphaDelta);
        }
        else if (m_gameOverImage.color.a > 0)
        {
            SetImageAlpha(m_gameOverImage, m_gameOverImage.color.a - alphaDelta);
        }
        else
        {
            SwitchState(GameState.RUNNING);
        }
    }

    protected void EndUpdate()
    {
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

    protected void SetImageAlpha(Image image, float alpha)
    {
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }

    public override void StartGame()
    {
        base.StartGame();
        SwitchState(GameState.PREPARE_RUNNING);
    }
    #endregion
}
