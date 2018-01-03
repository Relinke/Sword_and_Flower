using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    #region Show In Inspector
    [Header("Component Setting")]
    [SerializeField]
    protected Animator m_animator;
    [Header("Actor Attribute Setting")]
    [SerializeField]
    protected float m_speed;
    #endregion

    #region Hide In Inspector
    [HideInInspector]
    protected float m_speedScale = 1;
    #endregion

    public virtual void SetSpeedScale(float speedScale)
    {
        m_speedScale = speedScale;
        if (m_animator)
        {
            m_animator.speed = m_speedScale;
        }
    }
}
