using Microsoft.AspNetCore.Mvc;

namespace ZT.ApiService.Controllers.Base
{
    [ApiController]
    //[Authorize("App")]
    [ApiExplorerSettings(GroupName = "v3")]
    [Route("api/[controller]")]
    public class AppController : ControllerBase
    {

    }
}
