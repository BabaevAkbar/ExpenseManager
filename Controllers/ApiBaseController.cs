namespace Controllers
{
    public abstract class ApiBaseController : ControllerBase
    {
        public Guid UserId => Guid.Parse(User.Claims.First(i => i.Type == "Id").Value);
    }
}