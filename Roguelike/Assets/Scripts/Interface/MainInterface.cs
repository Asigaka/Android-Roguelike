using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInterface : InterfaceMenu
{
    public void TurnOnGameInterface()
    {
        InterfacesManager.Instance.ChangeInterface(InterfacesState.GameInterface);
        GameStatesManager.Instance.ChangeState(GameState.Playing);
    }
}
