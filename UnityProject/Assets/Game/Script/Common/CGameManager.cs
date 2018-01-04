using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class CGameManager : CMonoSingleton<CGameManager>
    {
		protected void Awake(){
			if(CGameManager.Instance() != this){
				Destroy(gameObject);
				return;
			}
			// Test Branch
		}
    }
}
