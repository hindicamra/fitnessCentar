﻿using AutoMapper;
using fitnessCentar.Model;
using fitnessCentar.Model.SearchObjects;
using fitnessCentar.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCentar.Services
{
    public class BaseService<T, TDb, TSearch>:IService<T, TSearch> where T: class where TDb : class where TSearch : BaseSearchObject
    {
        public FitnessCentarContext _context;

        public IMapper _mapper { get; set; }

        public BaseService(FitnessCentarContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResult<T>> Get(TSearch search)
        {
            var query = _context.Set<TDb>().AsQueryable();

            PagedResult<T> result = new PagedResult<T>();

            result.Count = await query.CountAsync();

            query = AddFilter(query, search);
            query = AddInclude(query, search);

            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                query = query.Take(search.PageSize.Value).Skip(search.Page.Value * search.PageSize.Value);
            }
            var list = await query.ToListAsync();

           
            var tmp = _mapper.Map<List<T>>(list);
            result.Result = tmp;
            return result;

        }
        
        public virtual IQueryable<TDb> AddInclude(IQueryable<TDb> query,TSearch? search = null)
        {
            return query;
        }

        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query, TSearch? search = null)
        {
            return query;
        }
        public async Task<T> GetById(int id)
        {
            var entity = _context.Set<TDb>().FindAsync();

            return _mapper.Map<T>(entity);

        }
    }
}
