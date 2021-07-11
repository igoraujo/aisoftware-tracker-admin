using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aisoftware.Tracker.Models;
using System.Web;
using Aisoftware.Tracker.UseCases.Tools;
using Server.Tools;
using X.PagedList;

namespace Aisoftware.Tracker.UseCases.Handlers
{
    public class DriverHandler : BaseHandler<Driver>
    {
        public DriverHandler(ApplicationDbContext context, IOptions<Config> config, HandlerFactory handlerFactory) : base(context, config, handlerFactory, context.driver) { }

        public IPagedList<Driver> GetAll(string companyID, int pagina, int qtdRegisters, string pesquisa = "")
        {
            try
            {
               return null;
            }
            catch (Exception ex)
            {
                throw new MoviyException(ex.Message);
            }
        }

        //private string GetDriversQuery(string companyID, int qtdRegistros = 10, int pagina = 1, string pesquisa = "", string active = "")
        //{
        //    string filtro = string.Empty;
        //    string filtroStatus = string.Empty;

        //    if (!string.IsNullOrEmpty(pesquisa))
        //    {
        //        filtro = $" and (name ilike '%' || {pesquisa} || '%' or social number '%' || {pesquisa} || '%')";
        //    }
        //    if (!string.IsNullOrEmpty(active))
        //    {
        //        if (active.Trim().ToLower() == "inativo")
        //        {
        //            filtroStatus = $" and active = false";
        //        }
        //        else filtroStatus = $" and active = true";
        //    }

        //    var query = Environment.NewLine + "select id, " +
        //                                   Environment.NewLine + "name, " +
        //                                   Environment.NewLine + "socialnumber, " +
        //                                   Environment.NewLine + "email, " +
        //                                   Environment.NewLine + "password, " +
        //                                   Environment.NewLine + "token, " +
        //                                   Environment.NewLine + "cellphone, " +
        //                                   Environment.NewLine + "birthdate, " +
        //                                   Environment.NewLine + "companyid, " +
        //                                   Environment.NewLine + "licenseid, " +
        //                                   Environment.NewLine + "active, " +
        //                                   Environment.NewLine + "registerdate, " +
        //                                   Environment.NewLine + "alterdate " +
        //                                   Environment.NewLine + "from driver " +
        //                                   Environment.NewLine + $"where companyid = '{companyID}' " +
        //                                   Environment.NewLine + filtro +
        //                                   Environment.NewLine + filtroStatus +
        //                                   Environment.NewLine + "order by name " +
        //                                   Environment.NewLine + $"limit {qtdRegistros} offset {pagina}";

        //    return query;
        //}
    }
}
