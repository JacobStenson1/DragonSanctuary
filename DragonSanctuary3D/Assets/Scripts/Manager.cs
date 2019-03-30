using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    bool isPlacingSomething = true;
    //public Transform smallCagePrefab;
    public UnityEngine.Transform smallcageprefab;

    UnityEngine.GameObject parentOfClicked;
    UnityEngine.Transform topRightBlock;
    UnityEngine.Transform bottomLeftBlock;
    Vector3 middleOfParent;
    float middleX;
    float middleZ;

    public UnityEngine.Transform middleGameObj;

    void Start()
    {
        //
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlacingSomething)
            {
                

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        // If the user clicked on the terrain
                        if (hit.collider.gameObject.tag == "Terrain")
                        {
                            parentOfClicked = hit.collider.gameObject.transform.parent.gameObject;
                            //Debug.DrawRay(ray);

                            if (parentOfClicked.GetComponent<twoXtwoManager>().isSomethingPlacedOn == false)
                            {
                                PlaceSomething();
                            }  
                        }
                    }
                }
            }
        }

    }

    public void TogglePlacing()
    {
        isPlacingSomething = !isPlacingSomething;
    }

    void PlaceSomething()
    {
        //Instantiate(middleGameOnj, parentOfClicked.transform.position, parentOfClicked.transform.rotation);

        topRightBlock = parentOfClicked.transform.GetChild(0);
        bottomLeftBlock = parentOfClicked.transform.GetChild(3);

        middleX = bottomLeftBlock.position.x - topRightBlock.position.x;
        middleZ = bottomLeftBlock.position.z - topRightBlock.position.z;

        middleOfParent = new Vector3(bottomLeftBlock.position.x - (middleX / 2), parentOfClicked.transform.position.y, bottomLeftBlock.position.z - (middleZ / 2));


        Instantiate(smallcageprefab, new Vector3(bottomLeftBlock.position.x - (middleX / 2), parentOfClicked.transform.position.y, bottomLeftBlock.position.z - (middleZ / 2)), new Quaternion(0.0f,0.0f,0.0f,0.0f));

        parentOfClicked.GetComponent<twoXtwoManager>().isSomethingPlacedOn = true;
    }
}
