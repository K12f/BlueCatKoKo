// YApi QuickType插件生成，具体参考文档:https://plugins.jetbrains.com/plugin/18847-yapi-quicktype/documentation

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlueCatKoKo.Ui.Models;

public partial class KuaishouShareVideoData
{
    [JsonProperty("adminTags")] public List<object> AdminTags { get; set; }

    [JsonProperty("soundTrack")] public SoundTrack SoundTrack { get; set; }

    [JsonProperty("headUrl")] public Uri HeadUrl { get; set; }

    [JsonProperty("caption")] public string Caption { get; set; }

    [JsonProperty("forcePublic")] public string ForcePublic { get; set; }

    [JsonProperty("likeCount")] public long LikeCount { get; set; }

    [JsonProperty("exp_tag")] public string ExpTag { get; set; }

    [JsonProperty("type")] public long Type { get; set; }

    [JsonProperty("mainMvUrls")] public List<KuaiShouShareVideoDatarUrl> MainMvUrls { get; set; }

    [JsonProperty("userEid")] public string UserEid { get; set; }

    [JsonProperty("duration")] public long Duration { get; set; }

    [JsonProperty("shareCount")] public long ShareCount { get; set; }

    [JsonProperty("serverExpTag")] public string ServerExpTag { get; set; }

    [JsonProperty("ext_params")] public ExtParams ExtParams { get; set; }

    [JsonProperty("viewCount")] public long ViewCount { get; set; }

    [JsonProperty("headUrls")] public List<KuaiShouShareVideoDatarUrl> HeadUrls { get; set; }

    [JsonProperty("forwardCount")] public long ForwardCount { get; set; }

    [JsonProperty("tagShow")] public TagShow TagShow { get; set; }

    [JsonProperty("singlePicture")] public bool SinglePicture { get; set; }

    [JsonProperty("timestamp")] public long Timestamp { get; set; }

    [JsonProperty("height")] public long Height { get; set; }

    [JsonProperty("webpCoverUrls")] public List<KuaiShouShareVideoDatarUrl> WebpCoverUrls { get; set; }

    [JsonProperty("userSex")] public string UserSex { get; set; }

    [JsonProperty("manifest")] public Manifest Manifest { get; set; }

    [JsonProperty("share_info")] public string ShareInfo { get; set; }

    [JsonProperty("sameFrame")] public SameFrame SameFrame { get; set; }

    [JsonProperty("verified")] public bool Verified { get; set; }

    [JsonProperty("photoId")] public string PhotoId { get; set; }

    [JsonProperty("userName")] public string UserName { get; set; }

    [JsonProperty("userId")] public long UserId { get; set; }

    [JsonProperty("commentCount")] public long CommentCount { get; set; }

    [JsonProperty("commentShowType")] public long CommentShowType { get; set; }

    [JsonProperty("width")] public long Width { get; set; }

    [JsonProperty("photoType")] public string PhotoType { get; set; }

    [JsonProperty("coverUrls")] public List<KuaiShouShareVideoDatarUrl> CoverUrls { get; set; }
}

public partial class KuaiShouShareVideoDatarUrl
{
    [JsonProperty("cdn")] public string Cdn { get; set; }

    [JsonProperty("url")] public Uri Url { get; set; }
}

public partial class ExtParams
{
    [JsonProperty("mtype")] public long Mtype { get; set; }

    [JsonProperty("color")] public string Color { get; set; }

    [JsonProperty("w")] public long W { get; set; }

    [JsonProperty("sound")] public long Sound { get; set; }

    [JsonProperty("h")] public long H { get; set; }

    [JsonProperty("interval")] public long Interval { get; set; }

    [JsonProperty("video")] public long Video { get; set; }
}

public partial class Manifest
{
    [JsonProperty("playInfo")] public PlayInfo PlayInfo { get; set; }

    [JsonProperty("manualDefaultSelect")] public bool ManualDefaultSelect { get; set; }

    [JsonProperty("videoFeature")] public VideoFeature VideoFeature { get; set; }

    [JsonProperty("stereoType")] public long StereoType { get; set; }

    [JsonProperty("adaptationSet")] public List<AdaptationSet> AdaptationSet { get; set; }

    [JsonProperty("mediaType")] public long MediaType { get; set; }

    [JsonProperty("videoId")] public string VideoId { get; set; }

    [JsonProperty("hideAuto")] public bool HideAuto { get; set; }

    [JsonProperty("businessType")] public long BusinessType { get; set; }

    [JsonProperty("version")] public string Version { get; set; }
}

public partial class AdaptationSet
{
    [JsonProperty("duration")] public long Duration { get; set; }

    [JsonProperty("id")] public long Id { get; set; }

    [JsonProperty("representation")] public List<Representation> Representation { get; set; }
}

public partial class Representation
{
    [JsonProperty("hidden")] public bool Hidden { get; set; }

    [JsonProperty("backupUrl")] public List<Uri> BackupUrl { get; set; }

    [JsonProperty("normalizeGain")] public long NormalizeGain { get; set; }

    [JsonProperty("maxBitrate")] public long MaxBitrate { get; set; }

    [JsonProperty("hdrType")] public long HdrType { get; set; }

    [JsonProperty("frameRate")] public long FrameRate { get; set; }

    [JsonProperty("qualityLabel")] public string QualityLabel { get; set; }

    [JsonProperty("oriLoudness")] public double OriLoudness { get; set; }

    [JsonProperty("bitratePattern")] public List<long> BitratePattern { get; set; }

    [JsonProperty("id")] public long Id { get; set; }

    [JsonProperty("kvqScore")] public KvqScore KvqScore { get; set; }

    [JsonProperty("disableAdaptive")] public bool DisableAdaptive { get; set; }

    [JsonProperty("videoCodec")] public string VideoCodec { get; set; }

    [JsonProperty("height")] public long Height { get; set; }

    [JsonProperty("avgBitrate")] public long AvgBitrate { get; set; }

    [JsonProperty("defaultSelect")] public bool DefaultSelect { get; set; }

    [JsonProperty("mute")] public bool Mute { get; set; }

    [JsonProperty("url")] public Uri Url { get; set; }

    [JsonProperty("p2spCode")] public string P2SpCode { get; set; }

    [JsonProperty("quality")] public double Quality { get; set; }

    [JsonProperty("featureP2sp")] public bool FeatureP2Sp { get; set; }

    [JsonProperty("makeupGain")] public double MakeupGain { get; set; }

    [JsonProperty("fileSize")] public long FileSize { get; set; }

    [JsonProperty("width")] public long Width { get; set; }

    [JsonProperty("comment")] public string Comment { get; set; }

    [JsonProperty("qualityType")] public string QualityType { get; set; }

    [JsonProperty("minorInfo")] public string MinorInfo { get; set; }

    [JsonProperty("agc")] public bool Agc { get; set; }
}

public partial class KvqScore
{
    [JsonProperty("FRPost", NullValueHandling = NullValueHandling.Ignore)]
    public long? FrPost { get; set; }

    [JsonProperty("NR")] public double Nr { get; set; }

    [JsonProperty("NRPost")] public double NrPost { get; set; }
}

public partial class PlayInfo
{
    [JsonProperty("cdnTimeRangeLevel")] public long CdnTimeRangeLevel { get; set; }
}

public partial class VideoFeature
{
    [JsonProperty("mosScore")] public double MosScore { get; set; }

    [JsonProperty("blurProbability")] public double BlurProbability { get; set; }

    [JsonProperty("blockyProbability")] public double BlockyProbability { get; set; }

    [JsonProperty("avgEntropy")] public double AvgEntropy { get; set; }
}

public partial class SameFrame
{
    [JsonProperty("allow")] public bool Allow { get; set; }

    [JsonProperty("availableDepth")] public long AvailableDepth { get; set; }
}

public partial class SoundTrack
{
    [JsonProperty("genreId")] public long GenreId { get; set; }

    [JsonProperty("audioUrls")] public List<KuaiShouShareVideoDatarUrl> AudioUrls { get; set; }

    [JsonProperty("finalStatus")] public long FinalStatus { get; set; }

    [JsonProperty("artist")] public string Artist { get; set; }

    [JsonProperty("avatarUrls")] public List<KuaiShouShareVideoDatarUrl> AvatarUrls { get; set; }

    [JsonProperty("hasCopyright")] public bool HasCopyright { get; set; }

    [JsonProperty("loudness")] public long Loudness { get; set; }

    [JsonProperty("audioType")] public long AudioType { get; set; }

    [JsonProperty("photoId")] public double PhotoId { get; set; }

    [JsonProperty("type")] public long Type { get; set; }

    [JsonProperty("usageCount")] public long UsageCount { get; set; }

    [JsonProperty("photoCount")] public long PhotoCount { get; set; }

    [JsonProperty("disableEnhancedEntry")] public bool DisableEnhancedEntry { get; set; }

    [JsonProperty("imageUrls")] public List<KuaiShouShareVideoDatarUrl> ImageUrls { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("isOffline")] public bool IsOffline { get; set; }

    [JsonProperty("id")] public long Id { get; set; }

    [JsonProperty("user")] public User User { get; set; }
}

public partial class User
{
    [JsonProperty("user_sex")] public string UserSex { get; set; }

    [JsonProperty("eid")] public string Eid { get; set; }

    [JsonProperty("user_id")] public long UserId { get; set; }

    [JsonProperty("user_name")] public string UserName { get; set; }

    [JsonProperty("following")] public bool Following { get; set; }

    [JsonProperty("headurl")] public Uri Headurl { get; set; }

    [JsonProperty("headurls")] public List<KuaiShouShareVideoDatarUrl> Headurls { get; set; }

    [JsonProperty("visitorBeFollowed")] public bool VisitorBeFollowed { get; set; }
}

public partial class TagShow
{
    [JsonProperty("bannerType")] public long BannerType { get; set; }

    [JsonProperty("bizId")] public string BizId { get; set; }

    [JsonProperty("type")] public long Type { get; set; }

    [JsonProperty("usedCount")] public long UsedCount { get; set; }
}