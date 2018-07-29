using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
    private static Manager inst;
    public static Manager Inst
    {
        get
        {
            return inst;
        }
    }

    #region inspector
    public DamageText damagePrefab;
    public Player p1;
    public Player p2;
    public HUD hud;
    #endregion

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

    public void ShowDamageText(int amount, Vector3 position)
    {
        DamageText t = GameObject.Instantiate(damagePrefab);
        t.transform.position = position + Vector3.back * 5;
        t.SetValue(amount);
    }

    public void UpdateUI()
    {
        hud.UpdateUI();
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
