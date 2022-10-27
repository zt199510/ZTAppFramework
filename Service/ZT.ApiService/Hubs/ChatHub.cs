using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using ZT.Common.Utils;
using ZT.Domain.Core.Cache;
using ZT.Domain.Core.Jwt;

namespace ZT.ApiService.Hubs
{
    [EnableCors("ZTFrameword")]
    public class ChatHub : Hub
    {
        private readonly IHttpContextAccessor _accessor;
        public ChatHub(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="user"></param>
        [HubMethodName("SendKickOut")]
        public async Task SendKickOut(string user)
        {
            var redisStr = RedisService.cli.Get(KeyUtils.ONLINEUSERS);
            if (!string.IsNullOrEmpty(redisStr))
            {
                var list = JsonSerializer.Deserialize<List<ClientUser>>(redisStr) ?? new List<ClientUser>();
                var now = list.FirstOrDefault(m => m.Id == long.Parse(user));
                if (now != null)
                {
                    Context.Items.Remove(now.ConnectionId);
                    list.Remove(now);
                }
                RedisService.cli.Set(KeyUtils.ONLINEUSERS, JsonSerializer.Serialize(list));
            }
            await Clients.All.SendAsync("ReceiveMessage", "out", user);
        }

        public override async Task OnConnectedAsync()
        {
            if (_accessor.HttpContext != null)
            {
                var token = _accessor.HttpContext.Request.Query["access_token"];
                var jwtToken = JwtAuthService.SerializeJwt(token);
                var user = new List<ClientUser>();
                var redisStr = RedisService.cli.Get(KeyUtils.ONLINEUSERS);
                if (string.IsNullOrEmpty(redisStr))
                {
                    user.Add(new ClientUser()
                    {
                        Id = jwtToken.Id,
                        ConnectionId = Context.ConnectionId,
                        Name = jwtToken.FullName
                    });
                    RedisService.cli.Set(KeyUtils.ONLINEUSERS, JsonSerializer.Serialize(user));
                }
                else
                {
                    user = JsonSerializer.Deserialize<List<ClientUser>>(redisStr) ?? new List<ClientUser>();
                    var now = user.FirstOrDefault(m => m.Id == jwtToken.Id);
                    if (now != null)
                    {
                        Context.Items.Remove(now.ConnectionId);
                        user.Remove(now);
                    }
                    user.Add(new ClientUser()
                    {
                        Id = jwtToken.Id,
                        ConnectionId = Context.ConnectionId,
                        Name = jwtToken.FullName
                    });
                    RedisService.cli.Set(KeyUtils.ONLINEUSERS, JsonSerializer.Serialize(user));
                }
            }
            await base.OnConnectedAsync();
        }

        /// <summary>
        /// 断开
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            string connid = Context.ConnectionId;
            var redisStr = RedisService.cli.Get(KeyUtils.ONLINEUSERS);
            if (string.IsNullOrEmpty(redisStr)) return base.OnDisconnectedAsync(exception);
            var user = JsonSerializer.Deserialize<List<ClientUser>>(redisStr) ?? new List<ClientUser>();
            var now = user.FirstOrDefault(m => m.ConnectionId == connid);
            if (now != null)
            {
                user.Remove(now);
            }
            RedisService.cli.Set(KeyUtils.ONLINEUSERS, JsonSerializer.Serialize(user));
            return base.OnDisconnectedAsync(exception);
        }

    }

    /// <summary>
    /// 用户信息
    /// </summary>
    public class ClientUser
    {
        /// <summary>
        /// 唯一id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 连接编号
        /// </summary>
        public string ConnectionId { get; set; }

        /// <summary>
        /// 应用编号
        /// </summary>
        public string AppId { get; set; } = "fytsoa";

        /// <summary>
        /// 登录人
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
