using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public HingeJoint2D armJoint;
    public bool player2;
    public Bag OpponentBag;
	// Use this for initialization
	void Start () {
        OpponentBag.SetCallback(TakeDamange);
	}

    // Update is called once per frame
    void Update()
    {
        if (Manager.Inst.Paused) return;
        HandleInput();
    }

    void HandleInput()
    {
        float h = Input.GetAxisRaw(player2 ? "P2" : "P1");
        ApplyTorque(h * 1000);
    }

    private void ApplyTorque(float torque)
    {
        armJoint.useMotor = true;
        var motor = armJoint.motor;
        motor.motorSpeed = torque;
        armJoint.motor = motor;
    }

    private void TakeDamange(float damage)
    {
        int damageTaken = Mathf.FloorToInt(damage / 20f);
        Manager.Inst.ShowDamageText(damageTaken, transform.position + Vector3.up * 10f);
        //print("Player " + (player2 ? "1" : "2") + " takes " + damageTaken + " damage!");
    }
}
