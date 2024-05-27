using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
    // DTO klasöründeki sınıflara burada aşağıdaki MAPLEME işlemlerini yapıyoruz
    // DTO klasöründeli sınıflar ile, ENTİTY klasöründeki sınıfları birbirleriyle eşleştirmiş oluyoruz.
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // Create dosyalarını geçtik.
            CreateMap<RoomCreateDto, Room>();
            CreateMap<Room, RoomCreateDto>();

            // Update dosyalarını geçtik. Yukarıdakinin kısaltılmış versiyonu.
            CreateMap<RoomUpdateDto, Room>().ReverseMap();
        }
    }
}