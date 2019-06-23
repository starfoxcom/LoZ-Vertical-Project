using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
  public int damage = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Link")
    {
      Link_Controller link_cntrl = collision.gameObject.GetComponent<Link_Controller>();
      link_cntrl.Damage(damage, gameObject.transform.position);
    }

    return;
  }
}
