using BlueCatKoKo.Ui.Constants;

namespace BlueCatKoKo.Ui.Models;

/// <summary>
///     home page页面数据
/// </summary>
public class VideoModel
{
    // 短视频所属的平台
    public ShortVideoPlatformEnum Platform { get; set; }

    // 视频ID
    public string? VideoId { get; set; }

    // 作者  
    public string? AuthorName { get; set; }

    // Unique Id
    public string? UniqueId { get; set; }

    // 头像
    public string? AuthorAvatar { get; set; }

    // 视频标题
    public string? Title { get; set; }

    // 封面
    public string? Cover { get; set; }

    // 收藏数
    public long? CollectCount { get; set; }

    // 点赞数
    public long? DiggCount { get; set; }

    // 分享数
    public long? ShareCount { get; set; }

    // 评论数
    public long? CommentCount { get; set; }

    // 观看数量
    public long? ViewCount { get; set; }

    // 视频地址
    public string? VideoUrl { get; set; }

    // 音频地址
    public string? Mp3Url { get; set; }

    // 创建时间
    public string? CreatedTime { get; set; }

    // 视频描述
    public string? Desc { get; set; }

    // 视频时长
    public string? Duration { get; set; }

    public string? ShareId { get; set; }
}