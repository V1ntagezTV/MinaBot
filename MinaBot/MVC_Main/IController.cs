using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Main
{
    interface IController<out T>
    {
        public abstract T GetModel { get; }
    }
}
