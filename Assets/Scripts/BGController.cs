using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BGController : MonoBehaviour
{
    public List<ShapeController> shapes;

    private float tick = 0;
    private float tickMod = 60;
    private Random _random = new Random(DateTime.UtcNow.Millisecond);

    public GameObject shape;
    public bool genShapes = true;
    public int density = 4;

    public bool useMouse = true;
    public GameObject trackedObject;
    public float multiplier = 40;

    public bool useScreen = true;
    public int size;
    public int scaleMultiplier = 1;

    private void Start()
    {
        if (useScreen)
        {
            size = Screen.width;
        }

        if (genShapes)
        {
            for (int i = 0; i < density * 20; i++)
            {
                float x = (float) (_random.NextDouble() * size * 2) - (size);
                float y = (float) (_random.NextDouble() * size * 2) - (size);
                GameObject instantiatedShape = GameObject.Instantiate(shape, this.transform);
                instantiatedShape.transform.position = new Vector3(x + (useScreen?(Screen.width/2):0), y + (useScreen?(Screen.height/2):0));
                instantiatedShape.transform.eulerAngles = new Vector3(0, 0, _random.Next() % 360);
                float scale = (float)(_random.NextDouble()/6) + 0.1f;
                instantiatedShape.transform.localScale -= new Vector3(scale * scaleMultiplier, scale * scaleMultiplier);
                
                shapes.Add(instantiatedShape.GetComponent<ShapeController>());
            }
        }
    }

    void FixedUpdate()
    {
        tick += 1;
        float xVal = (useMouse)?Input.mousePosition.x:trackedObject.transform.position.x;
        float yVal = (useMouse)?Input.mousePosition.y:trackedObject.transform.position.y;
        
        foreach (ShapeController shape in shapes)
        {
            if (tick % tickMod == 0)
            {
                float action = (float)_random.Next() % 3;
                switch (action)
                {
                    case 0:
                        shape.targetRotation += (float)(_random.NextDouble() * 100) - 50;
                        break;
                    case 1:
                        shape.aberration.aberrateX += (float)(_random.NextDouble() * 20) - 10;
                        shape.aberration.aberrateY += (float)(_random.NextDouble() * 20) - 10;
                        break;
                }

            }
            
            shape.targetPosition = shape.initialPosition + new Vector3(-xVal/((shape.transform.localScale.x * multiplier)), -yVal/((shape.transform.localScale.x * multiplier)));
            shape.targetPosition = new Vector3(shape.targetPosition.x, shape.targetPosition.y, 1);
            
            tickMod += (float) (_random.Next() % 10)-5;
            tickMod = Mathf.Min(Mathf.Max(60, tickMod), 240);
        }
    }
}
