// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Provides methods for extensing members in AliceToolsProxies namespace.
    /// </summary>
    public static class AliceToolsProxiesExtensions
    {

        private static readonly Dictionary<int, string> s_pageCodeNameMap = new Dictionary<int, string>(71)
        {
            {20127, "ASCII"           },
            {28591, "ISO-8859-1"      },
            {28592, "ISO-8859-2"      },
            {28593, "ISO-8859-3"      },
            {28594, "ISO-8859-4"      },
            {28595, "ISO-8859-5"      },
            {28596, "ISO-8859-6"      },
            {28597, "ISO-8859-7"      },
            {28598, "ISO-8859-8"      },
            {28599, "ISO-8859-9"      },
            {28603, "ISO-8859-13"     },
            {28605, "ISO-8859-15"     },
            {20866, "KOI8-R"          },
            {21866, "KOI8-U"          },
            {20932, "EUC-JP"          },
            {50220, "ISO-2022-JP"     },
            {51936, "EUC-CN"          },
            {52936, "HZ"              },
            {54936, "GB18030"         },
            {50227, "ISO-2022-CN"     },
            {51949, "EUC-KR"          },
            {50225, "ISO-2022-KR"     },
            {437,   "CP437"           },
            {737,   "CP737"           },
            {775,   "CP775"           },
            {874,   "CP874"           },
            {850,   "CP850"           },
            {852,   "CP852"           },
            {855,   "CP855"           },
            {857,   "CP857"           },
            {858,   "CP858"           },
            {860,   "CP860"           },
            {861,   "CP861"           },
            {862,   "CP862"           },
            {863,   "CP863"           },
            {864,   "CP864"           },
            {865,   "CP865"           },
            {866,   "CP866"           },
            {869,   "CP869"           },
            {932,   "CP932"           },
            {936,   "CP936"           },
            {949,   "CP949"           },
            {950,   "CP950"           },
            {1250,  "CP1250"          },
            {1251,  "CP1251"          },
            {1252,  "CP1252"          },
            {1253,  "CP1253"          },
            {1254,  "CP1254"          },
            {1255,  "CP1255"          },
            {1256,  "CP1256"          },
            {1257,  "CP1257"          },
            {1258,  "CP1258"          },
            {65000, "UTF-7"           },
            {65001, "UTF-8"           },
            {1200,  "UTF-16LE"        },
            {1201,  "UTF-16BE"        },
            {12000, "UTF-32LE"        },
            {12001, "UTF-32BE"        },
            {1361,  "JOHAB"           },
            {10000, "Macintosh"       },
            {10004, "MacArabic"       },
            {10005, "MacHebrew"       },
            {10006, "MacGreek"        },
            {10007, "MacCyrillic"     },
            {10017, "MacUkraine"      },
            {10010, "MacRomania"      },
            {10021, "MacThai"         },
            {10029, "MacCentralEurope"},
            {10079, "MacIceland"      },
            {10081, "MacTurkish"      },
            {10082, "MacCroatian"     }

        };

        /// <summary>
        /// Gets a value shows if this <see cref="Encoding"/> has libiconv friendly name.
        /// </summary>
        /// <param name="encoding">encoding.</param>
        /// <returns><c>true</c> if this <see cref="Encoding"/> has libiconv friendly name, otherwise, <c>false</c>.</returns>
        public static bool IsLibiconvSupported(this Encoding encoding) => s_pageCodeNameMap.ContainsKey(encoding.CodePage);

        /// <summary>
        /// Gets libiconv friendly name.
        /// </summary>
        /// <param name="encoding">encoding.</param>
        /// <returns>The libiconv friendly name.</returns>
        /// <exception cref="ArgumentException"><paramref name="encoding"/>does not have libiconv friendly name.</exception>
        public static string GetLibiconvFriendlyName(this Encoding encoding) =>
             s_pageCodeNameMap.TryGetValue(encoding.CodePage, out string name) ?
                name :
             throw new ArgumentException("encoding does not have libiconv friendly name.");

        /// <summary>
        /// Try get libiconv friendly name.
        /// </summary>
        /// <param name="encoding">encoding.</param>
        /// <param name="name">If succeed, returns the libiconv friendly name.</param>
        /// <returns><c>true</c> if succeed, otherwise, <c>false</c>.</returns>
        public static bool TryGetLibiconvFriendlyName(this Encoding encoding, out string name) => s_pageCodeNameMap.TryGetValue(encoding.CodePage, out name);
    }
}
