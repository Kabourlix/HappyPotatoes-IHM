using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoneyValve : MonoBehaviour
{

    public GameObject target;
    public float speed = 0.01f;
    //Quaternion m_MyQuaternion;
    public Vector3 targetPosition;
    public float maxopening;
    public float maxclosing;

    public bool opening;

    // Start is called before the first frame update
    void Start()
    {
        maxclosing = 0;
        maxopening = 90;
        opening = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (maxclosing != 0)
        {
            opening = true;
        }
    }

    void OnSelectEnter()
    {
        targetPosition = target.transform.position;

        if (Vector3.Distance(transform.eulerAngles, targetPosition) > 0.01f && transform.rotation.y<maxopening && maxclosing < transform.rotation.y)
        {
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, targetPosition, Time.time * speed);
        }
    }
}
