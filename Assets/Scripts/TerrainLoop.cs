using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TerrainLoop : MonoBehaviour
{
    public GameObject spriteShapeGameObject;

    private SpriteShapeController spriteShapeController;

    public float offsetRight = 0;

    private float x1;
    private float x2;

    public float width;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        spriteShapeController = spriteShapeGameObject.GetComponent<SpriteShapeController>();

        updateEdgesCoordinates();

        height = Camera.main.orthographicSize * 2;
        width = Camera.main.aspect * height;

        //spriteShapeController.spline.SetPosition(0, new Vector3(-100, 0));

        //spriteShapeController.spline.SetRightTangent(0, new Vector3(1, 3));


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position.x);

        if (transform.position.x + (width / 2) > (x2 + offsetRight ))
        {
            generateNextNodes();
            updateEdgesCoordinates();
        }

        if(transform.position.x > (x1 + 100))
        {
            removeLeftNodes();
            updateEdgesCoordinates();
        }
    }

    void generateNextNodes()
    {
        int length = spriteShapeController.spline.GetPointCount();

        float newY = Random.RandomRange(1.1f, 2.0f);

        float newX = x2 + 10;

        spriteShapeController.spline.InsertPointAt(length, new Vector3(newX, newY, 0));

        //spriteShapeController.spline.SetTangentMode(length, ShapeTangentMode.Continuous);

        //spriteShapeController.spline.SetLeftTangent(length, new Vector3(newX - 1, newY, 0));

        //spriteShapeController.spline.SetRightTangent(length, new Vector3(newX + 1, newY, 0));

    }

    void removeLeftNodes()
    {
        //
    }

    void updateEdgesCoordinates()
    {
        Vector3 leftPosition = spriteShapeController.spline.GetPosition(0);
        x1 = leftPosition.x;

        int length = spriteShapeController.spline.GetPointCount();
        Vector3 rightPosition = spriteShapeController.spline.GetPosition(length - 1);
        x2 = rightPosition.x;

    }
}
