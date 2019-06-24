using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zelda_Behaviour : MonoBehaviour
{
    public GameObject m_Target;
    private Rigidbody2D m_rb;
    private Link_Movement m_Movement;
    private Queue<Vector3> q_Positions;
    private Animator m_animator;
    Vector3 m_Direction;

    /*
     * Codigo que agarra la posicion y direccion de Link
     */

    void SavingTransform()
    {
        q_Positions.Enqueue(m_Target.transform.position);
    }

    /*
     * Codigo de busqueda de posición
     */

    Vector3 Seek()
    {
        Vector3 newTransform = new Vector3(q_Positions.Peek().x - transform.position.x, q_Positions.Peek().y - transform.position.y);
        newTransform.Normalize();
        return newTransform;
    }

    // Start is called before the first frame update
    void Start()
    {
        q_Positions = new Queue<Vector3>();

        m_rb = m_Target.GetComponent<Rigidbody2D>();
        m_animator = gameObject.GetComponent<Animator>();
    }

  // Update is called once per frame
  void Update()
  {
    if (m_rb.velocity != Vector2.zero)
    {
      SavingTransform();
      m_Direction = Seek();
      Vector3 newPosition = transform.position + m_Direction * .0155f;
      transform.position = newPosition;
      if ((q_Positions.Peek() - transform.position).magnitude < 0.1f)
      {
        q_Positions.Dequeue();
      }
    }

    Vector3 newTransform = new Vector3(q_Positions.Peek().x - transform.position.x, q_Positions.Peek().y - transform.position.y);
    newTransform.Normalize();
    m_animator.SetBool("Up", newTransform.y > 0.0);
    m_animator.SetBool("Down", newTransform.y < 0.0);
    m_animator.SetBool("Left", newTransform.x < 0.0);
    m_animator.SetBool("Right", newTransform.x > 0.0);
  }
}
