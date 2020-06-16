using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public GameObject target = null;
    public float distance = 0.0f;
    public float height = 0.0f;

    Vector3 _target_pos, _cam_pos;

    // Start is called before the first frame update
    private void Start() {

        // Posicion del target
        Vector3 target_position = target.transform.position;
        Vector3 camera_position = target_position;

        // Modifica la posicion de la camara
        camera_position.z -= distance;
        camera_position.y += height;

        // Valores iniciales
        _target_pos = target_position;
        _cam_pos = camera_position;

    }

    private void Update() {

        // Posicion del target
        Vector3 target_position = target.transform.position;
        Vector3 camera_position = target_position;

        // Modifica la posicion de la camara
        camera_position.z -= distance;
        camera_position.y += height;

        // Lerp
        _target_pos = Vector3.Lerp(_target_pos, target_position, (Time.smoothDeltaTime * 300.0f));
        _cam_pos = Vector3.Lerp(_cam_pos, camera_position, (Time.smoothDeltaTime * 300.0f));

    }

    // Update is called once per frame
    private void LateUpdate() {

        // Coloca la camara
        this.transform.position = _cam_pos;
        this.transform.LookAt(_target_pos);

    }

}
