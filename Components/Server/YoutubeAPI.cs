namespace BlazorWeb_New.Components.Server;

using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

public class YouTubeApiService
{
    private readonly YouTubeService _youtubeService;

    public YouTubeApiService(IConfiguration configuration)
    {
        var apiKey = configuration["YouTubeApi:ApiKey"];
        
        _youtubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = apiKey,
            ApplicationName = "MyBlazorApp"
        });
    }

    public async Task<Channel?> GetChannelAsync(string channelId)
    {
        var request = _youtubeService.Channels.List("statistics,snippet");
        request.Id = channelId;

        var response = await request.ExecuteAsync();
        return response.Items?.FirstOrDefault();
    }
}