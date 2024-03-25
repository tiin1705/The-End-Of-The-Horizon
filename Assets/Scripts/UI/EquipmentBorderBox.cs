using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentBorderBox : MonoBehaviour
{
    private Image parentImage;

    private void Start()
    {
        parentImage = transform.parent.GetComponent<Image>();

    }

    private void Update()
    {
        if (!parentImage.enabled)
        {
            gameObject.SetActive(true);
            Debug.Log("true");
        }
        else
        {
            gameObject.SetActive(false);
            Debug.Log("false");

        }
        
    }
}
