using AutoMapper;
using MovieStoreWebApi.Entity;
using MovieStoreWebApi.MovieOperations.CreateMovie;
using MovieStoreWebApi.MovieOperations.GetMovie;
using MovieStoreWebApi.MovieOperations.GetMovieDetail;

namespace MovieStoreWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() //Mapping işlemleri yapıldı.
        {
            CreateMap<CreateMovieModel, Movie>();
            CreateMap<Movie, MovieDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Movie, MovieViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}
