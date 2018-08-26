using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static int MAX_HP = 100;
    public static float INVINCIBLE_DURATION = 0.9f;

    public HingeJoint2D armJoint;
    public bool player2;
    public Bag Bag;
    public Player Opponent;
    public SpriteRenderer bodySprite;
    public SpriteRenderer armSprite;
    public Transform armPivot;
    public float armPower = 1000f;
    
    private Color bodyColor;
    private Color handbagColor; // separate for now
    private float invincibleEndTime = 0;
    private float flickerTime = 0.1f;
    private int hp = MAX_HP;
    private Vector2 prevDir = Vector2.zero;

	// Use this for initialization
	void Start () {
        bodyColor = bodySprite.color;
        Bag.SetCallback(DamangeOpponent);
	}

    // Update is called once per frame
    void Update()
    {
        if (Manager.Inst.Paused) return;
        HandleInput();
        if (invincibleEndTime > Time.time)
        {
            bool off = Time.time % flickerTime < flickerTime *0.2f;
            bodySprite.color = off ? Color.white : bodyColor;
            armSprite.color = off ? Color.white : bodyColor;
        } else
        {
            bodySprite.color = bodyColor;
            armSprite.color = bodyColor;
        }
    }

    void HandleInput()
    {
        float h = Input.GetAxisRaw(player2 ? "P2_Horizontal" : "P1_Horizontal");
        if (player2) h = -h;
        float v = Input.GetAxisRaw(player2 ? "P2_Vertical" : "P1_Vertical");
        Vector2 dir = new Vector2(h, v);
        if (dir.sqrMagnitude == 0) dir = prevDir;
        prevDir = dir;
        float a = Vector2.Angle(dir, Vector2.up);
        if (dir.x > 0) a = 360-a;
        armPivot.transform.localRotation = Quaternion.Lerp(armPivot.localRotation, Quaternion.AngleAxis(a, Vector3.forward), Time.deltaTime * 12);
    }

    public void TakeDamange(float damage)
    {
        if (invincibleEndTime > Time.time) return;
        int damageTaken = Mathf.FloorToInt(damage);
        Manager.Inst.ShowDamageText(damageTaken, transform.position + Vector3.up * 10f);
        if (damageTaken <= 0) return;
        invincibleEndTime = Time.time + INVINCIBLE_DURATION;
        hp -= damageTaken;
        Manager.Inst.UpdateUI();

    }

    private void DamangeOpponent(float damage)
    {
        Opponent.TakeDamange(damage);
    }

    public int GetHP()
    {
        return hp;
    }

    public void SetHP(int val)
    {
        hp = val;
    }
}
