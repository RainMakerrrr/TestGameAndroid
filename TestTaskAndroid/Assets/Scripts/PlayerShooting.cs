using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _newBall;
    
    private Vector3 _scalingVector = new Vector3(0.04f, 0.04f, 0.04f);
    private Vector3 _currentScale;
    private Vector3 _newBallScale;
    private void Start()
    {
        _currentScale = transform.localScale;
    }

    private void Update()
    {


        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Stationary)
            {
                _currentScale -= _scalingVector;

            }
            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    _newBallScale = transform.localScale - _currentScale;
                    transform.localScale = _currentScale;
                    _newBall.transform.localScale = _newBallScale + new Vector3(1.5f,1.5f,1.5f); // для упрощения геймплея

                    GameObject newBall =  Instantiate(_newBall, transform.position + new Vector3(0.2f,0.2f,0.2f), Quaternion.identity) as GameObject;

                    newBall.GetComponent<Rigidbody>().AddForce(hit.point * 5f, ForceMode.Impulse);
                }  
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            Debug.Log("You win");
            _text.enabled = true;
        }
    }

}
