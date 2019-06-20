﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
  /************************************************************************/
  /* PUBLIC                                                               */
  /************************************************************************/
  
  /*
   * Referencia a la Dungeon Camera
   * */
  public CameraController m_camera_controller;

  /*
   * Lista de Cuartos en el Dungeon.
   * */
  public Room[] m_room_list;

  public void
  SetActiveRoom(int _id)
  {
    foreach(Room room in m_room_list)
    {
      if(room.getID() == _id)
      {
        m_active_room = room;

        m_camera_controller.setRoomPoints(room.VECTOR_1, room.VECTOR_2);
        return;
      }
    }

    return;
  }

  /************************************************************************/
  /* PRIVATE                                                              */
  /************************************************************************/

  private Room m_active_room;

  // Start is called before the first frame update
  void 
  Start()
  {
    SetActiveRoom(m_room_list[0].getID());
    return;
  }
  
  // Update is called once per frame
  void 
  Update()
  {
      
  }
}
