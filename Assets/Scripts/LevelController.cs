using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int startLevel = 1;
    public int currentLevel = -1;
    public GameObject circle;
    public bool open = true;
    public GameObject player;
    public TMP_Text text;    
    public TMP_Text text2;
    public DynamicSceneCreator sceneCreator;
    public Scene dynamicScene;
    
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (PlayerPrefs.HasKey("level") && PlayerPrefs.GetString("level") != "")
        {
            // dynamicScene = sceneCreator.LoadLevel(PlayerPrefs.GetString("level"));
            LoadDynamicLevel(PlayerPrefs.GetString("level"));
            return;
        }
        
        if (PlayerPrefs.HasKey("furthest")) {
            LoadLatestLevel();
        } else {
            LoadLevel(startLevel);
        }
    }

    private void Update() {
        text.text = "Level: " + (currentLevel-2);
        text2.text = text.text;
    }

    public void LoadLevel(int level)
    {
        if (level == -1)
        {
            SceneManager.LoadScene(0);
            return;
        }
        
        if (currentLevel != -1)
        {
            SceneManager.UnloadScene(currentLevel);
        }

        SceneManager.LoadScene(level, LoadSceneMode.Additive);
        currentLevel = level;
        player.transform.GetChild(0).GetChild(0).gameObject.GetComponent<LerpScale>().targetScale = 1;
        player.transform.GetChild(0).GetChild(1).gameObject.GetComponent<LerpScale>().targetScale = 1;
        player.transform.GetChild(0).GetChild(2).gameObject.GetComponent<LerpScale>().targetScale = 1;
        player.transform.GetChild(0).GetComponent<Controller>().controllsEnabled = true;
        if (PlayerPrefs.HasKey("latest")) {
            if (level > PlayerPrefs.GetInt("furthest")) {
                PlayerPrefs.SetInt("furthest", level);
            }
        } else {
                PlayerPrefs.SetInt("furthest", level);
        }
    }
    
    public void LoadDynamicLevel(String level)
    {
        Debug.Log("Loading dynamic level 1");
        if (dynamicScene != null)
        {
            Debug.Log("Loading dynamic level 2");
            try
            {
                SceneManager.UnloadScene(dynamicScene);
            }
            catch (Exception ignored)
            {
                
            }
        }
        Debug.Log("Loading dynamic level 3");
        dynamicScene = sceneCreator.LoadLevel(level);
        player.transform.GetChild(0).GetChild(0).gameObject.GetComponent<LerpScale>().targetScale = 1;
        player.transform.GetChild(0).GetChild(1).gameObject.GetComponent<LerpScale>().targetScale = 1;
        player.transform.GetChild(0).GetChild(2).gameObject.GetComponent<LerpScale>().targetScale = 1;
        player.transform.GetChild(0).GetComponent<Controller>().controllsEnabled = true;
        Debug.Log("Loading dynamic level 4");

        Vector3 target = GameObject.FindGameObjectWithTag("Spawn").transform.position;
        Debug.Log("Loading dynamic level 5");
        Debug.Log("Spawn Target " + target);
        if (player == null)
        {
            Debug.Log("Loading dynamic level 6");
            player = GameObject.FindGameObjectWithTag("PlayerCamera");
        }
        Debug.Log("Loading dynamic level 7");
        player.transform.position = target;
        player.transform.GetChild(0).transform.position = target;
        player.transform.GetChild(1).transform.position = target;
        player.transform.GetChild(1).GetComponent<FollowObject>().SetToPos(target);
        Debug.Log("Loading dynamic level 8");

    }


    public void LoadLatestLevel() {
        LoadLevel(PlayerPrefs.GetInt("furthest"));
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded!" + scene.buildIndex);
        if ((scene.buildIndex != 0 && scene.buildIndex != 1) && !(PlayerPrefs.HasKey("level") && PlayerPrefs.GetString("level") != "")) {
            Debug.Log("Bruh");
            Vector3 target = GameObject.FindGameObjectWithTag("Spawn").transform.position;
            Debug.Log(target);
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("PlayerCamera");
            }
            player.transform.position = target;
            player.transform.GetChild(0).transform.position = target;
            player.transform.GetChild(1).transform.position = target;
            player.transform.GetChild(1).GetComponent<FollowObject>().SetToPos(target);
        }
    }

    private void FixedUpdate()
    {
        if (open)
        {
            circle.transform.localScale = new Vector3(Mathf.Min(circle.transform.localScale.x + 0.2f, 10),
                Mathf.Min(circle.transform.localScale.y + 0.2f, 10), 1);
        }
        else
        {
            circle.transform.localScale = new Vector3(Mathf.Max(circle.transform.localScale.x - 0.2f, 0),
                Mathf.Max(circle.transform.localScale.y - 0.2f, 0), 1);
        }
    }

    public void ReloadLevel()
    {
        if (open && !(PlayerPrefs.HasKey("level") && PlayerPrefs.GetString("level") != ""))
        {
            StartCoroutine(LoadLevelWait(currentLevel));
        } else if (open)
        {
            StartCoroutine(LoadDynamicLevelWait(PlayerPrefs.GetString("level")));
        }
    }

    public IEnumerator LoadLevelWait(int level)
    {
        open = false;
        yield return new WaitForSeconds(1.5f);
        LoadLevel(level);
        open = true;
    }
    
    public IEnumerator LoadDynamicLevelWait(String level)
    {
        open = false;
        yield return new WaitForSeconds(1.5f);
        LoadDynamicLevel(level);
        open = true;
    }
}
