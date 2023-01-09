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
using PxWeb.Api2.Server.Models;
using PCAxis.Paxiom;
using Px.Abstractions.Interfaces;
using PxWeb.Helper.Api2;
using PxWeb.Mappers;

namespace PxWeb.Controllers.Api2
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class TableApiController : PxWeb.Api2.Server.Controllers.TableApiController
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
        /// Endpoint to get metadata about table by {id}
        /// HttpGet
        /// Route /api/v2/tables/{id}/metadata
        /// </summary>
        /// <remarks>**Used for listing detailed information about a specific table** * List all variables and values and all other metadata needed to be able to fetch data  * Also links to where to:   + Fetch   - Where to get information about codelists  * 2 output formats   + Custom json    - JSON-stat2  </remarks>
        /// <param name="id">Id</param>
        /// <response code="200">Success</response>
        /// <response code="400">Error respsone for 400</response>
        /// <response code="404">Error respsone for 404</response>
        /// <response code="429">Error respsone for 429</response>
        public override IActionResult GetMetadataById([FromRoute(Name = "id"), Required] string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint to get table by {id}
        /// HttpGet
        /// Route /api/v2/tables/{id}
        /// </summary>
        /// <param name="id">Id</param>
        /// <response code="200">Success</response>
        /// <response code="400">Error respsone for 400</response>
        /// <response code="404">Error respsone for 404</response>
        /// <response code="429">Error respsone for 429</response>
        public override IActionResult GetTableById([FromRoute(Name = "id"), Required] string id)
        {
            //TODO: lang should be an optional parameter - fix yaml
            string lang = "en";

            lang = _languageHelper.HandleLanguage(lang);
            IPXModelBuilder builder = _dataSource.CreateBuilder(id, lang);

            if (builder != null)
            {
                try
                {
                    builder.BuildForSelection();
                    var model = builder.Model;

                    Table t = new Table();
                    t.Id = model.Meta.MainTable;
                    t.Label = model.Meta.Title;
                    return new ObjectResult(t);
                }
                catch (Exception)
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// List information about the codelist that is associated with the table.
        /// HttpGet
        /// Route /api/v2/tables/{id}/codelists/{codeListId}
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="codeListId">Identifier for a code list</param>
        /// <param name="lang">The language if the default is not what you want.</param>
        /// <response code="200">Success</response>
        /// <response code="400">Error respsone for 400</response>
        /// <response code="404">Error respsone for 404</response>
        /// <response code="429">Error respsone for 429</response>
        public override IActionResult GetTableCodeListById([FromRoute(Name = "id"), Required] string id, [FromRoute(Name = "codeListId"), Required] string codeListId, [FromQuery(Name = "lang")] string? lang)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List all codelists that are associated with the table
        /// HttpGet
        /// Route /api/v2/tables/{id}/codelists
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="lang">The language if the default is not what you want.</param>
        /// <response code="200">Success</response>
        /// <response code="400">Error respsone for 400</response>
        /// <response code="404">Error respsone for 404</response>
        /// <response code="429">Error respsone for 429</response>
        public override IActionResult GetTableCodeLists([FromRoute(Name = "id"), Required] string id, [FromQuery(Name = "lang")] string? lang)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get table data
        /// HttpGet
        /// Route /api/v2/tables/{id}/data
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="lang">The language if the default is not what you want.</param>
        /// <param name="valuecodes"></param>
        /// <param name="codelist"></param>
        /// <param name="outputvalues"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Error respsone for 400</response>
        /// <response code="403">Error respsone for 403</response>
        /// <response code="404">Error respsone for 404</response>
        /// <response code="429">Error respsone for 429</response>
        public override IActionResult GetTableData([FromRoute(Name = "id"), Required] string id, [FromQuery(Name = "lang")] string? lang, [FromQuery(Name = "valuecodes")] Dictionary<string, List<string>>? valuecodes, [FromQuery(Name = "codelist")] Dictionary<string, string>? codelist, [FromQuery(Name = "outputvalues")] Dictionary<string, CodeListOutputValuesStyle>? outputvalues)
        {
            throw new NotImplementedException();
        }
    }
}