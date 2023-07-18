﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BabouExtensions
{
    public static class UriExtensions
    {
        /// <summary>
        /// HashSet list of over 400 third party query string parameters. Does not remove id from query string.
        /// </summary>
        public static readonly HashSet<string> ThirdPartyQueryParameters = new(new[] { "Browser", "C", "GCCON", "MCMP", "MarketPlace", "PD", "Refresh", "Sens", "ServiceVersion", "Source", "Topic", "__WB_REVISION__", "__cf_chl_jschl_tk__", "__d", "__hsfp", "__hssc", "__hstc", "__s", "_branch_match_id", "_bta_c", "_bta_tid", "_com", "_escaped_fragment_", "_ga", "_ga-ft", "_gl", "_hsmi", "_ke", "_kx", "_paged", "_sm_byp", "_sp", "_szp", "3x", "a", "a_k", "ac", "acpage", "action-box", "action_object_map", "action_ref_map", "action_type_map", "activecampaign_id", "ad", "ad_frame_full", "ad_frame_root", "ad_name", "adclida", "adid", "adlt", "adsafe_ip", "adset_name", "advid", "aff_sub2", "afftrack", "afterload", "ak_action", "alt_id", "am", "amazingmurphybeds", "amp;", "amp;amp", "amp;amp;amp", "amp;amp;amp;amp", "amp;utm_campaign", "amp;utm_medium", "amp;utm_source", "ampStoryAutoAnalyticsLinker", "ampstoryautoanalyticslinke", "an", "ap", "ap_id", "apif", "apipage", "as_occt", "as_q", "as_qdr", "askid", "atFileReset", "atfilereset", "aucid", "auct", "audience", "author", "awt_a", "awt_l", "awt_m", "b2w", "back", "bannerID", "blackhole", "blockedAdTracking", "blog-reader-used", "blogger", "br", "bsft_aaid", "bsft_clkid", "bsft_eid", "bsft_ek", "bsft_lx", "bsft_mid", "bsft_mime_type", "bsft_tv", "bsft_uid", "bvMethod", "bvTime", "bvVersion", "bvb64", "bvb64resp", "bvplugname", "bvprms", "bvprmsmac", "bvreqmerge", "cacheburst", "campaign", "campaign_id", "campaign_name", "campid", "catablog-gallery", "channel", "checksum", "ck_subscriber_id", "cmplz_region_redirect", "cmpnid", "cn-reloaded", "code", "comment", "content_ad_widget", "cost", "cr", "crl8_id", "crlt.pid", "crlt_pid", "crrelr", "crtvid", "ct", "cuid", "daksldlkdsadas", "dcc", "dfp", "dm_i", "domain", "dosubmit", "dsp_caid", "dsp_crid", "dsp_insertion_order_id", "dsp_pub_id", "dsp_tracker_token", "dt", "dur", "durs", "e", "ee", "ef_id", "el", "env", "erprint", "et_blog", "exch", "externalid", "fb_action_ids", "fb_action_types", "fb_ad", "fb_source", "fbclid", "fbzunique", "fg-aqp", "fireglass_rsn", "fo", "fp_sid", "fpa", "fref", "fs", "furl", "fwp_lunch_restrictions", "ga_action", "gclid", "gclsrc", "gdffi", "gdfms", "gdftrk", "gf_page", "gidzl", "goal", "gooal", "gpu", "gtVersion", "haibwc", "hash", "hc_location", "hemail", "hid", "highlight", "hl", "home", "hsa_acc", "hsa_ad", "hsa_cam", "hsa_grp", "hsa_kw", "hsa_mt", "hsa_net", "hsa_src", "hsa_tgt", "hsa_ver", "ias_campId", "ias_chanId", "ias_dealId", "ias_dspId", "ias_impId", "ias_placementId", "ias_pubId", "ical", "ict", "ie", "igshid", "im", "ipl", "jw_start", "jwsource", "k", "key1", "key2", "klaviyo", "ksconf", "ksref", "l", "label", "lang", "ldtag_cl", "level1", "level2", "level3", "level4", "li_fat_id", "limit", "lng", "load_all_comments", "lt", "ltclid", "ltd", "lucky", "m", "m?sales_kw", "matomo_campaign", "matomo_cid", "matomo_content", "matomo_group", "matomo_keyword", "matomo_medium", "matomo_placement", "matomo_source", "max-results", "mc_cid", "mc_eid", "mdrv", "mediaserver", "memset", "mibextid", "mkcid", "mkevt", "mkrid", "mkwid", "ml_subscriber", "ml_subscriber_hash", "mobileOn", "mode", "month", "msID", "msclkid", "msg", "mtm_campaign", "mtm_cid", "mtm_content", "mtm_group", "mtm_keyword", "mtm_medium", "mtm_placement", "mtm_source", "murphybedstoday", "mwprid", "n", "native_client", "navua", "nb", "nb_klid", "o", "okijoouuqnqq", "org", "pa_service_worker", "partnumber", "pcmtid", "pcode", "pcrid", "pfstyle", "phrase", "pid", "piwik_campaign", "piwik_keyword", "piwik_kwd", "pk_campaign", "pk_keyword", "pk_kwd", "placement", "plat", "platform", "playsinline", "pp", "pr", "prid", "print", "q", "q1", "qsrc", "r", "rd", "rdt_cid", "redig", "redir", "ref", "reftok", "relatedposts_hit", "relatedposts_origin", "relatedposts_position", "remodel", "replytocom", "reverse-paginate", "rid", "rnd", "rndnum", "robots_txt", "rq", "rsd", "s_kwcid", "sa", "safe", "said", "sales_cat", "sales_kw", "sb_referer_host", "scrape", "script", "scrlybrkr", "search", "sellid", "sersafe", "sfn_data", "sfn_trk", "sfns", "sfw", "sha1", "share", "shared", "showcomment", "si", "sid", "sid1", "sid2", "sidewalkShow", "sig", "site", "site_id", "siteid", "slicer1", "slicer2", "source", "spref", "spvb", "sra", "src", "srk", "srp", "ssp_iabi", "ssts", "stylishmurphybeds", "subId1", "subId2", "subId3", "subid", "swcfpc", "tail", "teaser", "test", "timezone", "toWww", "triplesource", "trk_contact", "trk_module", "trk_msg", "trk_sid", "tsig", "turl", "u", "up_auto_log", "upage", "updated-max", "uptime", "us_privacy", "usegapi", "usqp", "utm", "utm_campa", "utm_campaign", "utm_content", "utm_expid", "utm_id", "utm_medium", "utm_reader", "utm_referrer", "utm_source", "utm_sq", "utm_ter", "utm_term", "v", "vc", "vf", "vgo_ee", "vp", "vrw", "vz", "wbraid", "webdriver", "wing", "wpdParentID", "wpmp_switcher", "wref", "wswy", "wtime", "x", "zMoatImpID", "zarsrc", "zeffdn" });

        /// <summary>
        /// Removes all querystring parameters from a Uri and returns a URL with a trailing slash
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string ToCleanUrl(this Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            try
            {
                if (uri.IsAbsoluteUri)
                {
                    var absoluteUri = uri.AbsoluteUri;

                    if (absoluteUri.IndexOf("?") is { } queryIndex && queryIndex != -1)
                    {
                        absoluteUri = absoluteUri[..queryIndex];
                    }

                    var hasExtension = Path.HasExtension(absoluteUri);

                    if (hasExtension)
                    {
                        return absoluteUri;
                    }
                    else
                    {
                        return absoluteUri.EndsWith('/') ? absoluteUri : $"{absoluteUri}/";
                    }
                }
                return uri.AbsoluteUri ?? string.Empty;
            }
            catch (Exception)
            {
                return uri.AbsoluteUri ?? string.Empty;
            }
        }

        /// <summary>
        /// This removes third party query string parameters, while keeping the id parameter by default. You can specify additional parameters to keep or pass in a null or empty HashSet.
        /// </summary>
        /// <param name="url">The URL you wish to clean or sanitize.</param>
        /// <param name="keepParameters">If defined, a list of query string parameters to keep.</param>
        /// <returns></returns>
        public static string ToCleanURL(this string url, HashSet<string> keepParameters)
        {
            if(url.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(url), "The URL provided is either empty or null");
            }

            if (!url.IsValidUrl())
            {
                throw new ArgumentException("The URL provided is not a valid URL", nameof(url));
            }

            keepParameters ??= new HashSet<string>();

            if (url.IndexOf("?") is { } queryIndex && queryIndex != -1)
            {
                var uri = new UriBuilder(url);
                var queryString = uri.Query;
                var qs = System.Web.HttpUtility.ParseQueryString(queryString);
                if(qs != null && qs.HasKeys())
                {
                    foreach(string key in qs.Keys.Cast<string>().ToArray())
                    {
                        if (ThirdPartyQueryParameters.Contains(key) && !keepParameters.Contains(key))
                        {
                            qs.Remove(key);
                        }
                    }
                    uri.Query = qs.ToString();
                    url = uri.ToString();
                }
            }

            return url;
        }

        /// <summary>
        /// This removes third party query string parameters, while keeping the id parameter by default. You can specify additional parameters to keep or pass in a null or empty HashSet.
        /// </summary>
        /// <param name="uri">The Uri you wish to clean or sanitize.</param>
        /// <param name="keepParameters">If defined, a list of query string parameters to keep.</param>
        /// <returns></returns>
        public static Uri ToCleanURL(this Uri uri, HashSet<string> keepParameters)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            var url = uri.AbsoluteUri;
            return new Uri(url.ToCleanURL(keepParameters));
        }

        /// <summary>
        /// Formats Uri to return just the schema and the host with a trailing slash
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static Uri GetHostUri(this Uri uri)
        {
            return new Uri($"{uri.Scheme}://{uri.Host}".TrimEnd('/') + "/", UriKind.Absolute);
        }

        /// <summary>
        /// Formats Uri to return just the schema and the host with a trailing slash
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string GetHostUriAsString(this Uri uri)
        {
            return (new Uri($"{uri.Scheme}://{uri.Host}".TrimEnd('/') + "/", UriKind.Absolute)).AbsoluteUri;
        }
    }
}
