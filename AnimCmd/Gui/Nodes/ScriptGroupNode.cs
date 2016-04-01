﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using Sm4shCommand.Classes;

namespace Sm4shCommand.Nodes
{
    public class ScriptGroupNode : BaseNode
    {
        private static ContextMenuStrip _menu;
        public bool Dirty { get { return Fighter.Dirty; } }
        public ScriptGroupNode(Fighter fighter, uint CRC)
        {

            ContextMenuStrip = _menu;
            base.Fighter = fighter;
            base.CRC = CRC;

            for (int i = 0; i < 4; i++)
            {
                if (fighter[(ACMDType)i].EventLists.ContainsKey(CRC))
                    lists.Add(fighter[(ACMDType)i].EventLists[CRC]);
                else
                {
                    ACMDScript cml = new ACMDScript(CRC);
                    cml.Initialize();
                    lists.Add(cml);
                }
            }
        }
        public List<ACMDScript> lists = new List<ACMDScript>(4);
    }
}