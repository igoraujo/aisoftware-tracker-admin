﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aisoftware.Tracker.Models.ViewModels;
using Aisoftware.Tracker.Admin.Code;
using Aisoftware.Tracker.UseCases.Handlers;

namespace Aisoftware.Tracker.Admin.Pages
{
    public class DashboardModel : MoviyPageModel
    {
        public DashboardModel(HandlerFactory handlerFactory) : base(handlerFactory) { }
        protected override bool AreaLogada() => true;

        public int PassagensDia { get; set; }
        public int UsuariosDia { get; set; }
        public int ViagensDia { get; set; }
        public int ViagensAtivas { get; set; }
        public List<ActiveTravelsPerDay> ViagensAbertasPorDia { get; set; }

        public void OnGet()
        {
            PassagensDia = HandlerFactory.Ticket.GetSoldTicketsPerDay();
            UsuariosDia = HandlerFactory.Passenger.GetUsersPerDay();
            ViagensDia = HandlerFactory.Travel.GetActiveTravelsPerDay();
            ViagensAtivas = HandlerFactory.Travel.GetActiveTravels();
            ViagensAbertasPorDia = HandlerFactory.Travel.GetActiveTravelsPerDayList();
        }
    }
}