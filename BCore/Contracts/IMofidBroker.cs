﻿using BotCore.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCore.Contracts
{
    public interface IMofidBroker : IBrokerBase
    {
        void CheckOrderList();
        void FirstHint();
    }
}