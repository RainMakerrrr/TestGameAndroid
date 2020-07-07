using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("ShootingBall"))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            Destroy(other.gameObject);
            StartCoroutine(DestroyObstacleWithDelay());
        }
    }

    private IEnumerator DestroyObstacleWithDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
