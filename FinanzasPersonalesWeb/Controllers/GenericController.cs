using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using FinanzasPersonalesWeb.Models;

namespace FinanzasPersonalesWeb.Controllers
{
    public class GenericController : Controller
    {
        private Model1 db = new Model1();

        public JsonResult GetCuentas()
        {
            var resultado = (from t in db.Cuentas
                             select t
                          ).ToList().Select(obj => new Cuentas
                          {
                              CuentaId = obj.CuentaId,
                              CuentaDescripcion = obj.CuentaDescripcion
                          }).ToList();

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTipoIngresos()
        {
            var resultado = (from t in db.TiposIngresos
                             select t
                          ).ToList().Select(obj => new TiposIngresos
                          {
                              TipoIngresoId = obj.TipoIngresoId,
                              TipoIngresoDescripcion = obj.TipoIngresoDescripcion
                          }).ToList();

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTipoGastos()
        {
            var resultado = (from t in db.TiposGastos
                             select t
                          ).ToList().Select(obj => new TiposGastos
                          {
                              TiposGastosId = obj.TiposGastosId,
                              TiposGastosDescripcion = obj.TiposGastosDescripcion
                          }).ToList();

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

    }
}
