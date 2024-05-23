using UnityEngine;
[RequireComponent (typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 500f;

    private Rigidbody _rb;
    private Vector3 _move;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        _move = new Vector3(x, 0, z);

        Quaternion rot = transform.rotation;

        Quaternion newRot = Quaternion.LookRotation(Vector3.Normalize(_move));

        transform.rotation = Quaternion.Lerp(rot, newRot, Time.deltaTime * 10);

    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        Vector3 move = new Vector3(_move.x * speed * Time.fixedDeltaTime, _rb.velocity.y, _move.z * speed * Time.fixedDeltaTime);
        _rb.velocity = move;
    }
}
