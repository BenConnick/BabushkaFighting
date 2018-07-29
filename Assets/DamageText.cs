using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMesh))]
public class DamageText : MonoBehaviour {

    TextMesh textMesh;
	// Use this for initialization
	void Awake () {
        textMesh = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Time.deltaTime * Vector3.up * 10f;
        if (transform.position.y > Camera.main.orthographicSize * 1.5f)
        {
            Destroy(gameObject);
        }
	}

    public void SetValue(int damage)
    {
        textMesh.text = "-" + damage;
    }
}
