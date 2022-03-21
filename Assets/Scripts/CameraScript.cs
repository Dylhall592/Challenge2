using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(target.position.x, target.position.y, this.transform.position.z);
    }
}
