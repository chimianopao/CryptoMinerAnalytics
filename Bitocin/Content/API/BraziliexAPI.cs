using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bitocin.Content.API {
    public class BraziliexAPI {


        public class Rootobject {
            public Btc_Brl btc_brl { get; set; }
            public Eth_Brl eth_brl { get; set; }
            public Ltc_Brl ltc_brl { get; set; }
            public Xmr_Brl xmr_brl { get; set; }
            public Dash_Brl dash_brl { get; set; }
            public Mxt_Brl mxt_brl { get; set; }
            public Sngls_Brl sngls_brl { get; set; }
            public Bch_Brl bch_brl { get; set; }
            public Btg_Brl btg_brl { get; set; }
            public Zec_Brl zec_brl { get; set; }
            public Crw_Brl crw_brl { get; set; }
            public Omg_Brl omg_brl { get; set; }
            public Eos_Brl eos_brl { get; set; }
            public Gnt_Brl gnt_brl { get; set; }
            public Trx_Brl trx_brl { get; set; }
            public Bnb_Brl bnb_brl { get; set; }
            public Xrp_Brl xrp_brl { get; set; }
            public Dcr_Brl dcr_brl { get; set; }
            public Lcc_Brl lcc_brl { get; set; }
            public Onix_Brl onix_brl { get; set; }
            public Usdt_Brl usdt_brl { get; set; }
            public Etc_Brl etc_brl { get; set; }
            public Smart_Brl smart_brl { get; set; }
            public Abc_Brl abc_brl { get; set; }
            public Iop_Brl iop_brl { get; set; }
            public Ltc_Btc ltc_btc { get; set; }
            public Eth_Btc eth_btc { get; set; }
            public Xmr_Btc xmr_btc { get; set; }
            public Dash_Btc dash_btc { get; set; }
            public Prsp_Btc prsp_btc { get; set; }
            public Mxt_Btc mxt_btc { get; set; }
            public Bch_Btc bch_btc { get; set; }
            public Btg_Btc btg_btc { get; set; }
            public Zec_Btc zec_btc { get; set; }
            public Crw_Btc crw_btc { get; set; }
            public Brzx_Btc brzx_btc { get; set; }
            public Sngls_Btc sngls_btc { get; set; }
            public Omg_Btc omg_btc { get; set; }
            public Eos_Btc eos_btc { get; set; }
            public Gnt_Btc gnt_btc { get; set; }
            public Trx_Btc trx_btc { get; set; }
            public Bnb_Btc bnb_btc { get; set; }
            public Dcr_Btc dcr_btc { get; set; }
            public Xrp_Btc xrp_btc { get; set; }
            public Epc_Btc epc_btc { get; set; }
            public Lcc_Btc lcc_btc { get; set; }
            public Onix_Btc onix_btc { get; set; }
            public Etc_Btc etc_btc { get; set; }
            public Cfty_Btc cfty_btc { get; set; }
            public Smart_Btc smart_btc { get; set; }
            public Abc_Btc abc_btc { get; set; }
            public Iop_Btc iop_btc { get; set; }
            public Eth_Usdt eth_usdt { get; set; }
            public Xmr_Usdt xmr_usdt { get; set; }
            public Xrp_Usdt xrp_usdt { get; set; }
            public Ltc_Usdt ltc_usdt { get; set; }
            public Zec_Usdt zec_usdt { get; set; }
            public Dash_Usdt dash_usdt { get; set; }
            public Btc_Usdt btc_usdt { get; set; }
            public Bch_Usdt bch_usdt { get; set; }
            public Mxt_Usdt mxt_usdt { get; set; }
            public Brzx_Usdt brzx_usdt { get; set; }
            public Cfty_Usdt cfty_usdt { get; set; }
            public Smart_Usdt smart_usdt { get; set; }
            public Abc_Usdt abc_usdt { get; set; }
            public Etc_Usdt etc_usdt { get; set; }
            public Dcr_Usdt dcr_usdt { get; set; }
        }

        public class Btc_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Eth_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Ltc_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Xmr_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Dash_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Mxt_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Sngls_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Bch_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Btg_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Zec_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Crw_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Omg_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Eos_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Gnt_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Trx_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Bnb_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Xrp_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Dcr_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Lcc_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Onix_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Usdt_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Etc_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Smart_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Abc_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Iop_Brl {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Ltc_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Eth_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Xmr_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Dash_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Prsp_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Mxt_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Bch_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Btg_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Zec_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Crw_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Brzx_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Sngls_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Omg_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Eos_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Gnt_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Trx_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Bnb_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Dcr_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Xrp_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Epc_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Lcc_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Onix_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Etc_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Cfty_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Smart_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Abc_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Iop_Btc {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Eth_Usdt {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Xmr_Usdt {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Xrp_Usdt {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Ltc_Usdt {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Zec_Usdt {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Dash_Usdt {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Btc_Usdt {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Bch_Usdt {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Mxt_Usdt {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Brzx_Usdt {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Cfty_Usdt {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Smart_Usdt {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Abc_Usdt {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Etc_Usdt {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }

        public class Dcr_Usdt {
            public Decimal active { get; set; }
            public string market { get; set; }
            public Decimal last { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume24 { get; set; }
            public Decimal quoteVolume24 { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal highestBid24 { get; set; }
            public Decimal lowestAsk24 { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal lowestAsk { get; set; }
        }




    }
}