using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColissionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.transform.tag)
        {
            case "Finish":
                Debug.Log("You finished a level!");
                break;
            case "Obstacle":
                Debug.Log("You hit an obstacle! Cringe bro");
                break;
            case "Friendly":
                Debug.Log("Nothing happens");
                break;
            default:
                Debug.Log("You hit into something");
                break;
        }
    }
}
