using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Object ExperienceOne;
    public Object ExperienceTwo;

    // void Start()
    // {
    //     Debug.Log(ExperienceOne);
    // }
    public void StartApp()
    {
        SceneManager.LoadScene(ExperienceOne.name);
    }

    public void MoveToExperienceTwo()
    {
        SceneManager.LoadScene(ExperienceTwo.name);
    }
    //[SerializeField] Object scene;

    // private void OnTriggerEnter(Collider other) 
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         SceneManager.LoadScene(scene.name);
    //     }
    // }
}
