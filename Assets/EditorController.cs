using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;

public class EditorController : MonoBehaviour
{
    public GameObject selected;
    public bool dragging;
    public Camera cam;
    public GameObject selector;
    private Vector3 initialMouse;
    private Vector3 initialScale;
    private Vector3 relativeMouse;
    private bool draggingSelector;
    public GameObject edit;
    
    public ToggleCheckbox redCheck;
    public ToggleCheckbox greenCheck;
    public ToggleCheckbox blueCheck;
    public ToggleCheckbox gravityCheck;

    public String fileBeingEdited;

    public DynamicSceneCreator dsc;
    public void Start()
    {
        String documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        String dirPath = Path.Combine(documents, "ProjectRGB_data");
        
        
        fileBeingEdited = PlayerPrefs.GetString("editing");
        Debug.Log(fileBeingEdited);

        dsc.LoadLevel(fileBeingEdited);
    }

    void Update()
    {
        bool mouse0 = Input.GetMouseButtonDown(0);
        bool mouse1 = Input.GetMouseButtonDown(1);
        bool mouse2 = Input.GetMouseButtonDown(2);

        cam.orthographicSize = Mathf.Max(2, cam.orthographicSize - Input.mouseScrollDelta.y);
        
        
        if ((mouse0 || mouse1) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) {
                if (mouse0 || mouse1)
                {
                    initialMouse = cam.ScreenToWorldPoint(Input.mousePosition);

                    if (hit.collider.gameObject == selector)
                    {
                        initialScale = selected.transform.localScale;
                        draggingSelector = true;
                    }
                    else
                    {
                        selected = hit.collider.gameObject.GetComponentInParent<Component2D>().gameObject;
                        RGBController cont = selected.GetComponent<RGBController>();
                        if (cont)
                        {
                            redCheck.toggle.isOn = cont.red.activeInHierarchy;
                            blueCheck.toggle.isOn = cont.blue.activeInHierarchy;
                            greenCheck.toggle.isOn = cont.green.activeInHierarchy;
                            gravityCheck.toggle.isOn = selected.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Static;                            
                        }

                        if (mouse0)
                        {
                            relativeMouse = selected.transform.position - mousePos;
                            dragging = true;
                        }
                    }                    
                }

                if (mouse1)
                {
                    edit.gameObject.SetActive(true);
                    edit.gameObject.transform.position = Input.mousePosition;

                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            draggingSelector = false;
        }

        if (dragging)
        {
            Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition) + relativeMouse;
            selected.transform.position = new Vector3(Mathf.Floor((pos.x + 0.5f) * 2) / 2.0f, Mathf.Floor((pos.y + 0.5f) * 2) / 2.0f, 0);
        }

        if (draggingSelector)
        {
            Vector3 newScale = ((cam.ScreenToWorldPoint(Input.mousePosition) - initialMouse) * 2) + initialScale;
            selected.transform.localScale = new Vector3(Mathf.Floor((newScale.x + 0.5f) * 1) / 1.0f, Mathf.Floor((newScale.y + 0.5f) * 1) / 1.0f);
        }

        if (!selected)
        {
            selector.SetActive(false);
        }
        else
        {
            if (!selected.activeSelf)
            {
                selector.SetActive(false);
            }
            else
            {
                selector.SetActive(true);
                selector.transform.position = selected.transform.TransformPoint(new Vector3(0.5f, 0.5f, 0));
            }
        }
    }

    public void SaveLevel()
    {
        String documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        String directory = Path.Combine(documents, "ProjectRGB_data");
        String filePath = "";
        if (fileBeingEdited == null)
        {
            filePath = Path.Combine(directory, "level_" + Mathf.Floor(UnityEngine.Random.Range(1000.0f, 9999.0f)) + ".json");
        }
        else
        {
            filePath = fileBeingEdited;
        }
        
        RootObject rootObject = new RootObject();
        rootObject.objects = new List<ObjectData>();
        foreach (Component2D component in GameObject.FindObjectsOfType<Component2D>())
        {
            ObjectData data = new ObjectData();
            if (component.GetComponent<RGBController>())
            {
                data.color = (component.GetComponent<RGBController>().red.activeInHierarchy ? "r" : "") +
                             (component.GetComponent<RGBController>().green.activeInHierarchy ? "g" : "") +
                             (component.GetComponent<RGBController>().blue.activeInHierarchy ? "b" : "");                
            }

            if (component.GetComponent<Rigidbody2D>())
            {
                data.physics = component.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Kinematic
                    ? "static"
                    : "dynamic";                
            }

            data.pos = new Position();
            data.pos.x = component.transform.position.x;
            data.pos.y = component.transform.position.y;
            data.size = new Size();
            data.size.x = component.transform.localScale.x;
            data.size.y = component.transform.localScale.y;
            data.type = component.type;
            rootObject.objects.Add(data);
        }
        Debug.Log(JsonUtility.ToJson(rootObject));
        
        File.WriteAllText(filePath, JsonUtility.ToJson(rootObject));
    }

    public void ToggleRed(bool val)
    {
        selected.GetComponent<RGBController>().red.SetActive(val);
    }
    public void ToggleGreen(bool val)
    {
        selected.GetComponent<RGBController>().green.SetActive(val);
    }
    public void ToggleBlue(bool val)
    {
        selected.GetComponent<RGBController>().blue.SetActive(val);
    }

    public void ToggleGravity(bool val)
    {
        if (val)
        {
            selected.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        else
        {
            selected.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }

    public void Delete()
    {
        selected.SetActive(false);
    }
}
