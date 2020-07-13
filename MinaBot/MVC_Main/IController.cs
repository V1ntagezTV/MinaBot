using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Main
{
    interface IController
    {
        abstract IModel GetModel { get; set; }
    }
}
