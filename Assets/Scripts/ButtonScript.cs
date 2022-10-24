using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] GameObject clickSound;

    public void PlayClick() {
        GameObject soundObject = Instantiate(clickSound, transform.position, Quaternion.identity);
        soundObject.transform.parent = gameObject.transform.parent.transform.parent;
    }
}
