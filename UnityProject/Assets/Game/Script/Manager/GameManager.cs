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
    #endregion

    #region Hide In Inspector
    protected GameState m_gameState = GameState.END;
    #endregion

    #region Init Part
    #endregion

    #region Update Part
    protected void Update()
    {
        switch (m_gameState)
        {
            case GameState.END:
                break;
            case GameState.RUNNING:
                break;
        }
    }

    protected void EndUpdate(){
    }

    protected void RunningUpdate(){

    }
    #endregion

    #region Function Part
    protected void SwitchState(GameState gameState){
        if(gameState == m_gameState){
            return;
        }
        m_gameState = gameState;
    }
    #endregion
}
