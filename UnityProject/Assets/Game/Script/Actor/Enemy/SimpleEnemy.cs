using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Actor
{
    protected Flower m_flower;
    private void Awake()
    {
        m_flower = FindObjectOfType<Flower>();
    }

    private void Update()
    {
        MoveUpdate();
    }

    protected void MoveUpdate()
    {
		if (m_speed != 0)
        {
			Vector2 moveDir = (m_flower.transform.position - transform.position).normalized;
            transform.position += (Vector3)(moveDir * m_speed * Time.deltaTime * m_speedScale);
        }
    }
}
