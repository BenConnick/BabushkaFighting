using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

    public ProgressBar p1HP;
    public ProgressBar p2HP;

	public void UpdateUI () {
        p1HP.Percent = Manager.Inst.p1.GetHP() / (float)Player.MAX_HP;
        p2HP.Percent = Manager.Inst.p2.GetHP() / (float)Player.MAX_HP;
    }
}
