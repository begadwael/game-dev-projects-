using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float speedGainPerSecond = 0.2f;
    [SerializeField] float turnSpeed = 200f;

    int steerValue;

    void Update()
    {
        speed += speedGainPerSecond * Time.deltaTime;

        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Obstacle")) 
        {
            SceneManager.LoadScene(0); //load Scene_MainMenu
        }
    }

    public void Steer(int value)
    {
        steerValue = value;
    }
}
