using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.MessageCategoryDto;
using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using HotelProject.WebUI.Dtos.TestimonialDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // ABOUT
            CreateMap<AboutListDto, About>().ReverseMap();
            CreateMap<AboutCreateDto, About>().ReverseMap();
            CreateMap<AboutUpdateDto, About>().ReverseMap();

            // BOOKING
            CreateMap<BookingListDto, Booking>().ReverseMap();
            CreateMap<BookingCreateDto, Booking>().ReverseMap();
            CreateMap<BookingUpdateDto, Booking>().ReverseMap();

            // CONTACT
            CreateMap<ContactListDto, Contact>().ReverseMap();
            CreateMap<ContactCreateDto, Contact>().ReverseMap();
            CreateMap<ContactUpdateDto, Contact>().ReverseMap();

            // GUEST
            CreateMap<GuestListDto, Guest>().ReverseMap();
            CreateMap<GuestCreateDto, Guest>().ReverseMap();
            CreateMap<GuestUpdateDto, Guest>().ReverseMap();

            // ROOM
            CreateMap<RoomListDto, Room>().ReverseMap();
            CreateMap<RoomCreateDto, Room>().ReverseMap();
            CreateMap<RoomUpdateDto, Room>().ReverseMap();

            // SERVICE
            CreateMap<ServiceListDto, Service>().ReverseMap();
            CreateMap<ServiceCreateDto, Service>().ReverseMap();
            CreateMap<ServiceUpdateDto, Service>().ReverseMap();

            // STAFF
            CreateMap<StaffListDto, Staff>().ReverseMap();
            CreateMap<StaffCreateDto, Staff>().ReverseMap();
            CreateMap<StaffUpdateDto, Staff>().ReverseMap();

            // SUBSCRIBE
            CreateMap<SubscribeListDto, Subscribe>().ReverseMap();
            CreateMap<SubscribeCreateDto, Subscribe>().ReverseMap();
            CreateMap<SubscribeUpdateDto, Subscribe>().ReverseMap();

            // TESTIMONIAL
            CreateMap<TestimonialListDto, Testimonial>().ReverseMap();
            CreateMap<TestimonialCreateDto, Testimonial>().ReverseMap();
            CreateMap<TestimonialUpdateDto, Testimonial>().ReverseMap();

            // MESSAGECATEGORY
            CreateMap<MessageCategoryListDto, MessageCategory>().ReverseMap();
            // CreateMap<MessageCategoryCreateDto, MessageCategory>().ReverseMap();
            // CreateMap<MessageCategoryUpdateDto, MessageCategory>().ReverseMap();
        }
    }
}