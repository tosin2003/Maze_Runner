using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectManager : MonoBehaviour
{

    public GameObject[] keys,Health;
    public GameObject LevelComplete,LevelFail;
    int keyCount = 0;
    int HealthCount = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag=="Key")
        {
            keys[keyCount].SetActive(true);
            keyCount++;
            col.gameObject.SetActive(false);
            Debug.Log("KEY");
        }

        if (col.tag == "Check")
        {
            if (keyCount==3)
            {
                LevelComplete.SetActive(true);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Gate")
        {
            HealthCount--;
            if (HealthCount==0)
            {

                Health[0].SetActive(false);
                LevelFail.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Health[HealthCount].SetActive(false);
            }
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }
}
