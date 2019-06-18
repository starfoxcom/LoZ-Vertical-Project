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
    //! to know if the boomerang should go to it's destination or back to link 
    public static bool isFlyingAway;
    //! the speed 
    float m_speed = 1.0f;
    //! how far the boomerang should go s
    float m_MaxDistance = 10.0f;
    // this is just temporary will change this with the class that represents link later
    public TempPlayer m_tempPlayer;
    // first use my test class before using the real link class 
   // public Link_Movement test;

    public override Vector2 ItemAcction(Vector2 direction, Vector2 Position)
    {
      m_Destination = Position + (direction * m_MaxDistance);
      m_Velocity = direction * m_speed;
      isFlyingAway = true;
      return m_Destination;
    }

    private void Start()
    {
      isFlyingAway = false;
      /******************REMOVE WHEN DONE******************/
      Vector2 Distination = new Vector2(3.81f, 2.713296f);
      ItemAcction(Distination, new Vector2(0, 0));
    }

    private void Update()
    {
      if (isFlyingAway)
      {
        m_Position = m_Position + m_Velocity * Time.deltaTime;
        this.transform.position = new Vector3(m_Position.x, m_Position.y, 0);
        if((m_Destination - m_Position).magnitude < 1.0f)
        {
          Debug.Log("Very close");
        }
      }
      else if(isFlyingAway == false)
      {
       // Vector2 PlayerLocation = m_tempPlayer;
      }
    }

  }
}
