using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationSpeedIOS;

    private void Update()
    {
        #if UNITY_EDITOR
                if (Input.GetMouseButton(0))
                {
                    float mouseX = Input.GetAxisRaw("Mouse X");
                    transform.Rotate(0, -mouseX * rotationSpeed * Time.deltaTime, 0);
                }
#elif UNITY_IOS || UNITY_ANDROID
                if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    float xDeltaPos = Input.GetTouch(0).deltaPosition.x;
                    transform.Rotate(0, -xDeltaPos * rotationSpeedIOS * Time.deltaTime, 0);
                }
#endif
    }
}