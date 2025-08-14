using AutoMapper;

namespace StudentManager.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            // Create mappings here
            CreateMap<Models.User, Dtos.UserRegisterDTO>()
                .ReverseMap();

            CreateMap<Models.Subject, Dtos.SubjectDTO>()
                .ReverseMap();

            CreateMap<Models.Class, Dtos.ClassDTO>()
                .ReverseMap();

            CreateMap<Models.Grade, Dtos.GradeDTO>()
                .ReverseMap();

            CreateMap<Models.Parent, Dtos.ParentDTO>()
                .ReverseMap();

            CreateMap<Models.YourEntity, Dtos.YourEntityDTO>()
                .ReverseMap();

            CreateMap<Models.Role, Dtos.RoleDTO>()
                .ReverseMap();

        }
    }
}
