using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRotate : MonoBehaviour
{
    private void Update() {
        // transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);

        Quaternion rot = Quaternion.AngleAxis(90 * Time.deltaTime, Vector3.up);
        transform.rotation = rot * transform.rotation;
    }
}
