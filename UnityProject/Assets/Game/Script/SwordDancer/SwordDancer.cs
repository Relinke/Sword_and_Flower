using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordDancer : MonoBehaviour
{
    #region Show In Inspector
    [Header("Attribute Setting")]
    [SerializeField]
    protected float m_turnSpeed = 30;

    [SerializeField]
    protected float m_slowTimeScale = 0.1f;

    [Header("Prefab Setting")]
    [SerializeField]
    protected Sword m_swordPrefab;

    [Header("Game Object Setting")]
    [SerializeField]
    protected GameObject m_guideLine;

    [Header("Component Setting")]
    [SerializeField]
    protected SpriteRenderer m_spriteRenderer;
    #endregion

    #region Hide In Inspector
    protected Sword m_aliveSword;
    protected bool m_firstControl = false;
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
        InputUpdate();
    }

    protected void InputUpdate()
    {
        if (m_spriteRenderer.gameObject.activeInHierarchy)
        {
            bool leftKey = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
            bool rightKey = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

            if (leftKey)
            {
                m_firstControl = true;
                TurnDirection(m_turnSpeed * Time.deltaTime);
            }
            else if (rightKey)
            {
                m_firstControl = true;
                TurnDirection(-m_turnSpeed * Time.deltaTime);
            }
            else if (!Input.anyKeyDown & !Input.anyKey)
            {
                if (m_firstControl)
                {
                    ShootSword();
                }
            }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                SwordBack();
            }
        }
    }
    #endregion

    #region Function Part
    protected void TurnDirection(float turnAngle)
    {
        Vector3 eulerAngle = transform.eulerAngles;
        eulerAngle.z += turnAngle;
        transform.eulerAngles = eulerAngle;
    }

    protected void ShootSword()
    {
        m_spriteRenderer.gameObject.SetActive(false);
        m_guideLine.SetActive(false);
        if (!m_aliveSword)
        {
            m_aliveSword = Instantiate(m_swordPrefab);
        }
        m_aliveSword.gameObject.SetActive(true);
        m_aliveSword.transform.position = transform.position;
        m_aliveSword.transform.eulerAngles = transform.eulerAngles;
        SpeedManager.Instance().ChangeTimeSpeed(SpeedManager.SpeedState.NORMAL);

    }

    protected void SwordBack()
    {
        m_spriteRenderer.gameObject.SetActive(true);
        m_guideLine.SetActive(true);
        m_aliveSword.gameObject.SetActive(false);
        transform.position = m_aliveSword.transform.position;
        transform.eulerAngles = m_aliveSword.transform.eulerAngles;
        SpeedManager.Instance().ChangeTimeSpeed(SpeedManager.SpeedState.SLOW);
    }
    #endregion
}
