using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGranade : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosion;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<TurretLookAndFire>() != null)
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.GetComponent<WaypointPatrol>() != null)
        {
            Debug.Log("Победа");
            Destroy(collision.gameObject);
            Application.Quit();
        }
        Instantiate(_explosion, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
