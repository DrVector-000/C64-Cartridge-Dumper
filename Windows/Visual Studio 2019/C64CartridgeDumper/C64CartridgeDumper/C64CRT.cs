using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C64CartridgeDumper
{
    /*
     * CRT file format specs:
     * https://codebase64.org/doku.php?id=base:crt_file_format
    */

    enum C64CRT_Type : ushort
    {
        CT_NORMAL   = 0,        // 0 - Normal cartridge
        CT_ACTREP   = 1,        // 1 - Action Replay
        CT_KCSPC    = 2,        // 2 - KCS Power Cartridge
        CT_FCIII    = 3,        // 3 - Final Cartridge III
        CT_SBAS     = 4,        // 4 - Simons Basic
        CT_OCEAN1   = 5,        // 5 - Ocean type 1*
        CT_EXPCRT   = 6,        // 6 - Expert Cartridge
        CT_FUNPOW   = 7,        // 7 - Fun Play, Power Play
        CT_SUPGAM   = 8,        // 8 - Super Games
        CT_ATPOW    = 9,        // 9 - Atomic Power
        CT_EPYXFL   = 10,       // 10 - Epyx Fastload
        CT_WESTLEA  = 11,       // 11 - Westermann Learning
        CT_REXUTIL  = 12,       // 12 - Rex Utility
        CT_FINALCI  = 13,       // 13 - Final Cartridge I
        CT_MAGFOR   = 14,       // 14 - Magic Formel
        CT_GAMSYS3  = 15,       // 15 - C64 Game System, System 3
        CT_WARPSP   = 16,       // 16 - WarpSpeed
        CT_DINAMIC  = 17,       // 17 - Dinamic**
        CT_ZAXXON   = 18,       // 18 - Zaxxon, Super Zaxxon (SEGA)
        CT_MAGDESK  = 19        // 19 - Magic Desk, Domark, HES Australia
    }

    public class C64CRT
    {
    }
}
