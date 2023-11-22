using FileApi.Data;

namespace FileApi.Services
{
    public class UserService : IUserService
    {
        private readonly UserDbContect _userDbContect;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserService(UserDbContect userDbContect,IWebHostEnvironment webHostEnvironment)
        {
            _userDbContect = userDbContect;
            _webHostEnvironment = webHostEnvironment;
        }
        public async ValueTask<string> CreateAvatarAsync(IFormFile formFile)
        {
            var extention = Path.GetExtension(formFile.FileName);
            var path = "/Images/" + Guid.NewGuid() + "." + extention;
            string fullpath = _webHostEnvironment.WebRootPath + path;

            using(FileStream file = new FileStream(fullpath, FileMode.Create))
            {
                await formFile.CopyToAsync(file);
            }
            return path;    
        }
    }
}
