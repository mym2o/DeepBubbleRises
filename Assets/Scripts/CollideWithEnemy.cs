using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections;

public class CollideWithEnemy : MonoBehaviour
{
    public BackgroundMusic backgroundMusic;
    public GameObject particleSystem;

    private GameObject playerToDestroy;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player") && other.GetComponent<SphereCollider>() != null)
        {
            playerToDestroy = other.gameObject.transform.parent.gameObject;
            GameObject instantiated = GameObject.Instantiate(particleSystem, playerToDestroy.transform);
            instantiated.transform.SetParent(null);

            playerToDestroy.SetActive(false);
        }
    }
}