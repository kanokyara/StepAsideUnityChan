using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    private GameObject myCameraController;

    // Start is called before the first frame update
    void Start()
    {
        this.myCameraController = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.myCameraController.transform.position.z> this.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
