using System;
using System.Collections.Generic;
using System.Text;

namespace UcuLifeLib.Listener
{
    public interface IPlayPauseListener: IListener
    {
        void PlayPauseClicked();
    }
}
