using UnityEngine;

public class PlayerRotationToMouse : MonoBehaviour {

    public float rotationSpeed = 5f;
    public Vector2 direction;
    public Quaternion rotation;
    public float angle;
	
	// Update is called once per frame
	private void Update ()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
