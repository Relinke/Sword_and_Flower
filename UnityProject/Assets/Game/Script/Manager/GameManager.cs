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
    #endregion

    #region Hide In Inspector
    protected GameState m_gameState = GameState.START;
    #endregion

    #region Init Part
    protected override void Init(){
        base.Init();
        InitStartImage();
    }

    protected void InitStartImage(){
        SetImageAlpha(m_gameStartImage, m_initStartImageAlpha);
    }
    #endregion

    #region Update Part
    protected void Update()
    {
        switch (m_gameState)
        {
            case GameState.START:
                break;
            case GameState.END:
                break;
            case GameState.RUNNING:
                break;
        }
    }

    protected void StartUpdate(){

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

    protected void SetImageAlpha(Image image, float alpha){
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }
    #endregion
}
