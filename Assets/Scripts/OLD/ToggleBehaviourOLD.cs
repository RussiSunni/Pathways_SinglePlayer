using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBehaviourOLD : MonoBehaviour
{
    private Collider2D _startPoint;
    private Collider2D _thisCollider;
    private SpriteRenderer _sprite;
    private Color _connectedColor = new Color(1, 1, 0, 1);
    private Color _disconnectedColor = new Color(1, 1, 1, 1);
    private bool _isConnected;


    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _thisCollider = GetComponent<BoxCollider2D>();
        _startPoint = GameObject.FindWithTag("StartPoint").GetComponent<CircleCollider2D>();
    }

    private void OnMouseOver()
    {
        // Rotate toggle on mouse click.
        if (Input.GetMouseButtonDown(0))
        {
            transform.eulerAngles = Vector3.forward * (transform.eulerAngles.z - 90);

            //_isConnected = false;
            //_sprite.color = _disconnectedColor;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        // If disconnected.
        //_isConnected = false;
        //_sprite.color = _disconnectedColor;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "StartPoint")
        {
            _isConnected = true;
            _sprite.color = _connectedColor;
        }

        //Debug.Log(collision.gameObject.name + " : " + gameObject.name);

        List<ContactPoint2D> contacts = new List<ContactPoint2D>();
        int numContacts = collision.GetContacts(contacts);
   

        foreach (ContactPoint2D contact in contacts)
        {
            if (collision.gameObject.GetComponent<ToggleBehaviourOLD>() != null)
            {
                if (collision.gameObject.GetComponent<ToggleBehaviourOLD>()._isConnected == true)
                {
                    _isConnected = true;
                    _sprite.color = _connectedColor;
                }
            }
        }
    }
}
