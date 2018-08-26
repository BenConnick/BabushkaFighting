using UnityEngine;

[ExecuteInEditMode]
public class CreatePlayer2 : MonoBehaviour {
    
    private Color bagColor = new Color(0.70196f, 0.68235f, 0.76470f);
    private Color personColor = new Color(0.84705f, 0.84705f, 1.00000f);

    void Update () {
        Player p = GetComponent<Player>();
        if (p == null)
        {
            Debug.LogError("No player component on this object!");
            this.enabled = false;
        }
        bagColor = new Color(0.70196f, 0.68235f, 0.76470f);
        personColor = new Color(0.84705f, 0.84705f, 1.00000f);
        p.player2 = true;
        p.bodySprite.color = personColor;
        p.armSprite.color = personColor;
        p.Bag.GetComponent<SpriteRenderer>().color = bagColor;
        p.transform.localScale = new Vector3(-1, 1, 1);
        gameObject.name = "Player 2";
        SetLayer();
        transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        FindObjectOfType<Manager>().p2 = p;
        Player[] players = FindObjectsOfType<Player>();
        foreach (var player in players)
        {
            if (player.player2) continue;
            p.Opponent = player;
            player.Opponent = p;
            break;
        }
       
        DestroyImmediate(this);
	}

    private void SetLayer() {
        gameObject.layer = LayerMask.NameToLayer("P2");
        SetLayerRecursive(transform);
    }
    
    private void SetLayerRecursive(Transform t)
    {
        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.layer == LayerMask.NameToLayer("P1"))
            {
                t.GetChild(i).gameObject.layer = LayerMask.NameToLayer("P2");
            }
            // recurse
            SetLayerRecursive(t.GetChild(i));
        }
    }
}
