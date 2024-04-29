using API.DTO;
using AutoMapper;
using Core.Model;
using Task = Core.Model.Task;

namespace API.Helpers
{
    public class FileUrlResolver : IValueResolver<Task, TaskToReturn, string>
    {
        private readonly IConfiguration _config;

        public FileUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Task source, TaskToReturn destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.FileURL)) { 
                return _config["ApiUrl"] + source.FileURL;
            }

            return null;
        }
    }
}
