using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedManager : Common.CMonoSingleton<SpeedManager> {
    #region Enum Part
    public enum SpeedType{
        NONE,
        LOW,
        NORMAL,
        FAST
    }
    #endregion

    #region Show In Inspector
    [Header("UI Setting")]
    [SerializeField]
    private Image m_lowSpeedImage;

    [Header("Time Setting")]
    [SerializeField]
    private float m_lowTimeScale = 0.1f;
    #endregion

    #region Hide In Inspector
    private SpeedType m_speedType = SpeedType.NONE;
    #endregion

    #region Function Part
	private void SetSpeedScale(float speedScale){
        Actor[] actors = FindObjectsOfType<Actor>();
        for(int i = 0; i < actors.Length; ++i){
            actors[i].SetSpeedScale(speedScale);
        }
    }

    public void ChangeTimeSpeed(SpeedType speedType){
        if(speedType == m_speedType){
            return;
        }
        m_speedType = speedType;
    }
    #endregion
}
