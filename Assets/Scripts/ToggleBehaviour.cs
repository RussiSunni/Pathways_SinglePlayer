using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBehaviour : MonoBehaviour
{
    private Collider2D _startPoint;
    private SpriteRenderer _sprite;
    private Color _connectedColor = new Color(1, 1, 0, 1);
    private Color _disconnectedColor = new Color(1, 1, 1, 1);
    private Transform _originalParent; 

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _startPoint = GameObject.FindWithTag("StartPoint").GetComponent<CircleCollider2D>();
        _originalParent = transform.parent;
    }

    private void OnMouseOver()
    {
        // Rotate toggle on mouse click.
        if (Input.GetMouseButtonDown(0))
        {
            int numChildren = transform.childCount;

            for (int i = 0; i < numChildren ; i++)
            {
               // Debug.Log(transform.GetChild(i).name);
                transform.GetChild(i).parent = _originalParent;
            }

            transform.parent = _originalParent;
            _sprite.color = _disconnectedColor;

            transform.eulerAngles = Vector3.forward * (transform.eulerAngles.z - 90);            
        }      
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "StartPoint")
        {
            _sprite.color = _connectedColor;
            gameObject.transform.parent = _startPoint.transform;
        }
        else if (collision.transform.root.name == "StartPoint")
        {
            _sprite.color = _connectedColor;
            gameObject.transform.parent = collision.transform;
        }
        else
        {
            _sprite.color = _disconnectedColor;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _sprite.color = _disconnectedColor;
    }
}
