using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI _text;
    private Rigidbody _rigidbody;
    private Joystick _joystick;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _joystick = FindObjectOfType<Joystick>();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * 10f,
                                          _rigidbody.velocity.y,
                                          _joystick.Vertical * 10f);   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Your Lose");
            _text.enabled = true;
            this.enabled = false;
            gameObject.GetComponent<PlayerShooting>().enabled = false;
        }
    }
}
