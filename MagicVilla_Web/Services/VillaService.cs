﻿using MagicVilla_Utilidad;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace MagicVilla_Web.Services
{
    public class VillaService : BaseService, IVillaService
    {
        public readonly IHttpClientFactory _httpClient;
        private string _villaUrl;

        public VillaService(IHttpClientFactory httpClient, IConfiguration configuration) :base(httpClient)
        {
            _httpClient = httpClient;

            _villaUrl = configuration.GetValue<string>("ServiceUrls:API_URL");

        }
        public Task<T> Actualizar<T>(VillaUpdateDto dto)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                APITipo = DS.APITipo.PUT,
                Datos = dto,
                Url = _villaUrl + "/api/Villa/" + dto.Id
            }) ;
        }

        public Task<T> Crear<T>(VillaCreateDto dto)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                APITipo = DS.APITipo.POST,
                Datos = dto,
                Url = _villaUrl+"/api/Villa"
            }) ;
        }

        public Task<T> Obtener<T>(int id)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                APITipo = DS.APITipo.GET,
                Url = _villaUrl + "/api/Villa/" + id
            });
        }

        public Task<T> ObtenerTodos<T>()
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                APITipo = DS.APITipo.GET,
                Url = _villaUrl + "/api/Villa/" 
            });
        }

        public Task<T> Remover<T>(int id)
        {
            return SendAsync<T>(new Models.APIRequest()
            {
                APITipo = DS.APITipo.DELETE,
                Url = _villaUrl + "/api/Villa/" + id
            });
        }
    }
}
