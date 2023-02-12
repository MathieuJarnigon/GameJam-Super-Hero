using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlaceParent : MonoBehaviour
{
    void OnMouseDown()
    {
        Destroy(this.gameObject);
    }
}
