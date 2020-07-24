using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Main
{
    interface IController
    {
        public abstract IModel GetModel { get; }
    }
}
