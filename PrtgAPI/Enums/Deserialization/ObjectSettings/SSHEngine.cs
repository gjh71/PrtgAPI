﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrtgAPI
{
    public enum SSHEngine
    {
        [XmlEnum("2")]
        Default,

        [XmlEnum("1")]
        CompatibilityMode
    }
}