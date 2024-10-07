using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOutOfBounds : MonoBehaviour
{   void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
