using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bitocin.Content.API
{
    public class CoinWarzAPI
    {

        public class Rootobject
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public Datum[] Data { get; set; }
        }

        public class Datum
        {
            public string CoinName { get; set; }
            public string CoinTag { get; set; }
            public string Algorithm { get; set; }
            public Decimal Difficulty { get; set; }
            public Decimal BlockReward { get; set; }
            public int BlockCount { get; set; }
            public Decimal ProfitRatio { get; set; }
            public Decimal AvgProfitRatio { get; set; }
            public string Exchange { get; set; }
            public Decimal ExchangeRate { get; set; }
            public Decimal ExchangeVolume { get; set; }
            public bool IsBlockExplorerOnline { get; set; }
            public bool IsExchangeOnline { get; set; }
            public string Message { get; set; }
            public int BlockTimeInSeconds { get; set; }
            public string HealthStatus { get; set; }
        }

    }
}