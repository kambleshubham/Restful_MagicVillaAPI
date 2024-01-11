﻿using Microsoft.AspNetCore.Mvc;
using Restful_MagicVillaAPI.Data;
using Restful_MagicVillaAPI.Models;
using Restful_MagicVillaAPI.Models.DTO;

namespace Restful_MagicVillaAPI.Controllers
{
    //We can also fetch ControllerName in Route
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(VillaStore.villaList);
        }

        [HttpGet("{id:int}")]
        //ResponseType as ststus code...
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0) {  
                return BadRequest(); 
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null) { 
                return NotFound(); 
            }

            return Ok(villa);
        }

        [HttpGet("name")]
        public ActionResult<VillaDTO> GetVilla(string name)
        {
            if (name == null) {
                return BadRequest(string.Empty);
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Name == name);
            if (villa == null) {
                return NotFound(string.Empty);
            }
            return Ok(villa);
        }

    }
}
