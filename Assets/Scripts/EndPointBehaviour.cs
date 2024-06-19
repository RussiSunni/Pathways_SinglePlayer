using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointBehaviour : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Color _connectedColor = new Color(1, 1, 0, 1);

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.root.name == "StartPoint")
        {
            Debug.Log("you win");
            _sprite.color = _connectedColor;
        }
    }
}
