using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class GravityShift : MonoBehaviour
{
    public GameObject parent;
    private int Rotation = 90;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            parent.transform.Rotate(0, 0, 90);
                
        }

            
    }
}
