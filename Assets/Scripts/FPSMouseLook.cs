using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMouseLook : MonoBehaviour
{
    //public enum RotationAxes { MouseXandY = 0, MouseX = 1, MouseY = 2};
    //public RotationAxes axes = RotationAxes.MouseXandY;
    [SerializeField]
    public float sensitivity = 5;
    [SerializeField]
    public float smoothing = 2.0f;

    public GameObject character;

    private Vector2 look;

    private Vector2 smoothv;

    // Start is called before the first frame update
    void Start()
    {
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var delta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        delta = Vector2.Scale(delta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothv.x = Mathf.Lerp(smoothv.x, delta.x, 1f / smoothing);
        smoothv.y = Mathf.Lerp(smoothv.y, delta.y, 1f / smoothing);

        look += smoothv;


        transform.localRotation = Quaternion.AngleAxis(-look.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(look.x, character.transform.up);
    }
}
