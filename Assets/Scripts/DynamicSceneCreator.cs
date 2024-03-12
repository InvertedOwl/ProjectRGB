using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.IO;

namespace DefaultNamespace
{
    public class DynamicSceneCreator: MonoBehaviour
    {
        public GameObject square;
        public GameObject spawn;
        public GameObject death;
        public GameObject gate;
        public GameObject door;
        public GameObject redFilter;
        public GameObject greenFilter;
        public GameObject blueFilter;
        public GameObject aberrationController;
        public bool spawnStatic;

        public Scene LoadLevel(String level)
        {
            Scene s = SceneManager.CreateScene(level);
            String data = "{}";
            try { data = File.ReadAllText(level); } catch (Exception ignored) { }
            
            RootObject rootObject = JsonUtility.FromJson<RootObject>(data);
            GameObject aberration = Instantiate(aberrationController);
            SceneManager.MoveGameObjectToScene(aberration, s); // Move object to the new scene

            Debug.Log(rootObject);
            foreach (ObjectData objectData in rootObject.objects)
            {
                GameObject spawned = null;

                if (objectData.type == "block")
                {
                    
                    spawned = GameObject.Instantiate(square);
                    if (spawned.GetComponent<RGBController>())
                    {
                        if (!objectData.color.Contains("r"))
                        {
                            spawned.GetComponent<RGBController>().red.gameObject.SetActive(false);
                        }
                        if (!objectData.color.Contains("g"))
                        {
                            spawned.GetComponent<RGBController>().green.gameObject.SetActive(false);
                        }
                        if (!objectData.color.Contains("b"))
                        {
                            spawned.GetComponent<RGBController>().blue.gameObject.SetActive(false);
                        }                        
                    }
                }

                if (objectData.type == "spawn")
                {                    
                    spawned = GameObject.Instantiate(spawn);
                }
                if (objectData.type == "death")
                {                    
                    spawned = GameObject.Instantiate(death);
                }
                if (objectData.type == "gate")
                {                    
                    spawned = GameObject.Instantiate(gate);
                    spawned.GetComponent<GateController>().controller = aberration.GetComponent<AberrationController>();
                }
                if (objectData.type == "door")
                {                    
                    spawned = GameObject.Instantiate(door);
                }
                
                if (objectData.type == "redfilter")
                {                    
                    spawned = GameObject.Instantiate(redFilter);
                }
                if (objectData.type == "greenfilter")
                {                    
                    spawned = GameObject.Instantiate(greenFilter);
                }
                if (objectData.type == "bluefilter")
                {                    
                    spawned = GameObject.Instantiate(blueFilter);
                }
                    
                spawned.transform.position = new Vector3(objectData.pos.x, objectData.pos.y);
                spawned.transform.localScale = new Vector3(objectData.size.x, objectData.size.y);
                

                if (spawned.GetComponent<Rigidbody2D>())
                {
                    RigidbodyType2D type;
                    if (objectData.physics == "static")
                    {
                        type = RigidbodyType2D.Kinematic;
                    } else
                    {
                        if (spawnStatic)
                        {
                            type = RigidbodyType2D.Static;
                        }
                        else
                        {
                            type = RigidbodyType2D.Dynamic;
                        }
                    }
                    spawned.GetComponent<Rigidbody2D>().bodyType = type; 
                }
                SceneManager.MoveGameObjectToScene(spawned, s); // Move object to the new scene
            }

            return s;
        }
    }
    
    [System.Serializable]
    public class Position
    {
        public float x;
        public float y;
    }

    [System.Serializable]
    public class Size
    {
        public float x;
        public float y;
    }

    [System.Serializable]
    public class ObjectData
    {
        public string type;
        public string color;
        public Position pos;
        public string physics;
        public Size size;
    }

    [System.Serializable]
    public class RootObject
    {
        public List<ObjectData> objects;
    }
}