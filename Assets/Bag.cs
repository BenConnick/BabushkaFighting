using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bag : MonoBehaviour {
    private Rigidbody2D rbody;
    private Action<float> hitCallback;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag != "Player") return;
        if (hitCallback != null) hitCallback.Invoke(rbody.velocity.magnitude);
    }

    public void SetCallback(Action<float> callback)
    {
        this.hitCallback = callback;
    }

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }
}
