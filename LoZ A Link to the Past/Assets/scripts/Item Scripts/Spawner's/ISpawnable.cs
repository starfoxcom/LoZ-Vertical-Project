using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.scripts.Item_Scripts.Spawner_s
{
  public enum SpawnableItems 
  {
    RANDOM = -1,
    HEART = 0,
    GREEN_POTION = 1,
    RUBY = 2,
    KEY = 3,
    MASTER_KEY = 4,
  }

  interface ISpawnable
  {
    void Spawn(int Index);
  }
}
