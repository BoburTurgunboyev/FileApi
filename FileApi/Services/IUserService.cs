namespace FileApi.Services
{
    public interface IUserService
    {
        public ValueTask<string> CreateAvatarAsync(IFormFile formFile);
    }
}
