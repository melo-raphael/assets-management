using AutoMapper;
using projeto.tcc.order.managament.application.Dtos;
using projeto.tcc.order.managament.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace projeto.tcc.order.managament.application.AutoMapper.AssetsProfile
{
    public class AssetsToGetAllAssetsResponseDto : Profile
    {
        public AssetsToGetAllAssetsResponseDto()
        {
            CreateGetAllAssetsResponseDto();
        }

        private void CreateGetAllAssetsResponseDto()
        {
            CreateMap<Assets, GetAllAssetsResponseDto>();                      
        }
    }
}
