using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum SpawnableItems : sbyte
{
  NULL = -128,
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

