﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Http.Cors;

namespace API.Controllers
{
    //[EnableCors(origins:"",headers:"*",methods:"*")]
    [RoutePrefix("ParkingProject/Parking")]
    public class ParkingController : ApiController
    {
        [Route("GetAllParkings")]
        [HttpGet]
        public IHttpActionResult GetAllParkings()
        {
            return Ok(BLL.BLL_Parking.GetAllParkings());
        }

        [Route("AddParking")]
        [HttpPost]
        public IHttpActionResult addParking(Entities.Parking_Entity newParking)
        {
            BLL.BLL_Parking.AddParking(newParking);
            return Ok("Parking added successfuly");
        }

        [Route("DeleteParking")]
        [HttpDelete]
        public IHttpActionResult deleteParking(int parking_id)
        {
            BLL.BLL_Parking.DeleteParking(parking_id);
            return Ok("deleted");
        }

        [Route("getParking_Search/{user_id}/{latA}/{longA}")]
        [HttpGet]
        public IHttpActionResult getParking_Search([FromUri]int user_id, [FromUri]decimal latA, [FromUri]decimal longA)
        {
            List<Parking_Entity> parkings= BLL.BLL_Parking.getParkings_Search(user_id,latA,longA);
            return Ok(parkings);
        }
    }



}
