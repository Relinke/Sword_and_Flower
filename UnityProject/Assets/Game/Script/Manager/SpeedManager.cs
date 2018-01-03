using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : Common.CMonoSingleton<SpeedManager> {
	public void SetSpeedScale(float speedScale){
        Actor[] actors = FindObjectsOfType<Actor>();
        for(int i = 0; i < actors.Length; ++i){
            actors[i].SetSpeedScale(speedScale);
        }
    }
}
