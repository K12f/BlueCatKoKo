// YApi QuickType插件生成，具体参考文档:https://plugins.jetbrains.com/plugin/18847-yapi-quicktype/documentation

using Newtonsoft.Json;

namespace BlueCatKoKo.Ui.Models
{
    public class KuaiShouShareVideoData 
    {
        [JsonProperty("result")]
        public long Result { get; set; }

        [JsonProperty("fid")]
        public long Fid { get; set; }

        [JsonProperty("shareInfo")]
        public ShareInfo ShareInfo { get; set; }

        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }

        [JsonProperty("counts")]
        public Counts Counts { get; set; }

        [JsonProperty("photo")]
        public Photo Photo { get; set; }

        [JsonProperty("trendingInfo")]
        public TrendingInfo TrendingInfo { get; set; }

        [JsonProperty("mp4Url")]
        public Uri Mp4Url { get; set; }

        [JsonProperty("photos")]
        public List<Photo> Photos { get; set; }

        [JsonProperty("shareUserPhotos")]
        public List<object> ShareUserPhotos { get; set; }

        [JsonProperty("serialInfo")]
        public SerialInfo SerialInfo { get; set; }
    }

    public class Comment
    {
        [JsonProperty("author_name")]
        public string AuthorName { get; set; }

        [JsonProperty("cashTags")]
        public CashTags CashTags { get; set; }

        [JsonProperty("commentAuthorTags")]
        public List<object> CommentAuthorTags { get; set; }

        [JsonProperty("photo_id")]
        public double PhotoId { get; set; }

        [JsonProperty("headurl")]
        public Uri Headurl { get; set; }

        [JsonProperty("headurls")]
        public List<CoverUrl> Headurls { get; set; }

        [JsonProperty("author_liked")]
        public bool AuthorLiked { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("comment_id")]
        public long CommentId { get; set; }

        [JsonProperty("authorVerified")]
        public bool AuthorVerified { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("user_sex")]
        public string UserSex { get; set; }

        [JsonProperty("reply_to")]
        public long ReplyTo { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("replyToUserName", NullValueHandling = NullValueHandling.Ignore)]
        public string ReplyToUserName { get; set; }

        [JsonProperty("commentBottomTags")]
        public List<object> CommentBottomTags { get; set; }

        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("author_id")]
        public long AuthorId { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }

    public  class CashTags
    {
    }

    public  class CoverUrl
    {
        [JsonProperty("cdn")]
        public string Cdn { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public  class Counts
    {
        [JsonProperty("fanCount")]
        public long FanCount { get; set; }

        [JsonProperty("followCount")]
        public long FollowCount { get; set; }

        [JsonProperty("collectionCount")]
        public long CollectionCount { get; set; }

        [JsonProperty("photoCount")]
        public long PhotoCount { get; set; }
    }

    public  class Photo
    {
        [JsonProperty("adminTags")]
        public List<object> AdminTags { get; set; }

        [JsonProperty("soundTrack")]
        public SoundTrack SoundTrack { get; set; }

        [JsonProperty("headUrl")]
        public Uri HeadUrl { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("forcePublic")]
        public string ForcePublic { get; set; }

        [JsonProperty("likeCount")]
        public long LikeCount { get; set; }

        [JsonProperty("exp_tag")]
        public string ExpTag { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("mainMvUrls")]
        public List<CoverUrl> MainMvUrls { get; set; }

        [JsonProperty("userEid")]
        public string UserEid { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("shareCount", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShareCount { get; set; }

        [JsonProperty("serverExpTag")]
        public string ServerExpTag { get; set; }

        [JsonProperty("ext_params")]
        public ExtParams ExtParams { get; set; }

        [JsonProperty("viewCount")]
        public long ViewCount { get; set; }

        [JsonProperty("headUrls")]
        public List<CoverUrl> HeadUrls { get; set; }

        [JsonProperty("forwardCount")]
        public long ForwardCount { get; set; }

        [JsonProperty("tagShow")]
        public TagShow TagShow { get; set; }

        [JsonProperty("singlePicture")]
        public bool SinglePicture { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("webpCoverUrls")]
        public List<CoverUrl> WebpCoverUrls { get; set; }

        [JsonProperty("userSex")]
        public string UserSex { get; set; }

        [JsonProperty("manifest", NullValueHandling = NullValueHandling.Ignore)]
        public Manifest Manifest { get; set; }

        [JsonProperty("share_info")]
        public string ShareInfo { get; set; }

        [JsonProperty("sameFrame")]
        public SameFrame SameFrame { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("photoId")]
        public string PhotoId { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("commentCount")]
        public long CommentCount { get; set; }

        [JsonProperty("commentShowType", NullValueHandling = NullValueHandling.Ignore)]
        public long? CommentShowType { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("photoType")]
        public string PhotoType { get; set; }

        [JsonProperty("coverUrls")]
        public List<CoverUrl> CoverUrls { get; set; }

        [JsonProperty("cccCoverMap", NullValueHandling = NullValueHandling.Ignore)]
        public CccCoverMap CccCoverMap { get; set; }

        [JsonProperty("overrideCoverUrls", NullValueHandling = NullValueHandling.Ignore)]
        public OverrideCoverUrls OverrideCoverUrls { get; set; }
    }

    public  class CccCoverMap
    {
        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public  class ExtParams
    {
        [JsonProperty("mtype")]
        public long Mtype { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("w")]
        public long W { get; set; }

        [JsonProperty("sound")]
        public long Sound { get; set; }

        [JsonProperty("h")]
        public long H { get; set; }

        [JsonProperty("interval")]
        public long Interval { get; set; }

        [JsonProperty("video")]
        public long Video { get; set; }
    }

    public  class Manifest
    {
        [JsonProperty("playInfo")]
        public PlayInfo PlayInfo { get; set; }

        [JsonProperty("manualDefaultSelect")]
        public bool ManualDefaultSelect { get; set; }

        [JsonProperty("videoFeature")]
        public VideoFeature VideoFeature { get; set; }

        [JsonProperty("stereoType")]
        public long StereoType { get; set; }

        [JsonProperty("adaptationSet")]
        public List<AdaptationSet> AdaptationSet { get; set; }

        [JsonProperty("mediaType")]
        public long MediaType { get; set; }

        [JsonProperty("videoId")]
        public string VideoId { get; set; }

        [JsonProperty("hideAuto")]
        public bool HideAuto { get; set; }

        [JsonProperty("businessType")]
        public long BusinessType { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public  class AdaptationSet
    {
        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("representation")]
        public List<Representation> Representation { get; set; }
    }

    public  class Representation
    {
        [JsonProperty("avgBitrate")]
        public long AvgBitrate { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("backupUrl")]
        public List<Uri> BackupUrl { get; set; }

        [JsonProperty("maxBitrate")]
        public long MaxBitrate { get; set; }

        [JsonProperty("defaultSelect")]
        public bool DefaultSelect { get; set; }

        [JsonProperty("hdrType")]
        public long HdrType { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("p2spCode")]
        public string P2SpCode { get; set; }

        [JsonProperty("quality")]
        public double Quality { get; set; }

        [JsonProperty("featureP2sp")]
        public bool FeatureP2Sp { get; set; }

        [JsonProperty("frameRate")]
        public double FrameRate { get; set; }

        [JsonProperty("qualityLabel")]
        public string QualityLabel { get; set; }

        [JsonProperty("fileSize")]
        public long FileSize { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("bitratePattern")]
        public List<long> BitratePattern { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("qualityType")]
        public string QualityType { get; set; }

        [JsonProperty("kvqScore")]
        public KvqScore KvqScore { get; set; }

        [JsonProperty("disableAdaptive")]
        public bool DisableAdaptive { get; set; }

        [JsonProperty("minorInfo")]
        public string MinorInfo { get; set; }

        [JsonProperty("videoCodec")]
        public string VideoCodec { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public  class KvqScore
    {
        [JsonProperty("FRPost")]
        public long FrPost { get; set; }

        [JsonProperty("NR")]
        public double Nr { get; set; }

        [JsonProperty("NRPost")]
        public double NrPost { get; set; }

        [JsonProperty("FR")]
        public double Fr { get; set; }
    }

    public  class PlayInfo
    {
        [JsonProperty("strategyBus")]
        public string StrategyBus { get; set; }

        [JsonProperty("cdnTimeRangeLevel")]
        public long CdnTimeRangeLevel { get; set; }
    }

    public  class VideoFeature
    {
        [JsonProperty("mosScore")]
        public double MosScore { get; set; }

        [JsonProperty("blurProbability")]
        public double BlurProbability { get; set; }

        [JsonProperty("blockyProbability")]
        public double BlockyProbability { get; set; }

        [JsonProperty("avgEntropy")]
        public double AvgEntropy { get; set; }
    }

    public  class OverrideCoverUrls
    {
        [JsonProperty("jpgCdnNodeView")]
        public List<CoverUrl> JpgCdnNodeView { get; set; }

        [JsonProperty("webpCdnNodeView")]
        public List<CoverUrl> WebpCdnNodeView { get; set; }
    }

    public  class SameFrame
    {
        [JsonProperty("allow")]
        public bool Allow { get; set; }

        [JsonProperty("availableDepth")]
        public long AvailableDepth { get; set; }
    }

    public  class SoundTrack
    {
        [JsonProperty("genreId")]
        public long GenreId { get; set; }

        [JsonProperty("audioUrls")]
        public List<CoverUrl> AudioUrls { get; set; }

        [JsonProperty("finalStatus")]
        public long FinalStatus { get; set; }

        [JsonProperty("avatarUrls")]
        public List<CoverUrl> AvatarUrls { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("hasCopyright")]
        public bool HasCopyright { get; set; }

        [JsonProperty("loudness")]
        public long Loudness { get; set; }

        [JsonProperty("audioType")]
        public long AudioType { get; set; }

        [JsonProperty("photoId")]
        public double PhotoId { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("disableEnhancedEntry")]
        public bool DisableEnhancedEntry { get; set; }

        [JsonProperty("imageUrls")]
        public List<CoverUrl> ImageUrls { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isOffline")]
        public bool IsOffline { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

    public  class User
    {
        [JsonProperty("user_sex")]
        public string UserSex { get; set; }

        [JsonProperty("eid")]
        public string Eid { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("following")]
        public bool Following { get; set; }

        [JsonProperty("headurl")]
        public Uri Headurl { get; set; }

        [JsonProperty("headurls")]
        public List<CoverUrl> Headurls { get; set; }

        [JsonProperty("visitorBeFollowed")]
        public bool VisitorBeFollowed { get; set; }
    }

    public  class TagShow
    {
        [JsonProperty("bannerType")]
        public long BannerType { get; set; }

        [JsonProperty("bizId")]
        public string BizId { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("usedCount")]
        public long UsedCount { get; set; }
    }

    public  class SerialInfo
    {
        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("show")]
        public bool Show { get; set; }
    }

    public  class ShareInfo
    {
        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        [JsonProperty("shareTitle")]
        public string ShareTitle { get; set; }

        [JsonProperty("docId")]
        public long DocId { get; set; }

        [JsonProperty("shareId")]
        public string ShareId { get; set; }

        [JsonProperty("shareType")]
        public long ShareType { get; set; }

        [JsonProperty("shareSubTitle")]
        public string ShareSubTitle { get; set; }
    }

    public  class TrendingInfo
    {
        [JsonProperty("iconRightMargin")]
        public long IconRightMargin { get; set; }

        [JsonProperty("preTitle")]
        public string PreTitle { get; set; }

        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; }

        [JsonProperty("iconHeight")]
        public long IconHeight { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }

        [JsonProperty("iconWidth")]
        public long IconWidth { get; set; }

        [JsonProperty("showSeparator")]
        public bool ShowSeparator { get; set; }

        [JsonProperty("wordId")]
        public long WordId { get; set; }

        [JsonProperty("notTruncatedTitle")]
        public string NotTruncatedTitle { get; set; }

        [JsonProperty("bottomWeakStyleType")]
        public long BottomWeakStyleType { get; set; }

        [JsonProperty("showArrow")]
        public bool ShowArrow { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("tailIconUrl")]
        public string TailIconUrl { get; set; }

        [JsonProperty("roundCorner")]
        public bool RoundCorner { get; set; }

        [JsonProperty("enableForceClose")]
        public bool EnableForceClose { get; set; }

        [JsonProperty("fontSize")]
        public long FontSize { get; set; }

        [JsonProperty("iconUrl")]
        public Uri IconUrl { get; set; }

        [JsonProperty("fontColor")]
        public string FontColor { get; set; }
    }
}
