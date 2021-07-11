using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aisoftware.Tracker.UseCases.Handlers
{
    public class BaseHandler<TEntity> where TEntity : class
    {
        readonly protected DbSet<TEntity> _entity;

        protected readonly ApplicationDbContext _context;
        protected readonly HandlerFactory _handlerFactory;
        protected readonly IOptions<Config> _config;

        public BaseHandler(ApplicationDbContext context, IOptions<Config> config, HandlerFactory handlerFactory, DbSet<TEntity> entity)
        {
            _context = context;
            _entity = entity;
            _handlerFactory = handlerFactory;
            _config = config;

            if (_config == null)
                _config = new Config();
        }

        public TEntity Get(object id)
        {
            return _entity.Find(id);
        }

        /// <summary>
        /// Busca todos os elementos, 
        /// MAS TRAZ NO MÁXIMO 1000
        /// </summary>
        public IEnumerable<TEntity> GetList()
        {
            return _entity.Take(1000);
        }

        public TEntity Criar(TEntity obj)
        {
            var im = _entity.Add(obj);
            Commit();
            return im.Entity;
        }

        public TEntity Update(TEntity obj)
        {
            //_context.Detached(obj);
            var im = _entity.Update(obj);
            Commit();
            return im.Entity;
        }

        public void Delete(TEntity obj)
        {
            _entity.Remove(obj);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
