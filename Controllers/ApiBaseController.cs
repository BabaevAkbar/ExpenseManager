namespace Controllers
{
    public abstract class ApiBaseController : ControllerBase
    {
        public int UserId => int.Parse(User.Claims.First(i => i.Type == "id").Value);
    }
}