using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Item_Scripts
{
  class ItemBomerang : ItemBasePlayerUsable
  {
    //! where to item is going 
    Vector2 m_Destination;
    //! the movement that takes it to it's location 
    Vector2 m_Velocity;
    //! this represents where the boomerang is 
    Vector2 m_Position;
    //! yse 
    Vector2 m_PositionOriginal;
    //! to know if the boomerang should go to it's destination or back to link 
    public static bool isFlyingAway;

    public static bool IsThrown = false;
    //! the speed 
    float m_speed = 4.0f;
    //! how far the boomerang should go s
    float m_MaxDistance = 5.0f;
    // this is just temporary will change this with the class that represents link later
    public Link_Data m_link;
    // first use my test class before using the real link class 
    // public Link_Movement test;

    public override Vector2 ItemAcction(Vector2 direction, Vector2 Position)
    {
      IsThrown = true;
      this.transform.position = Position;
      m_PositionOriginal = Position;

      m_Destination = Position + (direction * m_MaxDistance);
      m_Velocity = direction * m_speed;
      isFlyingAway = true;

      return m_Destination;
    }// end function

    // Start function
    private void Start()
    {
      IsThrown = false;
      isFlyingAway = false;
      //--------------------------
      GameObject Temp = GameObject.FindWithTag("Link");
      m_link = Temp.GetComponent<Link_Data>();
    }// end function 
    /// <summary>
    /// this dictates what happens with the boomerang 
    /// </summary>
    private void Update()
    {
      if (IsThrown)
      {
        Vector2 PlayerLocation = m_link.transform.position;

        if (isFlyingAway)
        {
          //moving to the Destination
          m_Position = m_Position + m_Velocity * Time.deltaTime;
          // check the distance 
          Debug.Log("Magnitude :" + (PlayerLocation - m_Position).magnitude);

          if ((m_PositionOriginal - m_Position).magnitude > m_MaxDistance)
          {
            Debug.Log("Very close");
            isFlyingAway = false;
          }
        }
        else if (isFlyingAway == false)
        {
          m_Velocity = (PlayerLocation - m_Position).normalized;
          m_Position += m_Velocity * m_speed * 2 * Time.deltaTime;
          if (IsThrown && (PlayerLocation - m_Position).magnitude < .3f)
          {
            IsThrown = false;
          }
        }
        this.transform.position = new Vector3(m_Position.x, m_Position.y, 0);

      }

    }// end function 

  }// end class 

}
