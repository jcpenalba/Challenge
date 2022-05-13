using AutoMapper;
using challenge.DTOs.Peliculas;
using challenge.Models;
using System;
using System.Linq;


namespace hallenge.Helpers
{
    public class AutomapperConfiguration
    {
        private static MapperConfiguration instance;

        private AutomapperConfiguration()
        {
        }

        public static MapperConfiguration Instance()
        {
            if (instance == null)
            {
                instance = new MapperConfiguration(conf =>
                {
                    conf.CreateMap<PeliculaActor, Actor>().ConvertUsing(r => r.Actor);
                    conf.CreateMap<Genero, String>().ConvertUsing(r => r.Nombre);
                    conf.CreateMap<Productora, String>().ConvertUsing(r => r.Nombre);

                    conf.CreateMap<TimeSpan, TimeDTO>()
                    .ForMember(d => d.Hours, o => o.MapFrom(s => s.Hours))
                    .ForMember(d => d.Minutes, o => o.MapFrom(s => s.Minutes))
                    .ForMember(d => d.Seconds, o => o.MapFrom(s => s.Seconds));


                    conf.CreateMap<TimeDTO, TimeSpan>()
                    .ForMember(d => d.Hours, o => o.MapFrom(s => s.Hours))
                    .ForMember(d => d.Minutes, o => o.MapFrom(s => s.Minutes))
                    .ForMember(d => d.Seconds, o => o.MapFrom(s => s.Seconds));

                    conf.CreateMap<Pelicula, GetPeliculaDTO>().ReverseMap();

                    conf.CreateMap<NewPeliculaDTO, Pelicula>().ReverseMap();
                    
                    conf.CreateMap<PeliculaDTO, Pelicula>().ReverseMap();
                });
            }

            return instance;
        }
    }
}