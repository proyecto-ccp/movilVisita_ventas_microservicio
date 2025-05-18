using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http.Json;
using Visitas.Aplicacion.Dto;

namespace Visitas.Test
{
    public class VisitaControllerTest: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly Guid clienteId = Guid.Parse("660e8400-e29b-41d4-a716-446655440001");
        private readonly Guid vendedorId = Guid.Parse("c807fbe9-8c83-451c-b264-389426371e3e");
        private bool isTest = false;
        private int idVisita;

        public VisitaControllerTest(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task crearVisita_Ok()
        {
            var visita = new VisitaIn
            {
                IdCliente = clienteId,
                IdVendedor = vendedorId,
                FechaVisita = DateTime.UtcNow.AddDays(12),
                Motivo = "Test"
            };
            var response = await _client.PostAsJsonAsync("/api/Visita/CrearVisita", visita);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<BaseOut>();
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);

            idVisita = result.Id.Value;
            isTest = true;
        }

        [Fact]
        public async Task crearVisita_BadRequest()
        {
            var visita = new VisitaIn
            {
                IdCliente = Guid.NewGuid(),
                IdVendedor = vendedorId,
                FechaVisita = DateTime.UtcNow,
                Motivo = "Test"
            };
            var response = await _client.PostAsJsonAsync("/api/Visita/CrearVisita", visita);
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [Fact]
        public async Task modificarVisita_Ok()
        {
            if(!isTest)
                await crearVisita_Ok();

            var visita = new VisitaModificarIn
            {
                IdCliente = clienteId,
                IdVendedor = vendedorId,
                FechaVisita = DateTime.UtcNow,
                Motivo = "Test",
                Resultado = "Test",
                Estado = "REALIZADA"
            };

            var response = await _client.PutAsJsonAsync($"/api/Visita/ModificarVisita/{idVisita}", visita);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<BaseOut>();
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task modificarVisita_BadRequest()
        {
            var visita = new VisitaModificarIn
            {
                IdCliente = Guid.NewGuid(),
                IdVendedor = vendedorId,
                FechaVisita = DateTime.UtcNow,
                Motivo = "Test",
                Resultado = "Test",
                Estado = "REALIZADA"
            };
            var response = await _client.PutAsJsonAsync($"/api/Visita/ModificarVisita/{0}", visita);
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [Fact]
        public async Task ObtenerVisitaPorId_Ok()
        {
            if (!isTest)
                await crearVisita_Ok();

            var response = await _client.GetAsync($"/api/Visita/ObtenerVisita/{idVisita}");

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<VisitaOut>();
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ObtenerVisitaPorIdVenedor_Ok()
        {
            if (!isTest)
                await crearVisita_Ok();

            var response = await _client.GetAsync($"/api/Visita/ObtenerVisitasPorVendedorId/{vendedorId}");

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<VisitaOut>();
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ObtenerVisitaPorFecha_Ok()
        {
            if (!isTest)
                await crearVisita_Ok();

            var fecha = "2025-05-30T00:00:00.420Z";
            var response = await _client.GetAsync($"/api/Visita/ObtenerVisitasPorFecha/{fecha}/{vendedorId}");

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<VisitaOut>();
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}