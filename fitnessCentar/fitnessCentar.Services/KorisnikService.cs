﻿using AutoMapper;
using fitnessCentar.Model;
using fitnessCentar.Model.Requests;
using fitnessCentar.Model.SearchObjects;
using fitnessCentar.Services.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace fitnessCentar.Services
{
    public class KorisnikService : BaseCRUDService<Model.Korisnik, Database.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest>, IKorisnikService 
    {
        private readonly IEmailService _emailService;
        public KorisnikService(FitnessCentarContext context, IMapper mapper, IEmailService emailService)
            : base(context, mapper)
        {
            _emailService = emailService;
        }

        public override async Task BeforeInsert(Database.Korisnik entity, KorisnikInsertRequest insert)
        {
            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, insert.Password);
            entity.UlogaId=2;
        }

        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);

            return Convert.ToBase64String(byteArray);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public override IQueryable<Database.Korisnik> AddInclude(IQueryable<Database.Korisnik> query, KorisnikSearchObject? search = null)
        {
            query=query.Include("Uloga");
            return base.AddInclude(query, search);
        }

        public async Task<Model.Korisnik> Login(string username, string password)
        {
            var entity = await _context.Korisniks.Include(x => x.Uloga).FirstOrDefaultAsync(x => x.KorisnickoIme == username);


            if (entity != null)
            {
                var hash = GenerateHash(entity.PasswordSalt, password);

                if (hash == entity.PasswordHash)
                {

                    ReservationNotifier reservation = new ReservationNotifier
                    {
                        Id = 1,
                        Trening="Ovo je test",
                        Email = entity.Email,
                        Datum = DateTime.Now,
                        Vrijeme = DateTime.Now,


                    };

                    _emailService.SendingObject(reservation);


                    return _mapper.Map<Model.Korisnik>(entity); ;
                }
            }

            return null;
        }


        public override async Task<PagedResult<Model.Korisnik>> Get(KorisnikSearchObject search)
        {
            var query = _context.Set<Database.Korisnik>().AsQueryable().Include("Uloga").Include("PlanIshraneKorisniks.PlanIshrane");


            if (search != null && !string.IsNullOrEmpty(search.ImePrezime))
            {
                query = query.Where(x => x.Ime.Contains(search.ImePrezime) || x.Prezime.Contains(search.ImePrezime));
            }

            if(search!=null && search.UlogaId!=null)
            {
                query=query.Where(x => x.UlogaId==search.UlogaId);
            }

            PagedResult<Model.Korisnik> result = new PagedResult<Model.Korisnik>();

            
            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true && query.Any())
            {
                query = query.Skip(search.Page.Value * search.PageSize.Value).Take(search.PageSize.Value);
            }

            result.Count = await query.CountAsync();

            var list = await query.ToListAsync();

            result.Result = _mapper.Map<List<Model.Korisnik>>(list);

            return result;
        }









    }
}
