using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotation : MonoBehaviour, IDragHandler
{
    public Transform vaseTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        //vaseTransform.Rotate(180f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        vaseTransform.eulerAngles += new Vector3(-eventData.delta.y, -eventData.delta.x);
    }
}
