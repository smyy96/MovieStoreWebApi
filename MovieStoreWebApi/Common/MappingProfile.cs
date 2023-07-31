using AutoMapper;
using MovieStoreWebApi.Application.GenreOperations;
using MovieStoreWebApi.Application.GenreOperations.Queries;
using MovieStoreWebApi.Application.MovieOperations.Commands.CreateMovie;
using MovieStoreWebApi.Application.MovieOperations.Queries.GetMovie;
using MovieStoreWebApi.Application.MovieOperations.Queries.GetMovieDetail;
using MovieStoreWebApi.Entity;

namespace MovieStoreWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() //Mapping işlemleri yapıldı.
        {
            CreateMap<CreateMovieModel, Movie>();

            CreateMap<Movie, MovieDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.GenreName));
            CreateMap<Movie, MovieViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.GenreName));


            CreateMap<Genre, GenreViewModel>(); //genre'yı genreview modele dönüştürme
            CreateMap<Genre, GenreDetailViewModel>(); 
        }
    }
}
