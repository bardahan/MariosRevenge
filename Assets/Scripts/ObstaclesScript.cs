using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesScript : MonoBehaviour
{
    public Transform[] needlePoints;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InitializeNewNeedle(Transform start, Transform end)
    {
        GameObject newObject = Instantiate(prefab, start.position, Quaternion.identity);
        NeedleScript newObjectScript = newObject.GetComponent<NeedleScript>();
        newObjectScript.start = start.transform;
        newObjectScript.end = end.transform;
        newObjectScript.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        float num = Random.RandomRange(0, 60);

        if (num == 0)
        {
            InitializeNewNeedle(needlePoints[0].transform, needlePoints[2]);
        }
        if (num == 1)
        {
            InitializeNewNeedle(needlePoints[2].transform, needlePoints[0]);
        }
        if (num == 2)
        {
            InitializeNewNeedle(needlePoints[1].transform, needlePoints[3]);
        }
        if (num == 3)
        {
            InitializeNewNeedle(needlePoints[3].transform, needlePoints[1]);
        }
    }
}
