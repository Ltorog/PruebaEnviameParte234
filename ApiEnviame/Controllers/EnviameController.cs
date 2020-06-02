using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApiCertiCorp.DAL;
using ApiEnviame.Models;
using Betfair_API_NG.Json;
using GoogleApi.Entities.Maps.Directions.Response;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RestSharp;

namespace ApiEnviame.Controllers
{
    [Route("/api/v1/[controller]/")]
    [ApiController]
    public class EnviameController : ControllerBase
    {
        private readonly string apiKey = "AIzaSyDba1ksvhbdqkaeS7SGgSKbQrO77Zemxdg";
        //private readonly double latitudEnvio = -33.412331;
        //private readonly double longitudEnvio = -70.602687;
        private readonly string direccionEnvio = "Av Vitacura 2909, Las Condes";

        private readonly DBContext context;

        public static string NombreEnviador = "ENVIAME EMP";

        string[] lstNombrePersonas = { "Luis", "Victor", "Juana", "Rafael",
                          "Ivannia", "Fernando", "Constanza", "Julia",
                          "Valentina", "Benajmin", "Joaquin", "Francisco", "UsuariosTesting" };

        string[] lstEntidadesEnvio = { "CHILEXPRESS", "CORREOS DE CHILE", "DHL" };

        string[] lstDirecciones = { "Progreso 1093-1029, San Bernardo, Región Metropolitana", "Av. San Carlos 227-373, Puente Alto, Región Metropolitana",
                                    "Los Moreños 2825-2883, Iquique, Tarapacá", "Ejército 413-317, Puerto Montt, Los Lagos" };

        Random random = new Random();

        public EnviameController(DBContext context)
        {
            this.context = context;
        }


        /// <summary>
        /// Método para obtener envíos
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObtenerEnvios")]
        public async Task<ActionResult> ObtenerEnvios()
        {
            List<Envios> lstEnvios = new List<Envios>();

            try
            {
                lstEnvios = await context.ENV_ENVIOS.ToListAsync();
            }
            catch(Exception ex)
            {
                return BadRequest("Error al procesar listado: " + ex.Message);
            }

            return Ok(lstEnvios);
        }


        /// <summary>
        /// Método para modificar envío
        /// </summary>
        /// <param name="envio"></param>
        /// <returns></returns>
        [HttpPut("ModificarEnvio")]
        public async Task<ActionResult> ModificarEnvio(Envios envio)
        {
            Envios envioACambiar = new Envios();
            try
            {
                envioACambiar = await context.ENV_ENVIOS.FirstOrDefaultAsync(x => x.Id == envio.Id);

                if(envioACambiar != null)
                {
                    envioACambiar.Descripcion = envio.Descripcion;
                    envioACambiar.LugarEnvío = envio.LugarEnvío;
                    envioACambiar.Longitud = envioACambiar.Longitud;
                    envioACambiar.Latitud = envioACambiar.Latitud;
                    envioACambiar.FechaEnvio = envio.FechaEnvio;
                    envioACambiar.FechaEstimadaEntrega = envio.FechaEstimadaEntrega;
                    envioACambiar.NombrePersonaEnvio = envio.NombrePersonaEnvio;
                    envioACambiar.NombrePersonaRecibe = envio.NombrePersonaRecibe;
                    envioACambiar.EntidadEnvio = envio.EntidadEnvio;

                    try
                    {
                        context.ENV_ENVIOS.Update(envioACambiar);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return BadRequest("Error al intentar modificar el envío: " + ex.Message);
                    }
                    
                }
                else
                {
                    return NotFound("No se ha podido encontrar envío");
                }
            }
            catch(Exception ex)
            {
                return BadRequest("Error al procesar búsqueda de envío: " + ex.Message);
            }

            return Ok("Modificado con éxito");
        }


        /// <summary>
        /// Se obtiene el detalle de un envío
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ObtenerDetalleEnvio/{id}")]
        public async Task<ActionResult> ObtenerDetalleEnvio(long id)
        {
            DetalleEnvios detalleEnvio = new DetalleEnvios();

            try
            {
                detalleEnvio = await context.ENV_DETALLE_ENVIOS.LastOrDefaultAsync(x => x.Envio.Id == id);
            }
            catch(Exception ex)
            {
                return BadRequest("Error al obtener información del detalle: " + ex.Message);
            }

            return Ok(detalleEnvio);
        }



        [HttpGet("GenerarDataAleatoria")]
        public async Task<ActionResult> GenerarDataAleatoria()
        {
            try
            {
                List<Envios> lstEnviosRandom = new List<Envios>();

                for(int i = 0; i < 10; i++)
                {
                    Envios nuevoEnvio = new Envios();

                    nuevoEnvio.Descripcion = "CREACION RANDOM";

                    //Se generan datos random
                    int indiceDireccion = random.Next(lstDirecciones.Length);
                    string nombreDireccion = lstDirecciones[indiceDireccion];
                    nuevoEnvio.LugarEnvío = nombreDireccion;

                    nuevoEnvio.Latitud = 0;
                    nuevoEnvio.Longitud = 0;

                    nuevoEnvio.FechaEnvio = DateTime.Now;

                    nuevoEnvio.FechaEstimadaEntrega = DateTime.Now.AddDays(random.Next(10));


                    int indiceNombreEnvia = random.Next(lstNombrePersonas.Length);
                    string nombrePersonaEnvia = lstNombrePersonas[indiceNombreEnvia];
                    nuevoEnvio.NombrePersonaEnvio = nombrePersonaEnvia;


                    int indiceNombreRecibe = random.Next(lstNombrePersonas.Length);
                    string nombrePersonaRecibe = lstNombrePersonas[indiceNombreRecibe];
                    nuevoEnvio.NombrePersonaRecibe = nombrePersonaRecibe;


                    int indiceEntidad = random.Next(lstEntidadesEnvio.Length);
                    string nombreEntidad = lstEntidadesEnvio[indiceEntidad];
                    nuevoEnvio.EntidadEnvio = nombreEntidad;

                    lstEnviosRandom.Add(nuevoEnvio);
                }

                await context.ENV_ENVIOS.AddRangeAsync(lstEnviosRandom);

                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return BadRequest("Error al crear aleatorios: " + ex.Message);
            }

            return Ok("Se ha generado la data correctamente");
        }


        [HttpGet("CalcularDistancia/{id}")]
        public async Task<ActionResult> CalcularDistancia(long id)
        {
            Distancia distancia = new Distancia();
            try
            {
                Envios envio = await context.ENV_ENVIOS.FirstOrDefaultAsync();

                if (envio != null)
                {
                    string origen = envio.LugarEnvío;

                    string urlRequest = "";
                    string travelMode = "Walking"; //Driving, Walking, Bicycling, Transit.
                    urlRequest = @"https://maps.googleapis.com/maps/api/distancematrix/json?origins=" + origen + "&destinations=" + direccionEnvio + "&mode='" + travelMode + "'&sensor=false&key="+apiKey;

                    WebRequest request = WebRequest.Create(urlRequest);
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";

                    Stream dataStream = request.GetRequestStream();
                    dataStream.Close();

                    WebResponse response = request.GetResponse();
                    dataStream = response.GetResponseStream();

                    StreamReader reader = new StreamReader(dataStream);
                    string resp = reader.ReadToEnd();

                    reader.Close();
                    dataStream.Close();
                    response.Close();

                    var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseDistance.Parent>(resp);

                    int cantidadKilometros = (jsonResponse.rows[0].elements[0].distance.value) / 1000;

                    int agregarDias = RecursividadDiasEntrega(cantidadKilometros);
                    DateTime fechaEntrega = envio.FechaEnvio.AddDays(agregarDias);

                    return Ok("Su pedido se entregará el día: " + String.Format("{0:dd-MM-yyyy}", fechaEntrega));
                }
                else
                {
                    return NotFound("No se ha encontrado el envío");
                }
            }
            catch(Exception ex)
            {
                return BadRequest("Error al calcular distancia: " + ex.Message); 
            }

        }


        private int RecursividadDiasEntrega(int kilometros)
        {
            if(kilometros <= 100)
            {
                return 0;
            }
            if (kilometros <= 200 && kilometros > 100)
            {
                return 1;
            }
            else
            {
                return RecursividadDiasEntrega(kilometros - 100) + RecursividadDiasEntrega(kilometros - 200);
            }
        }


    }
}
