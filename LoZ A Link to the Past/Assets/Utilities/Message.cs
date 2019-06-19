
using UnityEngine;
public class Message
{

  public Message(MESSAGE_TYPE _type, GameObject _gameObject = null)
  {

    m_type = _type;
    m_gameObject = _gameObject;
  }

  public enum MESSAGE_TYPE
  {
    LINK_COLLISION = 0,
    WALL_BLOCK_COLLISION,
  }

  public MESSAGE_TYPE m_type;
  public GameObject m_gameObject;
}
