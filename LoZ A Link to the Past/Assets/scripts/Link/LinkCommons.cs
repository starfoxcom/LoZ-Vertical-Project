﻿
static class LINK_GLOBALS
{
  public static int IDLE_STATE_ID = 0;

  public static int MOVEMENT_STATE_ID = 1;

  public static int DEAD_STATE_ID = 2;

  public static int PULL_STATE_ID = 3;

  public static int PUSH_STATE_ID = 4;

  public static int BOOMERANG_STATE_ID = 5;

  public static int TRANSITION_STATE_ID = 6;

  public static int ATTACK_STATE_ID = 7;

  public static int OUCH_STATE_ID = 8;

  public static string CONSUMIBLE_TAG = "Item_Consumible";
}

public enum LINK_TOOLS
{
  k_BOOMERANG,
  k_LAMP,
  k_EMPTY
}