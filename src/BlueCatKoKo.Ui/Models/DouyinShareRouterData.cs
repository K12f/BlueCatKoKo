using Newtonsoft.Json;

namespace BlueCatKoKo.Ui.Models
{
    /// <summary>
    ///     抖音 分享文本中的视频数据
    /// </summary>
    public class DouyinShareRouterData
    {
        [JsonProperty("loaderData")] public LoaderData LoaderData { get; set; }
    }

    public class LoaderData
    {
        [JsonProperty("video_(id)/page")] public VideoIdPage VideoIdPage { get; set; }
    }

    public class VideoIdPage
    {
        [JsonProperty("isAutoOpenApp")] public bool IsAutoOpenApp { get; set; }

        [JsonProperty("appName")] public string AppName { get; set; }

        [JsonProperty("query")] public Query Query { get; set; }

        [JsonProperty("isSpider")] public bool IsSpider { get; set; }

        [JsonProperty("ua")] public string Ua { get; set; }

        [JsonProperty("isVideoOptimize")] public bool IsVideoOptimize { get; set; }

        [JsonProperty("commonContext")] public CommonContext CommonContext { get; set; }

        [JsonProperty("itemId")] public string ItemId { get; set; }

        [JsonProperty("webId")] public string WebId { get; set; }

        [JsonProperty("renderInSSR")] public long RenderInSsr { get; set; }

        [JsonProperty("host")] public string Host { get; set; }

        [JsonProperty("videoInfoRes")] public VideoInfoRes VideoInfoRes { get; set; }

        [JsonProperty("darkModeAdaptation")] public bool DarkModeAdaptation { get; set; }

        [JsonProperty("lastPath")] public string LastPath { get; set; }

        [JsonProperty("isNotSupportWebp")] public bool IsNotSupportWebp { get; set; }

        [JsonProperty("serverToken")] public string ServerToken { get; set; }
    }

    public class CommonContext
    {
        [JsonProperty("webId")] public string WebId { get; set; }

        [JsonProperty("renderInSSR")] public long RenderInSsr { get; set; }

        [JsonProperty("appName")] public string AppName { get; set; }

        [JsonProperty("query")] public Query Query { get; set; }

        [JsonProperty("host")] public string Host { get; set; }

        [JsonProperty("isSpider")] public bool IsSpider { get; set; }

        [JsonProperty("lastPath")] public string LastPath { get; set; }

        [JsonProperty("isNotSupportWebp")] public bool IsNotSupportWebp { get; set; }

        [JsonProperty("ua")] public string Ua { get; set; }
    }

    public class Query
    {
        [JsonProperty("titleType")] public string TitleType { get; set; }

        [JsonProperty("iid")] public string Iid { get; set; }

        [JsonProperty("u_code")] public string UCode { get; set; }

        [JsonProperty("from_ssr")] public long FromSsr { get; set; }

        [JsonProperty("mid")] public string Mid { get; set; }

        [JsonProperty("share_sign")] public string ShareSign { get; set; }

        [JsonProperty("with_sec_did")] public long WithSecDid { get; set; }

        [JsonProperty("from_aid")] public long FromAid { get; set; }

        [JsonProperty("from")] public string From { get; set; }

        [JsonProperty("region")] public string Region { get; set; }

        [JsonProperty("did")] public string Did { get; set; }

        [JsonProperty("share_version")] public long ShareVersion { get; set; }

        [JsonProperty("ts")] public long Ts { get; set; }
    }

    public class VideoInfoRes
    {
        [JsonProperty("status_code")] public long StatusCode { get; set; }

        [JsonProperty("filter_list")] public List<object> FilterList { get; set; }

        [JsonProperty("item_list")] public List<ItemList> ItemList { get; set; }

        [JsonProperty("extra")] public Extra Extra { get; set; }
    }

    public class Extra
    {
        [JsonProperty("now")] public long Now { get; set; }
    }

    public class ItemList
    {
        [JsonProperty("video")] public Video Video { get; set; }

        [JsonProperty("music")] public Music Music { get; set; }

        [JsonProperty("create_time")] public long CreateTime { get; set; }

        [JsonProperty("author")] public Author Author { get; set; }

        [JsonProperty("risk_infos")] public RiskInfos RiskInfos { get; set; }

        [JsonProperty("mix_info")] public MixInfo MixInfo { get; set; }

        [JsonProperty("aweme_id")] public string AwemeId { get; set; }

        [JsonProperty("group_id_str")] public string GroupIdStr { get; set; }

        [JsonProperty("text_extra")] public List<TextExtra> TextExtra { get; set; }

        [JsonProperty("aweme_type")] public long AwemeType { get; set; }

        [JsonProperty("desc")] public string Desc { get; set; }

        [JsonProperty("statistics")] public Statistics Statistics { get; set; }
    }

    public class Author
    {
        [JsonProperty("avatar_medium")] public AvatarMedium AvatarMedium { get; set; }

        [JsonProperty("unique_id")] public string UniqueId { get; set; }

        [JsonProperty("sec_uid")] public string SecUid { get; set; }

        [JsonProperty("signature")] public string Signature { get; set; }

        [JsonProperty("mplatform_followers_count")]
        public long MplatformFollowersCount { get; set; }

        [JsonProperty("avatar_thumb")] public AvatarMedium AvatarThumb { get; set; }

        [JsonProperty("follow_status")] public long FollowStatus { get; set; }

        [JsonProperty("short_id")] public string ShortId { get; set; }

        [JsonProperty("following_count")] public long FollowingCount { get; set; }

        [JsonProperty("nickname")] public string Nickname { get; set; }

        [JsonProperty("favoriting_count")] public long FavoritingCount { get; set; }
    }

    public class AvatarMedium
    {
        [JsonProperty("url_list")] public List<Uri> UrlList { get; set; }

        [JsonProperty("uri")] public string Uri { get; set; }
    }

    public class MixInfo
    {
        [JsonProperty("mix_id")] public string MixId { get; set; }

        [JsonProperty("cover_url")] public AvatarMedium CoverUrl { get; set; }

        [JsonProperty("next_info")] public NextInfo NextInfo { get; set; }

        [JsonProperty("statis")] public Statis Statis { get; set; }

        [JsonProperty("create_time")] public long CreateTime { get; set; }

        [JsonProperty("extra")] public string Extra { get; set; }

        [JsonProperty("mix_name")] public string MixName { get; set; }

        [JsonProperty("status")] public Status Status { get; set; }

        [JsonProperty("desc")] public string Desc { get; set; }
    }

    public class NextInfo
    {
        [JsonProperty("cover_url")] public AvatarMedium CoverUrl { get; set; }

        [JsonProperty("mix_name")] public string MixName { get; set; }

        [JsonProperty("desc")] public string Desc { get; set; }
    }

    public class Statis
    {
        [JsonProperty("collect_vv")] public long CollectVv { get; set; }

        [JsonProperty("current_episode")] public long CurrentEpisode { get; set; }

        [JsonProperty("play_vv")] public long PlayVv { get; set; }

        [JsonProperty("updated_to_episode")] public long UpdatedToEpisode { get; set; }
    }

    public class Status
    {
        [JsonProperty("is_collected")] public long IsCollected { get; set; }

        [JsonProperty("status")] public long StatusStatus { get; set; }
    }

    public class Music
    {
        [JsonProperty("duration")] public long Duration { get; set; }

        [JsonProperty("author")] public string Author { get; set; }

        [JsonProperty("cover_medium")] public AvatarMedium CoverMedium { get; set; }

        [JsonProperty("mid")] public string Mid { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("cover_hd")] public AvatarMedium CoverHd { get; set; }

        [JsonProperty("cover_large")] public AvatarMedium CoverLarge { get; set; }

        [JsonProperty("cover_thumb")] public AvatarMedium CoverThumb { get; set; }

        [JsonProperty("status")] public long Status { get; set; }
    }

    public class RiskInfos
    {
        [JsonProperty("warn")] public bool Warn { get; set; }

        [JsonProperty("type")] public long Type { get; set; }

        [JsonProperty("content")] public string Content { get; set; }

        [JsonProperty("reflow_unplayable")] public long ReflowUnplayable { get; set; }
    }

    public class Statistics
    {
        [JsonProperty("comment_count")] public int CommentCount { get; set; }

        [JsonProperty("share_count")] public int ShareCount { get; set; }

        [JsonProperty("aweme_id")] public string AwemeId { get; set; }

        [JsonProperty("digg_count")] public int DiggCount { get; set; }

        [JsonProperty("play_count")] public int PlayCount { get; set; }

        [JsonProperty("collect_count")] public int CollectCount { get; set; }
    }

    public class TextExtra
    {
        [JsonProperty("hashtag_id")] public long HashtagId { get; set; }

        [JsonProperty("start")] public long Start { get; set; }

        [JsonProperty("end")] public long End { get; set; }

        [JsonProperty("type")] public long Type { get; set; }

        [JsonProperty("hashtag_name")] public string HashtagName { get; set; }
    }

    public class Video
    {
        [JsonProperty("cover")] public AvatarMedium Cover { get; set; }

        [JsonProperty("play_addr")] public AvatarMedium PlayAddr { get; set; }

        [JsonProperty("width")] public long Width { get; set; }

        [JsonProperty("height")] public long Height { get; set; }
    }
}