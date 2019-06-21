using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Http.Cors;
using Entities;

namespace API.Controllers
{
    //[EnableCors(origins: "", headers: "*", methods: "*")]
    [RoutePrefix("api/Car")]
    public class CarController : ApiController
    {
        [Route("GetAllCar")]
        [HttpGet]
        public List<Car_Entity> Get()
        {
            return BLL.BLL_Car.GetAllCar();
        }

        [Route("AddCar")]
        [HttpPost]
        public IHttpActionResult add_Car(Car_Entity newCar)
        {
            BLL.BLL_Car.AddCar(newCar);
            return Ok("Car added successfuly");
        }

        [Route("DeleteCar")]
        [HttpDelete]
        public IHttpActionResult Delete_Car(int car_id)
        {
            BLL.BLL_Car.DeleteCar(car_id);
            return Ok("deleted");
        }
        [Route("editCar")]
        [HttpPost]
        public IHttpActionResult edit_Car(Car_Entity newCar)
        {
            BLL.BLL_Car.editCar(newCar);
            return Ok("Car added successfuly");
        }
    }
}

