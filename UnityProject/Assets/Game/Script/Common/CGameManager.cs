using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class CGameManager : Common.CMonoSingleton<CGameManager>
    {
        #region Hide In Inspector
        public delegate void m_VoidDelegate();
        public event m_VoidDelegate m_GameStartEvent;
        public event m_VoidDelegate m_GameOverEvent;
        #endregion

        #region Init Part
        protected virtual void Awake()
        {
            Init();
        }

        protected virtual void Init()
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
            else
            {
                s_instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        #endregion

        #region Function Part
        public virtual void StartGame()
        {
            if (m_GameStartEvent != null)
            {
                m_GameStartEvent();
            }
        }

        public virtual void EndGame()
        {
            if (m_GameOverEvent != null)
            {
                m_GameOverEvent();
            }
        }
        #endregion
    }
}