﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum
{
    enum MemoryFormatType
    {
        BIG_EDIAN,          // Big Endian/.z64:   [SU][PE][R ][MA][RI][O ][64] SUPER MARIO 64
        BYTE_SWAPPED,       // Byte Swapped/.v64: [US][EP][RA][MI][R ][O4][6 ] USEP RAMIR O46
        LITTLE_EDIAN        // Little Endian/.n64:[EP][US][AM][R ][OI][R ][46] EPUSAM R OIR 46
    }
}
