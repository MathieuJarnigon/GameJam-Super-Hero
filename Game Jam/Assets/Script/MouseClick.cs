using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    void Update()
    {
        Cursor.visible = false;
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursorPos;
    }

    private GameObject FindChillGameObjectByName(GameObject topParentGameObject, string name)
    {
        for (int i = 0; i < topParentGameObject.transform.childCount; i++)
        {
            if (topParentGameObject.transform.GetChild(i).name == name)
            {
                return topParentGameObject.transform.GetChild(i).gameObject;
            }

            GameObject tmp = FindChillGameObjectByName(topParentGameObject.transform.GetChild(i).gameObject, name);
            
            if (tmp != null)
            {
                return tmp;
            }
        }

        return null;
    }
}
