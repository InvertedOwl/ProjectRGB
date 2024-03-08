using System;
using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel(startLevel);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update() {
        text.text = "Level: " + (currentLevel-2);
        text2.text = text.text;
    }

    public void LoadLevel(int level)
    {
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
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded!");
        if (scene.buildIndex != 0 && scene.buildIndex != 1) {
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
        if (open)
        StartCoroutine(LoadLevelWait(currentLevel));
    }

    public IEnumerator LoadLevelWait(int level)
    {
        open = false;
        yield return new WaitForSeconds(1.5f);
        LoadLevel(level);
        open = true;
    }
}
