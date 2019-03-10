using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicator : MonoBehaviour
{
    [SerializeField] Transform target;
    public float HideDist;
    


    // Update is called once per frame
    void Update()
    {
        var dir = target.position - transform.position;

        if (dir.magnitude < HideDist) {
           SetChild(false);
        }
        else {
            SetChild(true);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
    }

    private void SetChild(bool value) {
        foreach (Transform c in transform) {
            c.gameObject.SetActive(value);
        }
    }
}
