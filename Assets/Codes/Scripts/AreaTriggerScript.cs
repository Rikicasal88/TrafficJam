using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTriggerScript : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag.Equals("Enemy"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
