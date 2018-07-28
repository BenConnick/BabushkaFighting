using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    private static Manager inst;
    public static Manager Inst
    {
        get
        {
            return inst;
        }
    }

    public bool Paused { get; set; }

	// Use this for initialization
	void Awake () {
        inst = this;
        Physics.IgnoreLayerCollision(8, 8, true);
        Physics.IgnoreLayerCollision(9, 9, true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
