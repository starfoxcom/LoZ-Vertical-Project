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
    Vector2 m_Pos;
    Vector2 m_Velocity;
    bool FlyingAway = true;
    float m_speed = 1.0f;

    public override Vector2 ItemAcction(Vector2 direction, Vector2 Position)
    {
      throw new NotImplementedException();
    }

  }
}
