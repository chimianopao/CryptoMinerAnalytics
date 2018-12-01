using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bitocin.Content.API {
    public class CryptoCompareAtualAPI {

        public class Rootobject {
            public BTC BTC { get; set; }
            public ETH ETH { get; set; }
            public XMR XMR { get; set; }
            public BCH BCH { get; set; }
            public ZEC ZEC { get; set; }
        }

        public class BTC {
            public Decimal BRL { get; set; }
        }

        public class ETH {
            public Decimal BRL { get; set; }
        }

        public class XMR {
            public Decimal BRL { get; set; }
        }

        public class BCH {
            public Decimal BRL { get; set; }
        }

        public class ZEC {
            public Decimal BRL { get; set; }
        }

    }
}