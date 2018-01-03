using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Actor
{
    #region Show In Inspector
    [Header("Sword Component Setting")]
    [SerializeField]
    protected Transform m_head;
    [SerializeField]
    protected Transform m_rear;
    #endregion

    #region Hide In Inspector
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

    }

    private void FixedUpdate()
    {
        MoveFixUpdate();
    }

    protected void MoveFixUpdate()
    {
        if (m_speed != 0)
        {
            Vector2 moveDir = (m_head.position - m_rear.position).normalized;
            transform.position += (Vector3)(moveDir * m_speed * Time.deltaTime * m_speedScale);
        }
    }
    #endregion

    #region Collision Part
    protected void OnTriggerEnter2D(Collider2D collider2D)
    {
        Destroy(collider2D.gameObject);
    }
    #endregion

    #region Function Part
    protected void TurnDirection(float turnAngle)
    {
        Vector3 eulerAngle = transform.eulerAngles;
        eulerAngle.z += turnAngle;
        transform.eulerAngles = eulerAngle;
    }
    #endregion
}
