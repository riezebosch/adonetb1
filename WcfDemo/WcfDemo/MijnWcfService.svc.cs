using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AutoMapper;

namespace WcfDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MijnWcfService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MijnWcfService.svc or MijnWcfService.svc.cs at the Solution Explorer and start debugging.
    public class MijnWcfService : IMijnWcfService
    {
        static MijnWcfService()
        {
            Mapper
                .CreateMap<PersoonEF, PersoonDTO>()
                .ForMember(p => p.Naam, 
                    o => o.MapFrom(s => s.VolledigeNaam));

            Mapper.CreateMap<PersoonDTO, PersoonEF>()
                .ForMember(p => p.VolledigeNaam,
                    o => o.MapFrom(s => s.Naam));
        }

        public void DoWork(PersoonDTO p)
        {
            using (var ctx = new MijnContext())
            {
                //ctx.Personen.Add(new PersoonEF
                //    {
                //        Naam = p.Naam,
                //        Salaris = p.Salaris,
                //        Leeftijd = p.Leeftijd
                //    });

                ctx.Personen.Add(Mapper.Map<PersoonEF>(p));
                ctx.SaveChanges();
            }
        }

        public PersoonDTO Get(int id)
        {
            using (var ctx = new MijnContext())
            {
                ctx.Configuration.ProxyCreationEnabled =
                    ctx.Configuration.LazyLoadingEnabled = true;

                var p = ctx.Personen.Find(id);
                //return new PersoonDTO
                //    {
                //        Naam = p.Naam,
                //        Salaris = p.Salaris,
                //        Leeftijd = p.Leeftijd
                //    };

                return Mapper.Map<PersoonDTO>(p);
            }
        }
    }
}
