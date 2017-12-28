using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour {
	#region Show In Inspector
	#endregion

	#region Hide In Inspector
	#endregion

	#region Init Part
	private void Awake(){
		Init();
	}
	private void Init(){
		
	}
	#endregion

	#region Update Part
	private void Update () {
		Debug.Log(Test.Instance().time);
	}

	private void FixedUpdate()
	{

	}
	#endregion

	
}
