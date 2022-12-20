/*
 * PxApi
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 2.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using PxWeb.Models.Api2;
using PxWeb.Attributes.Api2;
using Px.Abstractions.Interfaces;
using PxWeb.Helper.Api2;
using PxWeb.Mappers;
using PCAxis.Paxiom;

namespace PxWeb.Controllers.Api2
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class TableApiController : ControllerBase
    {
        private readonly IDataSource _dataSource;
        private readonly ILanguageHelper _languageHelper;
        private readonly IResponseMapper _responseMapper;

        public TableApiController(IDataSource dataSource, ILanguageHelper languageHelper, IResponseMapper responseMapper)
        {
            _dataSource = dataSource;
            _languageHelper = languageHelper;
            _responseMapper = responseMapper;
        }

        /// <summary>
        /// Endpoint to get table by {id}
        /// </summary>
        /// <param name="id">Id</param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/v2/tables/{id}")]
        [ValidateModelState]
        [SwaggerOperation("GetTableById")]
        [SwaggerResponse(statusCode: 200, type: typeof(Table), description: "Success")]
        public virtual IActionResult GetTableById([FromRoute(Name = "id")][Required] string id)
        {
            string lang = _languageHelper.HandleLanguage("en");
            IPXModelBuilder builder = _dataSource.CreateBuilder(id, lang);
            builder.BuildForSelection();
            var model = builder.Model;

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Table));
            string exampleJson = null;
            exampleJson = "\"\"";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<Table>(exampleJson)
                        : default(Table);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Endpoint for listing tables
        /// </summary>
        /// <param name="query">Selects only tables that that matches a criteria which is specified by the search parameter.</param>
        /// <param name="pastDays">Selects only tables that was updated from the time of execution going back number of days stated by the parameter pastDays. Valid values for past days are integers between 1 and ?</param>
        /// <param name="includeDiscontinued">Decides if discontinued tables are included in response.</param>
        /// <param name="pageNumber">Pagination: Decides which page number to return</param>
        /// <param name="pageSize">Pagination: Decides how many tables per page</param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/v2/tables")]
        [ValidateModelState]
        [SwaggerOperation("ListAllTables")]
        [SwaggerResponse(statusCode: 200, type: typeof(TablesResponse), description: "Success")]
        public virtual IActionResult ListAllTables([FromQuery(Name = "query")] string? query, [FromQuery(Name = "pastDays")] int? pastDays, [FromQuery(Name = "includeDiscontinued")] bool? includeDiscontinued, [FromQuery(Name = "pageNumber")] int? pageNumber, [FromQuery(Name = "pageSize")] int? pageSize)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(TablesResponse));
            string exampleJson = null;
            exampleJson = "\"\"";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<TablesResponse>(exampleJson)
                        : default(TablesResponse);            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
